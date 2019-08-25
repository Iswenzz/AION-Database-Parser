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

        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Starting PhantomJS..");
            PhantomKillProcess();
            PhantomStart();

            int inputIndex = 0;
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
                        Console.WriteLine((++index) + ". {0}" + selection.Name, selection.Stop ? "" : "> ");
                    Console.WriteLine("\nParse Number: ");

                    string input_key = Console.ReadLine();
                    int.TryParse(input_key, out int input_parsed);
                    inputIndex = --input_parsed;
                    Console.Clear();

                    try
                    {
                        if (inputIndex + 1 <= button.Length)
                        {
                            switch (button[inputIndex].Name)
                            {
                                case "Aiondatabase.net": button = ButtonTable.Asset; break;
                                case "From AL-Server": ALNpcSpawnParser.InitFromConsole(); stop = true; break;
                                case "From TXT": TextNpcParser.InitFromConsole(); stop = true; break;

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
                button[inputIndex].Execute();
            }
            catch (Exception e) { Console.WriteLine($"\n{e}\n"); Thread.Sleep(1000); Main(); }

            PhantomKillProcess();
            Console.WriteLine("\nDone!\nPress Any Key to Exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Start PhantomJS on aiondatabase website.
        /// </summary>
        public static void PhantomStart()
        {
            try
            {
                DriverService = PhantomJSDriverService.CreateDefaultService();
                DriverService.HideCommandPromptWindow = true;
                Driver = new PhantomJSDriver(DriverService);
                Driver.Url = "http://aiondatabase.net/en/";
                Driver.Navigate();
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "The path is not of a legal form.":
                        Console.WriteLine("\nMissing WebDriver.dll\n");
                        Console.ReadKey();
                        Environment.Exit(-1);
                        break;
                    default:
                        Main();
                        break;
                }
            }
        }

        /// <summary>
        /// Select browser tab by index.
        /// </summary>
        /// <param name="index">Tab index</param>
        public static void PhantomTab(int index) =>
            Driver.SwitchTo().Window(Driver.WindowHandles[index]);

        /// <summary>
        /// Create a new browser tab.
        /// </summary>
        /// <param name="url">Start URL</param>
        /// <param name="index">Tab index</param>
        public static void PhantomNewTab(string url, int index)
        {
            Driver.ExecuteScript("$(window.open('" + url + "'))");
            Driver.SwitchTo().Window(Driver.WindowHandles[index]);
            Driver.Url = url;
            Driver.Navigate();
        }

        /// <summary>
        /// Close the current tab.
        /// </summary>
        public static void PhantomCloseTab() => Driver.Close();

        public static void PhantomKillProcess()
        {
            foreach (Process proc in Process.GetProcessesByName("phantomjs"))
                proc.Kill();
        }

        /// <summary>
        /// Get last URL Directory
        /// </summary>
        /// <param name="url">URL string</param>
        /// <returns></returns>
        public static string GetLastDir(string url)
        {
            string last_dir = url.Remove(url.Length - 1);

            int to_sub = 0;
            while (last_dir[last_dir.Length - to_sub - 1] != '/')
                to_sub++;

            return last_dir.Substring(last_dir.Length - to_sub);
        }

        /// <summary>
        /// Load XML file from aiondatabase url
        /// </summary>
        /// <param name="url">URL string</param>
        /// <param name="url_name">File name</param>
        /// <returns></returns>
        public static string LoadADBXName(string url, string url_name)
        {
            return AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + GetLastDir(url)
                + "_"
                + url_name
                + ".xml";
        }

        /// <summary>
        /// Save XML file from aiondatabase URL
        /// </summary>
        /// <param name="url">URL string</param>
        /// <param name="url_name">File name</param>
        /// <returns></returns>
        public static FileStream SaveADBXName(string url, string url_name)
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

        /// <summary>
        /// Save console log from aiondatabase URL
        /// </summary>
        /// <param name="url">URL string</param>
        /// <returns></returns>
        public static FileStream SaveADBLog(string url)
        {
            string path = AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + "console"
                + ".log";

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            return new FileStream(path, FileMode.Create);
        }

        /// <summary>
        /// Save HTML file from PhantomJS tab.
        /// </summary>
        /// <param name="add_string">File name</param>
        /// <returns></returns>
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