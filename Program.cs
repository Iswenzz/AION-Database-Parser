using OpenQA.Selenium.PhantomJS;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

using Iswenzz.AION.DBParser.Buttons;

namespace Iswenzz.AION.DBParser
{
    public static class Program
    {
        public static PhantomJSDriver Driver { get; set; }
        public static PhantomJSDriverService DriverService { get; set; }

        public static void Main()
        {
            PhantomKillProcess();
            PhantomStart();

            int input = 0;
            bool stop = false;
            Button[] button = ButtonTable.Button;

            Console.Clear();
            Console.WriteLine("Iswenzz (c) 2018\n");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            try
            {
                while (!stop)
                {
                    int index = 0;
                    foreach (var selection in button)
                        Console.WriteLine((++index) + ". {0}" + selection.Name, selection.Stop ? "" : ">>");
                    Console.WriteLine("\nParse Number: ");

                    string input_key = Console.ReadLine();
                    int.TryParse(input_key, out int input_parsed);
                    input = --input_parsed;
                    Console.Clear();

                    try
                    {
                        if (input + 1 <= button.Length)
                        {
                            switch (button[input].Name)
                            {
                                case "NPC": button = ButtonTable.Npc; break;
                                case "Grade": button = ButtonTable.Grade; break;
                                case "Zone": button = ButtonTable.Zone; break;
                                default: stop = true; break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("\nWrong input.\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                button[input].Execute();
            }
            catch (Exception e) { Console.WriteLine("\n" + e + "\n"); Thread.Sleep(1000); Main(); }

            PhantomKillProcess();
            Console.WriteLine("\nDone!\nPress Any Key to Exit...");
            Console.ReadKey();
        }

        public static void PhantomStart()
        {
            DriverService = PhantomJSDriverService.CreateDefaultService();
            DriverService.HideCommandPromptWindow = true;
            Driver = new PhantomJSDriver(DriverService);
            Driver.Url = "http://aiondatabase.net/en/";
            Driver.Navigate();
        }

        public static void PhantomTab(int index)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[index]);
        }

        public static void PhantomNewTab(string url, int index)
        {
            Driver.ExecuteScript("$(window.open('" + url + "'))");
            Driver.SwitchTo().Window(Driver.WindowHandles[index]);
            Driver.Url = url;
            Driver.Navigate();
        }

        public static void PhantomCloseTab()
        {
            Driver.Close();
            // Use PhantomTab after
        }

        public static void PhantomKillProcess()
        {
            foreach (Process proc in Process.GetProcessesByName("phantomjs"))
                proc.Kill();
        }

        public static string GetLastDir(string url)
        {
            string last_dir = url.Remove(url.Length - 1);

            int to_sub = 0;
            while (last_dir[last_dir.Length - to_sub - 1] != '/')
                to_sub++;

            return last_dir.Substring(last_dir.Length - to_sub);
        }

        public static string LoadXML(string url, string url_name)
        {
            return AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + GetLastDir(url)
                + "_"
                + url_name
                + ".xml";
        }

        public static FileStream SaveXML(string url, string url_name)
        {
            string path = AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + GetLastDir(url)
                +"_"
                + url_name
                + ".xml";

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            return new FileStream(path, FileMode.Create);
        }

        public static FileStream SaveLog(string url)
        {
            string path = AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + "console"
                + ".log";

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            return new FileStream(path, FileMode.Create);
        }

        public static string SaveHTML(string add_string = "")
        {
            string HTML_path = AppContext.BaseDirectory
                + "aiondatabase/"
                + Driver.Url.Replace("http://aiondatabase.net/en/", "")
                + add_string
                + ".html";

            Directory.CreateDirectory(Path.GetDirectoryName(HTML_path));
            StreamWriter HTML_page_source = new StreamWriter(new FileStream(HTML_path, FileMode.Create));

            HTML_page_source.Write(Driver.PageSource);
            HTML_page_source.Close();
            HTML_page_source.Dispose();

            return HTML_path;
        }
    }
}