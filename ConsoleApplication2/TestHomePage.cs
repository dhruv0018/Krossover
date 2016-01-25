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
    class TestHomePage : Program
    {
        /// <summary>
        /// Test all links on the Krossover home page
        /// </summary>
        public void testHomePage(FirefoxDriver driver)
        {
            string homePage = "http://www.krossover.com/";
            driver.Navigate().GoToUrl(homePage);
            Thread.Sleep(1000);

            //find all links on the page
            IList<IWebElement> links = driver.FindElementsByTagName("a");

            //loop through all of the links on the page
            foreach (IWebElement link in links)
            {
                try
                {
                    //check if any of the links return a 404
                    driver.FindElementByXPath("//div[contains(@class, '404')]");
                    log(link.GetAttribute("href") + " is broken.  Returned 404");
                }
                catch
                {
                    //continue to the next link
                    continue;
                }

            }
            driver.Quit(); //kill the driver
        }
    }
}
