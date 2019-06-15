using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading;

using Iswenzz.AION.DBParser.Buttons;

namespace Iswenzz.AION.DBParser
{
    class Program
    {
        public static void Main()
        {
            PhantomKillProcess();
            PhantomStart();

            int input = 1000;
            bool stop = false;
            dynamic checker = ButtonTable.Button;

            Console.Clear();
            Console.WriteLine("Iswenzz (c) 2018\n");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            try
            {
                while (!stop)
                {
                    int index = 0;
                    foreach (var selection in checker)
                        Console.WriteLine((index += 1) + ". {0}" + selection.Name, selection.Stop ? "" : ">>");
                    Console.WriteLine("\nParse Number: ");

                    string input_key = Console.ReadLine();
                    int.TryParse(input_key, out int input_parsed);
                    input = input_parsed;
                    input--;

                    Console.Clear();

                    if (input + 1 <= checker.Length)
                    {
                        switch (checker[input].Name)
                        {
                            case "NPC":   checker = ButtonTable.Npc;    break;
                            case "Grade": checker = ButtonTable.Grade;  break;
                            case "Zone":  checker = ButtonTable.Zone;   break;
                            default:      stop = true;                  break;
                        }
                    }
                }

                checker[input].Parse();
            }
            catch (Exception e) { Console.WriteLine("\n" + e + "\n"); Thread.Sleep(1000); Main(); }

            PhantomKillProcess();
            Console.WriteLine("\nDone!\nPress Any Key to Exit...");
            Console.ReadKey();
        }

        public static PhantomJSDriver driver;
        public static PhantomJSDriverService driverService;
        public static ArrayList WindowHandle = new ArrayList();

        public static void PhantomStart()
        {
            driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            driver = new PhantomJSDriver(driverService);
            driver.Url = "http://aiondatabase.net/en/";
            driver.Navigate();
            WindowHandle.Add(driver.CurrentWindowHandle);
        }

        public static void PhantomTab(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]);
        }

        public static void PhantomNewTab(string url, int index)
        {
            driver.ExecuteScript("$(window.open('" + url + "'))");
            driver.SwitchTo().Window(driver.WindowHandles[index]);
            driver.Url = url;
            driver.Navigate();
        }

        public static void PhantomCloseTab()
        {
            driver.Close();
            // Use PhantomTab after
        }

        public static void PhantomKillProcess()
        {
            foreach (Process proc in Process.GetProcessesByName("phantomjs"))
                proc.Kill();
        }

        public static string Last_Dir(string url)
        {
            string last_dir = url.Remove(url.Length - 1);

            int to_sub = 0;
            while (last_dir[last_dir.Length - to_sub - 1] != '/')
                to_sub++;

            return last_dir.Substring(last_dir.Length - to_sub);
        }

        public static string Load_XML(string url, string url_name)
        {
            return AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + Last_Dir(url)
                + "_"
                + url_name
                + ".xml";
        }

        public static FileStream Save_XML(string url, string url_name)
        {
            string path = AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + Last_Dir(url)
                +"_"
                + url_name
                + ".xml";

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            return new FileStream(path, FileMode.Create);
        }

        public static FileStream Save_Log(string url)
        {
            string path = AppContext.BaseDirectory
                + "aiondatabase/"
                + url.Replace("http://aiondatabase.net/en/", "")
                + "console"
                + ".log";

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            return new FileStream(path, FileMode.Create);
        }

        public static string Save_HTML(string add_string = "")
        {
            string HTML_path = AppContext.BaseDirectory
                + "aiondatabase/"
                + driver.Url.Replace("http://aiondatabase.net/en/", "")
                + add_string
                + ".html";

            Directory.CreateDirectory(Path.GetDirectoryName(HTML_path));
            StreamWriter HTML_page_source = new StreamWriter(new FileStream(HTML_path, FileMode.Create));

            HTML_page_source.Write(driver.PageSource);
            HTML_page_source.Close();
            HTML_page_source.Dispose();

            return HTML_path;
        }
    }
}