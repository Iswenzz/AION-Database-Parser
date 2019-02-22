using HtmlAgilityPack;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Drawing;
using System.Threading;

namespace Iswenzz.AION.DBParser
{
    public static class Table_Info
    {
        public enum NPC_Race
        {
            ELYOS,
            ASMO,
            BALAUR
        }

        public enum NPC_Grade
        {
            NORMAL,
            ELITE,
            HEROIC,
            LEGENDARY
        }

        public enum Item_Quality
        {
            JUNK,
            COMMON,
            SUPERIOR,
            HEROIC,
            FABLED,
            ETERNAL,
            MYTHICAL
        }

        public static NPC_Race ParseRace(HtmlDocument doc, string xpath)
        {
            if (doc.DocumentNode.SelectSingleNode(xpath) == null)
                return NPC_Race.BALAUR;

            if (doc.DocumentNode.SelectSingleNode(xpath).GetAttributeValue("class", "") == "race-light")
                return NPC_Race.ELYOS;

            if (doc.DocumentNode.SelectSingleNode(xpath).GetAttributeValue("class", "") == "race-dark")
                return NPC_Race.ASMO;

            return NPC_Race.BALAUR;
        }

        public static Item_Quality ParseColor(string color)
        {
            Item_Quality newColor;

            switch (color)
            {
                case "qtooltip item_grade_0": newColor = Item_Quality.JUNK; break;
                case "qtooltip item_grade_1": newColor = Item_Quality.COMMON; break;
                case "qtooltip item_grade_2": newColor = Item_Quality.SUPERIOR; break;
                case "qtooltip item_grade_3": newColor = Item_Quality.HEROIC; break;
                case "qtooltip item_grade_4": newColor = Item_Quality.FABLED; break;
                case "qtooltip item_grade_5": newColor = Item_Quality.ETERNAL; break;
                case "qtooltip item_grade_6": newColor = Item_Quality.MYTHICAL; break;
                default: newColor = Item_Quality.JUNK; break;
            }

            return newColor;
        }

        public static NPC_Grade ParseGrade(string grade)
        {
            NPC_Grade newGrade;

            switch (grade)
            {
                case "Normal": newGrade = NPC_Grade.NORMAL; break;
                case "Elite": newGrade = NPC_Grade.ELITE; break;
                case "Heroic": newGrade = NPC_Grade.HEROIC; break;
                case "Legendary": newGrade = NPC_Grade.LEGENDARY; break;
                default: newGrade = NPC_Grade.NORMAL; break;
            }

            return newGrade;
        }

        public static Color ParseColorConsole(Item_Quality color)
        {
            Color consoleColor;

            switch (color)
            {
                case Item_Quality.JUNK: consoleColor = Color.Gray; break;
                case Item_Quality.COMMON: consoleColor = Color.White; break;
                case Item_Quality.SUPERIOR: consoleColor = Color.FromArgb(42, 193, 94); break;
                case Item_Quality.HEROIC: consoleColor = Color.FromArgb(76, 207, 219); break;
                case Item_Quality.FABLED: consoleColor = Color.FromArgb(226, 183, 28); break;
                case Item_Quality.ETERNAL: consoleColor = Color.FromArgb(240, 128, 51); break;
                case Item_Quality.MYTHICAL: consoleColor = Color.FromArgb(126, 57, 192); break;
                default: consoleColor = Color.LightGray; break;
            }

            return consoleColor;
        }

        public static string ParseGroup(Item_Quality color, string icon)
        {
            string itemName = icon;

            /* KINAH */
            if (itemName.Contains("item_qina")) itemName = "KINAH";

            /* ARMOR */
            else if (itemName.Contains("item_ch_torso")) itemName = "ARMOR";
            else if (itemName.Contains("item_ch_pants")) itemName = "ARMOR";
            else if (itemName.Contains("item_ch_shoulder")) itemName = "ARMOR";
            else if (itemName.Contains("item_ch_glove")) itemName = "ARMOR";
            else if (itemName.Contains("item_ch_shoes")) itemName = "ARMOR";
            else if (itemName.Contains("item_lt_torso")) itemName = "ARMOR";
            else if (itemName.Contains("item_lt_pants")) itemName = "ARMOR";
            else if (itemName.Contains("item_lt_shoulder")) itemName = "ARMOR";
            else if (itemName.Contains("item_lt_glove")) itemName = "ARMOR";
            else if (itemName.Contains("item_lt_shoes")) itemName = "ARMOR";
            else if (itemName.Contains("item_pl_torso")) itemName = "ARMOR";
            else if (itemName.Contains("item_pl_pants")) itemName = "ARMOR";
            else if (itemName.Contains("item_pl_shoulder")) itemName = "ARMOR";
            else if (itemName.Contains("item_pl_glove")) itemName = "ARMOR";
            else if (itemName.Contains("item_pl_shoes")) itemName = "ARMOR";
            else if (itemName.Contains("item_rb_torso")) itemName = "ARMOR";
            else if (itemName.Contains("item_rb_pants")) itemName = "ARMOR";
            else if (itemName.Contains("item_rb_shoulder")) itemName = "ARMOR";
            else if (itemName.Contains("item_rb_glove")) itemName = "ARMOR";
            else if (itemName.Contains("item_rb_shoes")) itemName = "ARMOR";

            /* WEAPONS */
            else if (itemName.Contains("item_2hsword")) itemName = "WEAPON";
            else if (itemName.Contains("item_book")) itemName = "WEAPON";
            else if (itemName.Contains("item_bow")) itemName = "WEAPON";
            else if (itemName.Contains("item_dagger")) itemName = "WEAPON";
            else if (itemName.Contains("item_cannon")) itemName = "WEAPON";
            else if (itemName.Contains("item_gun")) itemName = "WEAPON";
            else if (itemName.Contains("item_harp")) itemName = "WEAPON";
            else if (itemName.Contains("item_keyblade")) itemName = "WEAPON";
            else if (itemName.Contains("item_mace")) itemName = "WEAPON";
            else if (itemName.Contains("item_orb")) itemName = "WEAPON";
            else if (itemName.Contains("item_polearm")) itemName = "WEAPON";
            else if (itemName.Contains("item_shield")) itemName = "WEAPON";
            else if (itemName.Contains("item_staff")) itemName = "WEAPON";
            else if (itemName.Contains("item_sword")) itemName = "WEAPON";

            /* ACCESSORY */
            else if (itemName.Contains("item_ac_head")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_ch_head")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_rb_head")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_pl_head")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_lt_head")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_belt")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_ring")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_necklace")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_feather")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_earring")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_tshirt")) itemName = "ACCESSORY";
            else if (itemName.Contains("item_bracelet")) itemName = "ACCESSORY";

            /* CONSUMABLE */
            else if (itemName.Contains("item_potion")) itemName = "POTION";
            else if (itemName.Contains("item_dish")) itemName = "FOOD";
            else if (itemName.Contains("item_scroll")) itemName = "SCROLL";
            else if (itemName.Contains("item_estima_enchant")) itemName = "ESTIMA_ENCHANT";
            else if (itemName.Contains("item_enchant")) itemName = "ENCHANT";
            else if (itemName.Contains("item_2stenchant")) itemName = "ENCHANT";
            else if (itemName.Contains("item_polish")) itemName = "IDIAN";
            else if (itemName.Contains("magicstone")) itemName = "MANASTONE";
            else if (itemName.Contains("holystone")) itemName = "GODSTONE";
            else if (itemName.Contains("item_sack")) itemName = "BAG";

            /* CRAFTING */
            else if (itemName.Contains("crystalball")) itemName = "FLUX";
            else if (itemName.Contains("item_dragonhorn")) itemName = "CRAFTING";
            else if (itemName.Contains("item_dragonscale")) itemName = "CRAFTING";
            else if (itemName.Contains("item_dragonhide")) itemName = "CRAFTING";
            else if (itemName.Contains("item_mucus")) itemName = "CRAFTING";
            else if (itemName.Contains("item_heart")) itemName = "CRAFTING";

            // If this item doesn't have any group defined, group it by color quality
            if (itemName == icon)
                return color.ToString();

            if (itemName == "ARMOR" || itemName == "WEAPON" || itemName == "ACCESSORY")
                return color + "_" + itemName;
            return itemName;
        }

        public static string ParseUrl(string url)
        {
            return url.Replace("http://aiondatabase.net", "")
                .Insert(0, "http://aiondatabase.net");
        }

        public static string ParseLevel(string info)
        {
            string newInfo = info;

            if (!newInfo.Contains("Lv.: "))
                return "0";

            int i = 0;
            while (Char.IsDigit(newInfo[newInfo.IndexOf(':') + 2 + i]))
                i++;

            switch (i)
            {
                case 0: newInfo = "0"; break;
                case 1: newInfo = newInfo[newInfo.IndexOf(':') + 1 + 1].ToString(); break;
                case 2: newInfo = newInfo[newInfo.IndexOf(':') + 1 + 1].ToString() + newInfo[newInfo.IndexOf(':') + 1 + 2].ToString(); break;
                default: newInfo = "0"; break;
            }

            return newInfo;
        }

        public static dynamic ParseText<T>(string str)
        {
            dynamic v;

            if (string.IsNullOrEmpty(str))
            {
                switch (typeof(T).ToString())
                {
                    case "System.Int32": v = 1; break;
                    case "System.String": v = "Missing Info"; break;
                    case "System.Single": v = 0.00f; break;
                    case "Table_Info+Item_Quality": v = "qtooltip item_grade_1"; break;
                    case "Table_Info+NPC_Grade": v = "Normal"; break;
                    case "Table_Info+NPC_Race": v = null; break;
                    default: v = "Missing Info"; break;
                }
                return v;
            }

            if (str.Contains("Icy "))
            {
                v = str.Replace("Icy ", "");
                return v;
            }

            if (int.TryParse(str, out int n))
                return int.Parse(str);
            else
                return str;
        }

        public static bool isChest(string npc_name)
        {
            if (npc_name.Contains("Box")) return true;
            if (npc_name.Contains("Crate")) return true;
            if (npc_name.Contains("Chest")) return true;
            if (npc_name.Contains("Beritra's Claw")) return true;

            return false;
        }

        public static int Count(PhantomJSDriver driver, string xpath)
        {
            string str = driver.FindElementByXPath(xpath).Text
                .Replace(",", "")
                .Replace(" entries", "");

            int to_sub = 0;
            while (Char.IsNumber(str[str.Length - to_sub - 1]))
                to_sub++;

            return int.Parse(str.Substring(str.Length - to_sub));
        }

        public static void Loading(string xpath)
        {
            int loop = 0;

            while (true)
            {
                try
                {
                    if (loop == 10)
                    {
                        Console.WriteLine("\nNo data available in table.");
                        Thread.Sleep(2000);
                        Environment.Exit(-1);
                    }
                    if (string.IsNullOrEmpty(Program.driver.FindElementByXPath(xpath).Text))
                        Thread.Sleep(500);
                }
                catch { Thread.Sleep(500); }
                loop++;
            }
        }
    }
}