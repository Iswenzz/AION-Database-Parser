using HtmlAgilityPack;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Drawing;
using System.Threading;

using Iswenzz.AION.DBParser.Data;

namespace Iswenzz.AION.DBParser
{
    public static class TableUtility
    {
        public static NPCRace ParseRace(HtmlDocument doc, string xpath)
        {
            if (doc.DocumentNode.SelectSingleNode(xpath) == null)
                return NPCRace.BALAUR;

            if (doc.DocumentNode.SelectSingleNode(xpath).GetAttributeValue("class", "") == "race-light")
                return NPCRace.ELYOS;

            if (doc.DocumentNode.SelectSingleNode(xpath).GetAttributeValue("class", "") == "race-dark")
                return NPCRace.ASMO;

            return NPCRace.BALAUR;
        }

        public static ItemQuality ParseColor(string color)
        {
            ItemQuality newColor;

            switch (color)
            {
                case "qtooltip item_grade_0": newColor = ItemQuality.JUNK; break;
                case "qtooltip item_grade_1": newColor = ItemQuality.COMMON; break;
                case "qtooltip item_grade_2": newColor = ItemQuality.SUPERIOR; break;
                case "qtooltip item_grade_3": newColor = ItemQuality.HEROIC; break;
                case "qtooltip item_grade_4": newColor = ItemQuality.FABLED; break;
                case "qtooltip item_grade_5": newColor = ItemQuality.ETERNAL; break;
                case "qtooltip item_grade_6": newColor = ItemQuality.MYTHICAL; break;
                default: newColor = ItemQuality.JUNK; break;
            }

            return newColor;
        }

        public static NPCGrade ParseGrade(string grade)
        {
            NPCGrade newGrade;

            switch (grade)
            {
                case "Normal": newGrade = NPCGrade.NORMAL; break;
                case "Elite": newGrade = NPCGrade.ELITE; break;
                case "Heroic": newGrade = NPCGrade.HEROIC; break;
                case "Legendary": newGrade = NPCGrade.LEGENDARY; break;
                default: newGrade = NPCGrade.NORMAL; break;
            }

            return newGrade;
        }

        public static Color ParseColorConsole(ItemQuality color)
        {
            Color consoleColor;

            switch (color)
            {
                case ItemQuality.JUNK: consoleColor = Color.Gray; break;
                case ItemQuality.COMMON: consoleColor = Color.White; break;
                case ItemQuality.SUPERIOR: consoleColor = Color.FromArgb(42, 193, 94); break;
                case ItemQuality.HEROIC: consoleColor = Color.FromArgb(76, 207, 219); break;
                case ItemQuality.FABLED: consoleColor = Color.FromArgb(226, 183, 28); break;
                case ItemQuality.ETERNAL: consoleColor = Color.FromArgb(240, 128, 51); break;
                case ItemQuality.MYTHICAL: consoleColor = Color.FromArgb(126, 57, 192); break;
                default: consoleColor = Color.LightGray; break;
            }

            return consoleColor;
        }

        public static string ParseGroup(ItemQuality color, string icon)
        {
            string itemName = icon;

            switch (true)
            {
                /* KINAH */
                case true when itemName.Contains("item_qina"):
                    itemName = "KINAH";
                    break;

                /* ARMORS */
                case true when itemName.Contains("item_ch_torso"):
                case true when itemName.Contains("item_ch_pants"):
                case true when itemName.Contains("item_ch_shoulder"):
                case true when itemName.Contains("item_ch_glove"):
                case true when itemName.Contains("item_ch_shoes"):
                case true when itemName.Contains("item_lt_torso"):
                case true when itemName.Contains("item_lt_pants"):
                case true when itemName.Contains("item_lt_shoulder"):
                case true when itemName.Contains("item_lt_glove"):
                case true when itemName.Contains("item_lt_shoes"):
                case true when itemName.Contains("item_pl_torso"):
                case true when itemName.Contains("item_pl_pants"):
                case true when itemName.Contains("item_pl_shoulder"):
                case true when itemName.Contains("item_pl_glove"):
                case true when itemName.Contains("item_pl_shoes"):
                case true when itemName.Contains("item_rb_torso"):
                case true when itemName.Contains("item_rb_pants"):
                case true when itemName.Contains("item_rb_shoulder"):
                case true when itemName.Contains("item_rb_glove"):
                case true when itemName.Contains("item_rb_shoes"):
                    itemName = "ARMOR";
                    break;

                /* WEAPONS */
                case true when itemName.Contains("item_2hsword"):
                case true when itemName.Contains("item_book"):
                case true when itemName.Contains("item_bow"):
                case true when itemName.Contains("item_dagger"):
                case true when itemName.Contains("item_cannon"):
                case true when itemName.Contains("item_gun"):
                case true when itemName.Contains("item_harp"):
                case true when itemName.Contains("item_keyblade"):
                case true when itemName.Contains("item_mace"):
                case true when itemName.Contains("item_orb"):
                case true when itemName.Contains("item_polearm"):
                case true when itemName.Contains("item_shield"):
                case true when itemName.Contains("item_staff"):
                case true when itemName.Contains("item_sword"):
                    itemName = "WEAPON";
                    break;

                /* ACCESSORY */
                case true when itemName.Contains("item_ac_head"):
                case true when itemName.Contains("item_ch_head"):
                case true when itemName.Contains("item_rb_head"):
                case true when itemName.Contains("item_pl_head"):
                case true when itemName.Contains("item_lt_head"):
                case true when itemName.Contains("item_belt"):
                case true when itemName.Contains("item_ring"):
                case true when itemName.Contains("item_necklace"):
                case true when itemName.Contains("item_feather"):
                case true when itemName.Contains("item_earring"):
                case true when itemName.Contains("item_tshirt"):
                case true when itemName.Contains("item_bracelet"):
                    itemName = "ACCESSORY";
                    break;

                /* CONSUMABLE */
                case true when itemName.Contains("item_potion"): itemName = "POTION"; break;
                case true when itemName.Contains("item_dish"): itemName = "FOOD"; break;
                case true when itemName.Contains("item_scroll"): itemName = "SCROLL"; break;
                case true when itemName.Contains("item_estima_enchant"): itemName = "ESTIMA_ENCHANT"; break;
                case true when itemName.Contains("item_enchant"): itemName = "ENCHANT"; break;
                case true when itemName.Contains("item_2stenchant"): itemName = "ENCHANT"; break;
                case true when itemName.Contains("item_polish"): itemName = "IDIAN"; break;
                case true when itemName.Contains("magicstone"): itemName = "MANASTONE"; break;
                case true when itemName.Contains("holystone"): itemName = "GODSTONE"; break;
                case true when itemName.Contains("item_sack"): itemName = "BAG"; break;

                /* CRAFTING */
                case true when itemName.Contains("crystalball"):
                    itemName = "FLUX";
                    break;
                case true when itemName.Contains("item_dragonhorn"):
                case true when itemName.Contains("item_dragonscale"):
                case true when itemName.Contains("item_dragonhide"):
                case true when itemName.Contains("item_mucus"):
                case true when itemName.Contains("item_heart"):
                    itemName = "CRAFTING";
                    break;
            }

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
            while (char.IsDigit(newInfo[newInfo.IndexOf(':') + 2 + i]))
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

        public static bool IsChest(string npc_name)
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
            while (char.IsNumber(str[str.Length - to_sub - 1]))
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
                    if (string.IsNullOrEmpty(Program.Driver.FindElementByXPath(xpath).Text))
                        Thread.Sleep(500);
                }
                catch { Thread.Sleep(500); }
                loop++;
            }
        }
    }
}