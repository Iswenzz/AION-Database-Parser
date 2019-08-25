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
        public static void LoopADB()
        {
            foreach (ButtonNpcZone button in ButtonTable.Zone)
            {
                try { button.Execute(); }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Map {button.Name.ToUpper()} crashed:\n{e.Message}");
                }
                finally
                {
                    Thread.Sleep(2000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void LoopALDir()
        {
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

            foreach (string file in Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories))
            {
                try
                {
                    Console.Clear();
                    new ALNpcSpawnParser(Path.GetFileNameWithoutExtension(file).ToUpper() + ".xml", file);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Map {Path.GetFileNameWithoutExtension(file)} crashed:\n{e.Message}");
                }
                finally
                {
                    Thread.Sleep(2000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void LoopTXT()
        {
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

            foreach (string file in Directory.GetFiles(dir, "*.txt", SearchOption.AllDirectories))
            {
                try
                {
                    Console.Clear();
                    new TextNpcParser(Path.GetFileNameWithoutExtension(file).ToUpper() + ".xml", file);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Map {Path.GetFileNameWithoutExtension(file)} crashed:\n{e.Message}");
                }
                finally
                {
                    Thread.Sleep(2000);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}
