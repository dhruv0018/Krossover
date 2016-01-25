using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace Krossover
{
    class Program
    {
        static void Main(string[] args)
        {
                var driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                
                TestHomePage test = new TestHomePage();
                test.testHomePage(driver);

                TestBasketballPage test2 = new TestBasketballPage();
                test2.testBasketballPage(driver);
                
        }

        /// <summary>
        /// Write to log file
        /// </summary>
        public void log(string logText)
        {
            // Create a writer and open the file
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }

            // Write to the file
            log.WriteLine(DateTime.Now);
            log.WriteLine(logText);
            log.WriteLine();

            log.Close();
        }
    }
}
