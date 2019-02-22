using System;

namespace Iswenzz.AION.DBParser
{
    public static class Config
    {
        /**
         * Custom config item drop 
         * @name 
         * @min 
         * @max 
         * @chance
         */
        public static Item_Config[] items = new Item_Config[]
        {
            // Shard
            new Item_Config("Power Shard: Weapon Attack +10", 1, 294, 25.0f),
            new Item_Config("Power Shard: Weapon Attack +100", 1, 294, 25.0f),
            new Item_Config("Power Shard: +10", 1, 294, 25.0f),
            new Item_Config("Lesser Power Shard", 1, 294, 25.0f),
            new Item_Config("Power Shard: +20", 1, 294, 25.0f),
            new Item_Config("Duaguru Power Shard", 1, 294, 25.0f),
            new Item_Config("Greater Power Shard", 1, 294, 25.0f),
            new Item_Config("Power Shard: +30", 1, 294, 25.0f),
            new Item_Config("Premium Power Shard", 1, 294, 25.0f),
            new Item_Config("Power Shard: +40", 1, 294, 25.0f),
            new Item_Config("Power Shard: +50", 1, 294, 25.0f),
            new Item_Config("Power Shard of Honour: +40", 1, 294, 25.0f),
            new Item_Config("[Legion Reward] Power Shard: +20", 1, 294, 25.0f),
            new Item_Config("[Jakunerk] Power Shard: +20", 1, 294, 25.0f),
            new Item_Config("Stigma Shard", 1, 294, 25.0f),
            // Esterra & Nosra Crafting Items
            new Item_Config("Red Natural Magic Stone", 1, 5, 25.0f),
            new Item_Config("Blue Natural Magic Stone", 1, 5, 25.0f),
            new Item_Config("Green Natural Magic Stone", 1, 5, 25.0f),
            new Item_Config("Violet Natural Magic Stone", 1, 5, 25.0f),
            new Item_Config("Holy Balaur Flesh", 1, 5, 10.0f),
            new Item_Config("Blue Natural Gemstone", 1, 5, 3.0f),
            new Item_Config("Red Natural Gemstone", 1, 5, 3.0f),
            new Item_Config("Green Natural Gemstone", 1, 5, 3.0f),
            new Item_Config("Violet Natural Gemstone", 1, 5, 3.0f),
            new Item_Config("Blue Droplet", 1, 5, 3.0f),
            new Item_Config("Green Droplet", 1, 5, 3.0f),
            new Item_Config("Violet Droplet", 1, 5, 3.0f),
            new Item_Config("Red Droplet", 1, 5, 3.0f),
            new Item_Config("Edible Fruit", 1, 5, 50.0f),
            new Item_Config("Edible Meat", 1, 5, 50.0f),
            new Item_Config("Spirit Stone of Darkness", 1, 5, 50.0f),
            new Item_Config("Natural Energy", 1, 5, 50.0f),
            new Item_Config("Natural Essence", 1, 5, 50.0f),
            new Item_Config("Spirit Stone of Light", 1, 5, 50.0f),
            new Item_Config("Spirit Stone of Eternity", 1, 5, 50.0f),
        };

        public static float Item_Check_Config(string item_name, float item_rarity)
        {
            bool has_config = false;

            // Check if this item have a config
            foreach (Item_Config item in items)
            {
                if (item.Name == item_name)
                {
                    has_config = true;
                    break;
                }
            }

            // Return default RNG if not 
            if (!has_config)
                return item_rarity;

            foreach (Item_Config item in items)
            {
                if (item.Name == item_name)
                {
                    return item.Rarity;
                }
            }

            return 0f;
        }

        public static int[] getMinMaxByName(string item_name, int npc_level)
        {
            bool has_config = false;
            int[] minMax = new int[2] { 1, 1 };

            // Check if this item have a config
            foreach (Item_Config item in items)
            {
                if (item.Name == item_name)
                {
                    has_config = true;
                    break;
                }
            }

            if (item_name == "Kinah")
                return getKinahByLevel(npc_level);

            // Return default if not 
            if (!has_config)
                return minMax;

            foreach (Item_Config item in items)
            {
                if (item.Name == item_name)
                {
                    minMax[0] = item.Min;
                    minMax[1] = item.Max;
                    return minMax;
                }
            }

            return minMax;
        }

        public static int[] getKinahByLevel(int level = 0)
        {
            int[] minMax = new int[2] { 1, 1 };

            if (level == 0) { minMax[0] = 60 * 250; minMax[1] = 60 * 320; }
            else if (level <= 10) { minMax[0] = level * 20; minMax[1] = level * 90; }
            else if (level <= 20) { minMax[0] = level * 90; minMax[1] = level * 120; }
            else if (level <= 30) { minMax[0] = level * 60; minMax[1] = level * 75; }
            else if (level <= 40) { minMax[0] = level * 75; minMax[1] = level * 125; }
            else if (level <= 50) { minMax[0] = level * 125; minMax[1] = level * 250; }
            else if (level <= 60) { minMax[0] = level * 250; minMax[1] = level * 320; }
            else if (level <= 70) { minMax[0] = level * 290; minMax[1] = level * 370; }
            else if (level <= 80) { minMax[0] = level * 350; minMax[1] = level * 410; }

            return minMax;
        }

        public class Item_Config
        {
            public string Name;
            public int Min = 1;
            public int Max;
            public float Rarity;

            public Item_Config(string name, int min, int max, float rarity)
            {
                this.Name = name;
                this.Max = min;
                this.Max = max;
                this.Rarity = rarity;
            }
        }

        public static float getRarityByGroup(string group)
        {
            float newFloat;

            switch (group)
            {
                case "KINAH": newFloat = 50.0f; break;

                case "COMMON_ARMOR": newFloat = 0.96f; break;
                case "SUPERIOR_ARMOR": newFloat = 0.48f; break;
                case "HEROIC_ARMOR": newFloat = 0.15f; break;
                case "FABLED_ARMOR": newFloat = 0.06f; break;
                case "ETERNAL_ARMOR": newFloat = 0.04f; break;
                case "MYTHICAL_ARMOR": newFloat = 0.03f; break;

                case "COMMON_WEAPON": newFloat = 0.96f; break;
                case "SUPERIOR_WEAPON": newFloat = 0.48f; break;
                case "HEROIC_WEAPON": newFloat = 0.15f; break;
                case "FABLED_WEAPON": newFloat = 0.06f; break;
                case "ETERNAL_WEAPON": newFloat = 0.04f; break;
                case "MYTHICAL_WEAPON": newFloat = 0.03f; break;

                case "COMMON_ACCESSORY": newFloat = 0.96f; break;
                case "SUPERIOR_ACCESSORY": newFloat = 0.48f; break;
                case "HEROIC_ACCESSORY": newFloat = 0.15f; break;
                case "FABLED_ACCESSORY": newFloat = 0.06f; break;
                case "ETERNAL_ACCESSORY": newFloat = 0.04f; break;
                case "MYTHICAL_ACCESSORY": newFloat = 0.015f; break;

                case "POTION": newFloat = 1.5f; break;
                case "FOOD": newFloat = 1.5f; break;
                case "SCROLL": newFloat = 1.5f; break;
                case "ESTIMAENCHANT": newFloat = 3.0f; break;
                case "ENCHANT": newFloat = 0.015f; break;
                case "IDIAN": newFloat = 1.0f; break;
                case "MANASTONE": newFloat = 0.3f; break;
                case "GODSTONE": newFloat = 0.01f; break;
                case "BAG": newFloat = 0.25f; break;

                case "FLUX": newFloat = 5.0f; break;
                case "CRAFTING": newFloat = 50.0f; break;

                case "JUNK": newFloat = 100.0f; break;
                case "COMMON": newFloat = 50.0f; break;
                case "SUPERIOR": newFloat = 8.0f; break;
                case "HEROIC": newFloat = 3.0f; break;
                case "FABLED": newFloat = 0.06f; break;
                case "ETERNAL": newFloat = 0.04f; break;
                case "MYTHICAL": newFloat = 0.03f; break;
                default: newFloat = 0f; break;
            }

            return newFloat;
        }

        public static float getRarityByGroup_BOSS(string group)
        {
            float newFloat;

            switch (group)
            {
                case "KINAH": newFloat = 50.0f; break;

                case "COMMON_ARMOR": newFloat = 25.0f; break;
                case "SUPERIOR_ARMOR": newFloat = 20.0f; break;
                case "HEROIC_ARMOR": newFloat = 15.0f; break;
                case "FABLED_ARMOR": newFloat = 10.0f; break;
                case "ETERNAL_ARMOR": newFloat = 5.0f; break;
                case "MYTHICAL_ARMOR": newFloat = 5.0f; break;

                case "COMMON_WEAPON": newFloat = 25.0f; break;
                case "SUPERIOR_WEAPON": newFloat = 15.0f; break;
                case "HEROIC_WEAPON": newFloat = 10.0f; break;
                case "FABLED_WEAPON": newFloat = 5.0f; break;
                case "ETERNAL_WEAPON": newFloat = 3.0f; break;
                case "MYTHICAL_WEAPON": newFloat = 3.0f; break;

                case "COMMON_ACCESSORY": newFloat = 25.0f; break;
                case "SUPERIOR_ACCESSORY": newFloat = 20.0f; break;
                case "HEROIC_ACCESSORY": newFloat = 15.0f; break;
                case "FABLED_ACCESSORY": newFloat = 12.0f; break;
                case "ETERNAL_ACCESSORY": newFloat = 7.0f; break;
                case "MYTHICAL_ACCESSORY": newFloat = 7.0f; break;

                case "POTION": newFloat = 25.0f; break;
                case "FOOD": newFloat = 25.0f; break;
                case "SCROLL": newFloat = 25.0f; break;
                case "ESTIMA_ENCHANT": newFloat = 30.0f; break;
                case "ENCHANT": newFloat = 10.0f; break;
                case "IDIAN": newFloat = 10.0f; break;
                case "MANASTONE": newFloat = 10.0f; break;
                case "GODSTONE": newFloat = 0.5f; break;
                case "BAG": newFloat = 25.0f; break;

                case "FLUX": newFloat = 75.0f; break;
                case "CRAFTING": newFloat = 100.0f; break;

                case "JUNK": newFloat = 100.0f; break;
                case "COMMON": newFloat = 85.0f; break;
                case "SUPERIOR": newFloat = 60.0f; break;
                case "HEROIC": newFloat = 45.0f; break;
                case "FABLED": newFloat = 35.00f; break;
                case "ETERNAL": newFloat = 25.00f; break;
                case "MYTHICAL": newFloat = 15.00f; break;
                default: newFloat = 0f; break;
            }

            return newFloat;
        }
    }
}