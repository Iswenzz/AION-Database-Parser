using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

using Iswenzz.AION.DBParser.Buttons;
using System.IO;

namespace Iswenzz.AION.DBParser
{
    public static class LoopedParsing
    {
        public static int StartAt()
        {
            int ret = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Start loop at index:\t\t\t{ENTER->0}");
                try { ret = int.Parse(Console.ReadLine()); break; }
                catch { Console.WriteLine("Wrong input."); Thread.Sleep(2000); }
            }
            return ret;
        }

        public static void LoopADB()
        {
            for (int i = StartAt(); i < ButtonTable.Zone.Length; i++)
            {
                try { ButtonTable.Zone[i].Execute(); }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Map {ButtonTable.Zone[i].Name.ToUpper()} crashed:\n{e.Message}");
                }
                finally
                {
                    Program.PhantomKillProcess();
                    Program.PhantomStart();
                    Thread.Sleep(2000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void LoopALDir()
        {
            // AL GAME SPAWN DIR
            string dir = "";
            Console.Clear();
            Console.WriteLine("Please select a AL-Game spawn directory (instances/npcs)");
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                Title = "Please select a AL-Game spawn directory (instances/npcs)",
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                dir = dialog.FileName;

            // STATIC DATA NPC TEMPALTE
            Console.Clear();
            Console.WriteLine("{OPTIONAL BETTER DROP RATES}\nPlease select NPC template from static_data/npcs");
            OpenFileDialog dialog2 = new OpenFileDialog
            {
                Filter = "XML|*.xml",
                Title = "Please select NPC template from static_data/npcs"
            };
            if (dialog2.ShowDialog() == DialogResult.OK)
                ALNpcSpawnParser.XNPCStaticData = dialog2.FileName;

            string[] files = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            for (int i = StartAt(); i < files.Length; i++)
            {
                try
                {
                    Console.Clear();
                    new ALNpcSpawnParser(Path.GetFileNameWithoutExtension(files[i]).ToUpper() + ".xml", files[i]);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Map {Path.GetFileNameWithoutExtension(files[i])} crashed:\n{e.Message}");
                }
                finally
                {
                    Program.PhantomKillProcess();
                    Program.PhantomStart();
                    Thread.Sleep(2000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void LoopTXT()
        {
            // TXT FILES DIR
            string dir = "";
            Console.Clear();
            Console.WriteLine("Please select a dir that contains txt id files");
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                Title = "Please select a dir that contains txt id files",
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                dir = dialog.FileName;

            // STATIC DATA NPC TEMPALTE
            Console.Clear();
            Console.WriteLine("{OPTIONAL BETTER DROP RATES}\nPlease select NPC template from static_data/npcs");
            OpenFileDialog dialog2 = new OpenFileDialog
            {
                Filter = "XML|*.xml",
                Title = "Please select NPC template from static_data/npcs"
            };
            if (dialog2.ShowDialog() == DialogResult.OK)
                TextNpcParser.XNPCStaticData = dialog2.FileName;

            string[] files = Directory.GetFiles(dir, "*.txt", SearchOption.AllDirectories);
            for (int i = StartAt(); i < files.Length; i++)
            {
                try
                {
                    Console.Clear();
                    new TextNpcParser(Path.GetFileNameWithoutExtension(files[i]).ToUpper() + ".xml", files[i]);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Map {Path.GetFileNameWithoutExtension(files[i])} crashed:\n{e.Message}");
                }
                finally
                {
                    Program.PhantomKillProcess();
                    Program.PhantomStart();
                    Thread.Sleep(2000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}
