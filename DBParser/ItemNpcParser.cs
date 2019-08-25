using HtmlAgilityPack;
using System.IO;
using System.Threading;
using System;
using System.Diagnostics;
using Console = Colorful.Console;

using Iswenzz.AION.DBParser.Data;

namespace Iswenzz.AION.DBParser
{
    public class ItemNpcParser
    {
        public NpcEntry NPC { get; set; }
        public int ERROR { get; set; }

        public ItemNpcEntry[] Items { get; set; }

        public ItemNpcParser(NpcEntry npc)
        {
            NPC = npc;
            ParseItem();
        }

        private void ParseItem()
        {
            Program.PhantomNewTab(NPC.Url, 2);
            HtmlDocument doc = new HtmlDocument();

            // Get level and name of this npc
            try
            {
                if (string.IsNullOrEmpty(NPC.Name))
                    NPC.Name = TableUtility.ParseText<string>(Program.Driver.FindElementByXPath(
                        "/html/body/div[3]/div[1]/div[3]/div/div[1]/div/table/tbody/tr[2]/td/span/b").Text);
                NPC.Level = TableUtility.ParseText<int>(TableUtility.ParseLevel(
                    Program.Driver.FindElementByXPath("/html/body/div[3]/div[1]/div[3]/div" +
                    "/div[1]/div/table/tbody/tr[4]/td[2]").Text));
            }
            catch { NPC.Level = 0; }

            // Click on loot button
            try { Program.Driver.FindElementByXPath("//*[@href=\"#tabs-drop\"]").Click(); }
            catch { SetError(-1); return; }

            Thread.Sleep(500);

            int items_size = TableUtility.Count(Program.Driver, "//*[@id=\"npcDropTable_info\"]");
            if (items_size < 1) { SetError(-1); return; }
            Items = new ItemNpcEntry[items_size + 1]; // + 1 for kinah

            // Set the table size to 50
            Program.Driver.ExecuteScript("document.getElementsByTagName(\"option\")[1]" +
                ".setAttribute(\"value\",\"50\");");
            Program.Driver.FindElementByXPath("//*[@id=\"npcDropTable_length\"]/label/select").Click();
            Program.Driver.FindElementByXPath("//*[@id=\"npcDropTable_length\"]/label/select/option[2]").Click();
            // Click on Page 1
            Program.Driver.FindElementByXPath("//*[@id=\"npcDropTable_paginate\"]/ul/li[2]/a").Click();

            int file_index = 1;
            for (int item = 0; item < items_size;)
            {
                doc.LoadHtml(File.ReadAllText(Program.SaveHTML(file_index++.ToString())));
                HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id=\"npcDropTable\"]");
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

                        int id = TableUtility.ParseText<int>(doc.DocumentNode.SelectSingleNode(tableXPath 
                            + "/tbody/tr[" + (tr + 1) + "]/td[1]").InnerText);
                        string name = TableUtility.ParseText<string>(doc.DocumentNode.SelectSingleNode(tableXPath 
                            + "/tbody/tr[" + (tr + 1) + "]/td[3]/a/b").InnerText);
                        ItemQuality color = TableUtility.ParseColor(TableUtility.ParseText<ItemQuality>(
                            doc.DocumentNode.SelectSingleNode(tableXPath + "/tbody" 
                            + "/tr[" + (tr + 1) + "]/td[3]/a").GetAttributeValue("class", "")));
                        int level = TableUtility.ParseText<int>(doc.DocumentNode.SelectSingleNode(tableXPath 
                            + "/tbody/tr[" + (tr + 1) + "]/td[4]").InnerText);
                        string url = TableUtility.ParseUrl(TableUtility.ParseText<string>(
                            doc.DocumentNode.SelectSingleNode(tableXPath + "/tbody" 
                            + "/tr[" + (tr + 1) + "]/td[3]/a").GetAttributeValue("href", "")));
                        string icon = TableUtility.ParseText<string>(doc.DocumentNode.SelectSingleNode(tableXPath 
                            + "/tbody/tr[" + (tr + 1) + "]/td[2]/div/div/a/img")
                            .GetAttributeValue("src", ""));
                        string group = TableUtility.ParseGroup(color, icon);

                        Items[item] = new ItemNpcEntry();
                        Items[item].ID = id;
                        Items[item].Name = name;
                        Items[item].Color = color;
                        Items[item].Level = level;
                        Items[item].Url = url;
                        Items[item].Group = group;

                        Items[item].Info(item + 1);
                        Items[item].GetRarity(NPC.Grade, NPC.Name);
                        Items[item].GetMinMax(NPC.Level);
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
                Program.Driver.FindElementByXPath("//*[@id=\"npcDropTable_next\"]/a").Click();
            }

            try
            {
                int kinah = Items.Length - 1;

                Items[kinah] = new ItemNpcEntry();
                Items[kinah].ID = 182400001;
                Items[kinah].Name = "Kinah";
                Items[kinah].Color = ItemQuality.COMMON;
                Items[kinah].Level = 1;
                Items[kinah].Url = "http://aiondatabase.net/en/item/182400001/";
                Items[kinah].Group = "KINAH";

                Items[kinah].Info(kinah + 1);
                Items[kinah].GetRarity(NPC.Grade, NPC.Name);
                Items[kinah].GetMinMax(NPC.Level);
            }
            catch { }

            Program.PhantomCloseTab();
            Program.PhantomTab(1);
        }

        public void SetError(int error)
        {
            ERROR = error;
            Program.PhantomCloseTab();
            Program.PhantomTab(1);

            switch (error)
            {
                case -1:
                    Trace.WriteLine("\tNo items for this NPC!");
                    break;
            }
        }
    }
}