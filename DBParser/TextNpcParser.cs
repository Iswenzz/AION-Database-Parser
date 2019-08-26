using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

using Iswenzz.AION.DBParser.Data;

namespace Iswenzz.AION.DBParser
{
    public class TextNpcParser
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public TextNpcParser(string name, string path)
        {
            Console.ForegroundColor = Color.LightGray;

            FileName = name;
            FilePath = path;

            if (string.IsNullOrEmpty(FilePath))
                return;

            Log.Config(new FileStream("./alparse/npc_drop/" 
                + Path.GetFileNameWithoutExtension(FilePath) + ".log", FileMode.Create));
            Trace.WriteLine("Loading " + FileName + ":\n\n" + FilePath + "\n");

            CreateXML();
            ParseNPC();
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

            Directory.CreateDirectory(Path.GetDirectoryName("./alparse/npc_drop/"));
            using (FileStream stream = new FileStream("./alparse/npc_drop/" + FileName, FileMode.Create))
                xml.Save(stream);
        }

        private void ParseNPC()
        {
            Program.PhantomNewTab("http://aiondatabase.net/en/", 1);

            List<string> npcs_id = File.ReadAllText(FilePath).Split('\n')
                .Select(s => s.Trim()).ToList();
            List<string> alreadyParsedID = new List<string>();

            Stopwatch timer = new Stopwatch();
            timer.Start();

            int index = 1;
            foreach (string id in npcs_id)
            {
                if (!alreadyParsedID.Contains(id))
                {
                    alreadyParsedID.Add(id);
                    NpcEntry npc = new NpcEntry();
                    npc.Url = $"http://aiondatabase.net/en/npc/{id}/";
                    npc.ID = int.Parse(id);
                    Trace.WriteLine($"\n{index}. {npc.ID}\n");
                    npc.GetDrop("./alparse/npc_drop/" + FileName);
                    index++;
                }
            }

            timer.Stop();
            Trace.WriteLine("\nParsed " + FileName + " in " + timer.Elapsed.ToString("hh\\:mm\\.ss"));
        }

        public static TextNpcParser InitFromConsole()
        {
            string name = "";
            string path = "";

            Console.Clear();
            Console.WriteLine("Please select a TXT file that contains NPC ID on each line: ");

            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "TXT|*.txt",
                Title = "TXT NPC ID"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("\n" + dialog.FileName);
                path = dialog.FileName;
                name = Path.GetFileNameWithoutExtension(path).ToUpper() + ".xml";
            }
            Thread.Sleep(1000);
            Console.Clear();
            return new TextNpcParser(name, path);
        }
    }
}
