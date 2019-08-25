using System.Diagnostics;
using Console = Colorful.Console;

namespace Iswenzz.AION.DBParser.Data
{
    public class ItemNpcEntry
    {
        public string Url;

        public ItemQuality Color;
        public string Group;
        public int ID;
        public string Name;
        public int Level;
        public float Rarity = 100;
        public int Min = 1;
        public int Max = 1;

        public void Info(int index = 0)
        {
            Console.ForegroundColor = TableUtility.ParseColorConsole(Color);
            Trace.WriteLine($"\t{index}. {Color} {ID} {Name} {Level}");
            Console.ForegroundColor = System.Drawing.Color.LightGray;
        }

        public void GetRarity(NPCGrade grade, string name)
        {
            if ((int)grade > 1 || TableUtility.IsChest(name))
                Rarity = Config.getRarityByGroup_BOSS(Group);
            else
                Rarity = Config.getRarityByGroup(Group);

            Rarity = Config.Item_Check_Config(Name, Rarity);
        }

        public void GetMinMax(int level)
        {
            int[] minMax = Config.getMinMaxByName(Name, level);
            Min = minMax[0];
            Max = minMax[1];
        }
    }
}
