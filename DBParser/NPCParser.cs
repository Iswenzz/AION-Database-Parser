using HtmlAgilityPack;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System;
using System.Threading;
using Console = Colorful.Console;
using System.Drawing;

using Iswenzz.AION.DBParser.Data;

namespace Iswenzz.AION.DBParser
{
    public class NpcParser
    {
        public string UrlName { get; set; }
        public string Url { get; set; }
        public string WorldID { get; set; }

        public NpcParser(string name, string url)
        {
            Console.ForegroundColor = Color.LightGray;

            UrlName = name;
            Url = url;
            WorldID = Program.GetLastDir(Url);

            Log.Config(Program.SaveADBLog(Url));
            Trace.WriteLine("Loading " + name + ": " + url);

            CreateXML();
            ParseNPC();
        }

        private void ParseNPC()
        {
            Program.PhantomNewTab(Url, 1);

            // Reset table settings
            Program.Driver.FindElementByXPath("//*[@id=\"NpcTable_wrapper\"]/div[1]/div[2]/div/a").Click();

            // Wait if table is loading, Quit if table is empty
            while (Program.Driver.FindElementByXPath("//*[@id=\"NpcTable\"]/tbody/tr/td").Displayed)
            {
                if (Program.Driver.FindElementByXPath("//*[@id=\"NpcTable\"]/tbody/tr/td").Text 
                    == "No data available in table")
                {
                    Trace.WriteLine("\nNo data available in table.");
                    Thread.Sleep(2000);
                    Program.Main();
                }
                else
                    Thread.Sleep(500);
            }

            HtmlDocument doc = new HtmlDocument();
            int npcs_size = TableUtility.Count(Program.Driver, "//*[@id=\"NpcTable_info\"]");
            NpcEntry[] npcs = new NpcEntry[npcs_size];

            // Sort by ID
            Program.Driver.ExecuteScript("document.evaluate(\"//*[@id=\\\"NpcTable\\\"]/thead/tr/th[1]\"," +
                " document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();");
            // Set the table size to 50
            Program.Driver.ExecuteScript("document.getElementsByTagName(\"option\")[1]" +
                ".setAttribute(\"value\",\"50\");");
            Program.Driver.FindElementByXPath("//*[@id=\"NpcTable_length\"]/label/select").Click();
            Program.Driver.FindElementByXPath("//*[@id=\"NpcTable_length\"]/label/select/option[2]").Click();
            // Click on Page 1
            Program.Driver.FindElementByXPath("//*[@id=\"NpcTable_paginate\"]/ul/li[2]/a").Click();

            int file_index = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int validNpcIndex = 0;
            for (int item = 0; item < npcs_size;)
            {
                doc.LoadHtml(File.ReadAllText(Program.SaveHTML(file_index++.ToString())));
                HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id=\"NpcTable\"]");
                for (int tr = 0; tr < 50; tr++)
                {
                    try
                    {
                        string tableXPath = "";
                        if (table != null && doc.DocumentNode.SelectSingleNode(
                            table.XPath + "/tbody/tr[" + (tr + 1) + "]/td[1]") != null)
                            tableXPath = table.XPath;
                        else
                            throw new Exception("{EOF}");

                        NPCRace race = TableUtility.ParseRace(doc, tableXPath + "/tbody/tr[" + (tr + 1) 
                            + "]/td[3]/div");
                        int id = TableUtility.ParseText<int>(doc.DocumentNode.SelectSingleNode(tableXPath
                            + "/tbody/tr[" + (tr + 1) + "]/td[1]").InnerText);
                        NPCGrade grade = TableUtility.ParseGrade(TableUtility.ParseText<NPCGrade>(
                            doc.DocumentNode.SelectSingleNode(tableXPath + "/tbody/tr[" + (tr + 1) 
                            + "]/td[6]").InnerText));
                        string name = "";
                        string url = "";

                        if (race == NPCRace.BALAUR)
                        {
                            name = TableUtility.ParseText<string>(doc.DocumentNode.SelectSingleNode(
                                tableXPath + "/tbody/tr[" + (tr + 1) + "]/td[3]/a/b").InnerText);
                            url = TableUtility.ParseUrl(TableUtility.ParseText<string>(
                                doc.DocumentNode.SelectSingleNode(tableXPath + "/tbody/tr[" + (tr + 1) 
                                + "]/td[3]/a").GetAttributeValue("href", "")));
                        }
                        else
                        {
                            name = TableUtility.ParseText<string>(doc.DocumentNode.SelectSingleNode(tableXPath
                                + "/tbody/tr[" + (tr + 1) + "]/td[3]/div/a/b").InnerText);
                            url = TableUtility.ParseUrl(TableUtility.ParseText<string>(
                                doc.DocumentNode.SelectSingleNode(tableXPath + "/tbody/tr[" + (tr + 1) 
                                + "]/td[3]/div/a").GetAttributeValue("href", "")));
                        }
                        if (validNpcIndex > 0 && npcs[validNpcIndex - 1].ID == id)
                            throw new Exception("{Duplicate ID}");

                        npcs[validNpcIndex] = new NpcEntry();
                        npcs[validNpcIndex].Race = race;
                        npcs[validNpcIndex].Name = name;
                        npcs[validNpcIndex].Url = url;
                        npcs[validNpcIndex].ID = id;
                        npcs[validNpcIndex].Grade = grade;

                        npcs[validNpcIndex].Info(item + 1);
                        npcs[validNpcIndex].GetDrop(Program.LoadADBXName(Url, UrlName));
                        validNpcIndex++;
                    }
                    catch /*(Exception e)*/
                    {
                        //Trace.WriteLine(e.Message);
                    }
                    finally
                    {
                        item++;
                    }
                }
                // Click on Next Page
                Program.Driver.FindElementByXPath("//*[@id=\"NpcTable_next\"]/a").Click();
            }

            timer.Stop();
            Trace.WriteLine("\nParsed " + UrlName + " in " + timer.Elapsed.ToString("hh\\:mm\\.ss"));
        }

        private void CreateXML()
        {
            XNamespace xmlns = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
            XNamespace xsi = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

            XDocument xml = new XDocument
            (
                new XDeclaration("1.0", "ISO-8859-1", null),
                new XElement("npc_drops", new XAttribute(XNamespace.Xmlns + "xsi", xmlns), new XAttribute(xsi + "noNamespaceSchemaLocation", "npc_drops.xsd"),
                new XComment("Generated on " + DateTime.Now + " Using github.com/iswenzz AION Database Parser"))
            );

            xml.Save(Program.SaveADBXName(Url, UrlName));
        }
    }
}