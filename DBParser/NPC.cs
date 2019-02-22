using HtmlAgilityPack;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using Console = Colorful.Console;
using System.Drawing;

using Iswenzz.AION.utility;

namespace Iswenzz.AION.DBParser
{
    public class NPC_Parser
    {
        public static string Url_Name;
        public static string Url;
        public static string World_ID;

        public NPC_Parser(string name, string url)
        {
            Console.ForegroundColor = Color.LightGray;

            Url_Name = name;
            Url = url;
            World_ID = Program.Last_Dir(Url);

            Log.Config(Program.Save_Log(Url));
            Trace.WriteLine("Loading " + name + ": " + url);

            this.Drop_NPC();
            this.Parse_NPC();
        }

        private void Parse_NPC()
        {
            Program.PhantomNewTab(Url, 1);

            // Reset table settings
            Program.driver.FindElementByXPath("//*[@id=\"NpcTable_wrapper\"]/div[1]/div[2]/div/a").Click();

            // Wait if table is loading, Quit if table is empty
            while (Program.driver.FindElementByXPath("//*[@id=\"NpcTable\"]/tbody/tr/td").Displayed)
            {
                if (Program.driver.FindElementByXPath("//*[@id=\"NpcTable\"]/tbody/tr/td").Text == "No data available in table")
                {
                    Trace.WriteLine("\nNo data available in table.");
                    Thread.Sleep(2000);
                    Program.Main();
                }
                else
                    Thread.Sleep(500);
            }

            HtmlDocument doc = new HtmlDocument();
            int npcs_size = Table_Info.Count(Program.driver, "//*[@id=\"NpcTable_info\"]");
            NPC_Info[] npcs = new NPC_Info[npcs_size];

            // Sort by ID
            Program.driver.ExecuteScript("document.evaluate(\"//*[@id=\\\"NpcTable\\\"]/thead/tr/th[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();");
            // Set the table size to 50
            Program.driver.ExecuteScript("document.getElementsByTagName(\"option\")[1].setAttribute(\"value\",\"50\");");
            Program.driver.FindElementByXPath("//*[@id=\"NpcTable_length\"]/label/select").Click();
            Program.driver.FindElementByXPath("//*[@id=\"NpcTable_length\"]/label/select/option[2]").Click();
            // Click on Page 1
            Program.driver.FindElementByXPath("//*[@id=\"NpcTable_paginate\"]/ul/li[2]/a").Click();

            int file_index = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int v = 0;
            for (int i = 0; i < npcs_size; i++)
            {
                doc.LoadHtml(File.ReadAllText(Program.Save_HTML(file_index++.ToString())));

                for (int t = 0; t < 50; t++)
                {
                    try
                    {
                        if (doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[1]") == null)
                            throw new Exception("End of Table");

                        Table_Info.NPC_Race race = Table_Info.ParseRace(doc, "/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/div");
                        int id = Table_Info.ParseText<int>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[1]").InnerText);
                        Table_Info.NPC_Grade grade = Table_Info.ParseGrade(Table_Info.ParseText<Table_Info.NPC_Grade>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[6]").InnerText));
                        string name = "";
                        string url = "";

                        if (race == Table_Info.NPC_Race.BALAUR)
                        {
                            name = Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/a/b").InnerText);
                            url = Table_Info.ParseUrl(Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/a").GetAttributeValue("href", "")));
                        }

                        else
                        {
                            name = Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/div/a/b").InnerText);
                            url = Table_Info.ParseUrl(Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/div/a").GetAttributeValue("href", "")));
                        }

                        if (v > 0 && npcs[v - 1].ID == id)
                            throw new Exception("Duplicate");

                        npcs[v] = new NPC_Info();
                        npcs[v].Race = race;
                        npcs[v].Name = name;
                        npcs[v].Url = url;
                        npcs[v].ID = id;
                        npcs[v].Grade = grade;

                        npcs[v].Info(i + 1);
                        npcs[v].getDrop();
                        i++; v++;
                    }

                    catch (Exception e)
                    {
                        i++;

                        switch (e.Message)
                        {
                            case "Duplicate": continue;
                            case "End of Table": continue;
                            default: break;
                        }

                        Trace.WriteLine("\n" + e + "\n");
                    }
                }

                i--;
                // Click on Next Page
                Program.driver.FindElementByXPath("//*[@id=\"NpcTable_next\"]/a").Click();
            }

            timer.Stop();
            Trace.WriteLine("\nParsed " + Url_Name + " in " + timer.Elapsed.ToString("hh\\:mm\\.ss"));
        }

        private void Drop_NPC()
        {
            XNamespace xmlns = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
            XNamespace xsi = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

            XDocument xml = new XDocument
            (
                new XDeclaration("1.0", "ISO-8859-1", null),
                new XElement("npc_drops", new XAttribute(XNamespace.Xmlns + "xsi", xmlns), new XAttribute(xsi + "noNamespaceSchemaLocation", "npc_drops.xsd"),
                new XComment("Generated on " + DateTime.Now + " Using github.com/iswenzz AION Database Parser"))
            );

            xml.Save(Program.Save_XML(Url, Url_Name));
        }
    }

    public class NPC_Info
    {
        public string Url;

        public Table_Info.NPC_Race Race;
        public int ID;
        public Table_Info.NPC_Grade Grade;
        public int Level = 0;
        public string Name;
        public int HP;

        public void Info(int index = 0)
        {
            Trace.WriteLine("\n" +
                index       + ". " +
                this.Race   + " " +
                this.ID     + " " +
                this.Grade  + " " +
                this.Name   + "\n"
            );
        }

        public void getDrop()
        {
            Item_NPC_Parser npc = new Item_NPC_Parser(this.Url, this.Name, this.Grade);
            if (npc.error_code == -1) return;
            XDocument xml = XDocument.Load(Program.Load_XML(NPC_Parser.Url, NPC_Parser.Url_Name));
            List<string> group = new List<string>();
            Dictionary<string, XElement> group_element = new Dictionary<string, XElement>();

            // Add this NPC to root
            XElement this_npc = new XElement("npc_drop", new XAttribute("npc_id", this.ID), new XAttribute("npc_name", this.Name));

            // Create child node for each item group of this NPC
            foreach (Item_NPC_Info item_group in npc.items)
            {
                if (item_group == null) continue;

                if(!group.Contains(item_group.Group))
                {
                    group.Add(item_group.Group);

                    XElement elem = new XElement("drop_group", new XAttribute("name", item_group.Group),
                        new XAttribute("use_category", "true"), new XAttribute("race", "PC_ALL"));

                    group_element.Add(item_group.Group, elem);
                    this_npc.Add(elem);
                }
            }

            // Add each item to there own child node group
            foreach (Item_NPC_Info item in npc.items)
            {
                if (item == null) continue;

                group_element[item.Group].Add
                (
                    new XElement("drop", new XAttribute("item_id", item.ID), new XAttribute("chance", item.Rarity.ToString("0.000")),
                    new XAttribute("min_amount", item.Min), new XAttribute("max_amount", item.Max), new XAttribute("no_reduce", "false"),
                    new XAttribute("eachmember", "false"), new XAttribute("name", item.Name))
                );
            }

            xml.Root.Add(this_npc);
            xml.Save(Program.Save_XML(NPC_Parser.Url, NPC_Parser.Url_Name));
        }
    }
}