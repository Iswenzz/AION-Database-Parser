using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace Iswenzz.AION.DBParser.Data
{
    public class NpcEntry
    {
        public string Url;

        public NPCRace Race;
        public int ID;
        public NPCGrade Grade;
        public int Level;
        public string Name;
        public int HP;

        public void Info(int index = 0)
        {
            Trace.WriteLine($"\n{index}. {Race} {ID} {Grade} {Name}\n");
        }

        public void GetDrop(string url)
        {
            ItemNpcParser npc = new ItemNpcParser(this);
            if (npc.ERROR == -1) return;
            XDocument xml = XDocument.Load(url);
            List<string> group = new List<string>();
            Dictionary<string, XElement> group_element = new Dictionary<string, XElement>();

            // Add this NPC to root
            XElement this_npc = new XElement("npc_drop", new XAttribute("npc_id", ID),
                new XAttribute("npc_name", Name));

            // Create child node for each item group of this NPC
            foreach (ItemNpcEntry item_group in npc.Items)
            {
                if (item_group == null) continue;

                if (!group.Contains(item_group.Group))
                {
                    group.Add(item_group.Group);

                    XElement elem = new XElement("drop_group", new XAttribute("name", item_group.Group),
                        new XAttribute("use_category", "true"), new XAttribute("race", "PC_ALL"));

                    group_element.Add(item_group.Group, elem);
                    this_npc.Add(elem);
                }
            }

            // Add each item to there own child node group
            foreach (ItemNpcEntry item in npc.Items)
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
            using (FileStream stream = new FileStream(url, FileMode.Create))
                xml.Save(stream);
        }
    }
}
