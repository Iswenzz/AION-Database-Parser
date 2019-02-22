using HtmlAgilityPack;
using System.IO;
using System.Threading;
using System;
using System.Diagnostics;
using Console = Colorful.Console;

namespace Iswenzz.AION.DBParser
{
    public class Item_NPC_Parser
    {
        private string Url;

        public static string NPC_name;
        public static int NPC_level = 0;
        public static Table_Info.NPC_Grade NPC_Grade;
        public int error_code;

        public Item_NPC_Info[] items;

        public Item_NPC_Parser(string url, string npc_name, Table_Info.NPC_Grade npc_grade)
        {
            NPC_Grade = npc_grade;
            NPC_name = npc_name;

            this.Url = url;
            this.Parse_Item();
        }

        private void Parse_Item()
        {
            Program.PhantomNewTab(this.Url, 2);
            HtmlDocument doc = new HtmlDocument();

            // Get the level of this npc
            try { NPC_level = Table_Info.ParseText<int>(Table_Info.ParseLevel(Program.driver.FindElementByXPath("/html/body/div[3]/div[1]/div[3]/div/div[1]/div/table/tbody/tr[4]/td[2]").Text)); } catch { NPC_level = 0; }

            // Click on loot button
            try { Program.driver.FindElementByXPath("//*[@href=\"#tabs-drop\"]").Click(); }
            catch
            {
                Program.PhantomCloseTab();
                Program.PhantomTab(1);
                Trace.WriteLine("\tNo items for this NPC!");
                this.error_code = -1;
                return;
            }

            Thread.Sleep(500);

            int items_size = Table_Info.Count(Program.driver, "//*[@id=\"npcDropTable_info\"]");
            items = new Item_NPC_Info[items_size + 1]; // + 1 for kinah

            // Set the table size to 50
            Program.driver.ExecuteScript("document.getElementsByTagName(\"option\")[1].setAttribute(\"value\",\"50\");");
            Program.driver.FindElementByXPath("//*[@id=\"npcDropTable_length\"]/label/select").Click();
            Program.driver.FindElementByXPath("//*[@id=\"npcDropTable_length\"]/label/select/option[2]").Click();
            // Click on Page 1
            Program.driver.FindElementByXPath("//*[@id=\"npcDropTable_paginate\"]/ul/li[2]/a").Click();

            int file_index = 1;
            int i = 0;

            for (; i < items_size; i++)
            {
                doc.LoadHtml(File.ReadAllText(Program.Save_HTML(file_index++.ToString())));

                for (int t = 0; t < 50; t++)
                {
                    try
                    {
                        if (doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[1]") == null)
                            throw new Exception("End of Table");

                        int id = Table_Info.ParseText<int>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[1]").InnerText);
                        string name = Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/a/b").InnerText);
                        Table_Info.Item_Quality color = Table_Info.ParseColor(Table_Info.ParseText<Table_Info.Item_Quality>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/a").GetAttributeValue("class", "")));
                        int level = Table_Info.ParseText<int>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[4]").InnerText);
                        string url = Table_Info.ParseUrl(Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[3]/a").GetAttributeValue("href", "")));
                        string icon = Table_Info.ParseText<string>(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody/tr[" + (t + 1) + "]/td[2]/div/div/a/img").GetAttributeValue("src", ""));
                        string group = Table_Info.ParseGroup(color, icon);

                        items[i] = new Item_NPC_Info();
                        items[i].ID = id;
                        items[i].Name = name;
                        items[i].Color = color;
                        items[i].Level = level;
                        items[i].Url = url;
                        items[i].Group = group;

                        items[i].Info(i + 1);
                        items[i].getRarity();
                        items[i].getMinMax();
                        i++;
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
                Program.driver.FindElementByXPath("//*[@id=\"npcDropTable_next\"]/a").Click();
            }

            try
            {
                int kinah = items.Length - 1;

                items[kinah] = new Item_NPC_Info();
                items[kinah].ID = 182400001;
                items[kinah].Name = "Kinah";
                items[kinah].Color = Table_Info.Item_Quality.COMMON;
                items[kinah].Level = 1;
                items[kinah].Url = "http://aiondatabase.net/en/item/182400001/";
                items[kinah].Group = "KINAH";

                items[kinah].Info(kinah + 1);
                items[kinah].getRarity();
                items[kinah].getMinMax();
            }
            catch { }

            Program.PhantomCloseTab();
            Program.PhantomTab(1);
        }
    }

    public class Item_NPC_Info
    {
        public string Url;

        public Table_Info.Item_Quality Color;
        public string Group;
        public int ID;
        public string Name;
        public int Level;
        public float Rarity = 100;
        public int Min = 1;
        public int Max = 1;

        public void Info(int index = 0)
        {
            Console.ForegroundColor = Table_Info.ParseColorConsole(this.Color);

            Trace.WriteLine(
                "\t" + index    + ". " +
                this.Color      + " " +
                this.ID         + " " +
                this.Name       + " " +
                this.Level
            );
        }

        public void getRarity()
        {
            if((int)Item_NPC_Parser.NPC_Grade > 1 || Table_Info.isChest(Item_NPC_Parser.NPC_name))
                this.Rarity = Config.getRarityByGroup_BOSS(this.Group);
            else
                this.Rarity = Config.getRarityByGroup(this.Group);

            this.Rarity = Config.Item_Check_Config(this.Name, this.Rarity);
        }

        public void getMinMax()
        {
            int[] minMax = Config.getMinMaxByName(this.Name, Item_NPC_Parser.NPC_level);
            this.Min = minMax[0];
            this.Max = minMax[1];
        }
    }
}