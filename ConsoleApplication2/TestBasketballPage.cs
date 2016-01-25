﻿using System;
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
    class TestBasketballPage : Program
    {
        /// <summary>
        /// Test form submission on Krossover basketball page
        /// </summary>
        public void testBasketballPage(FirefoxDriver driver)
        {
            //variables to enter in form
            string page = "http://www.krossover.com/basketball/";
            string name = "Jóhn Dóe"; //international character testing
            string teamName = "Test Team";
            string city = "New York";
            string state = "NY";
            string sport = "Football";
            string gender = "Male";
            string email = "test@gmail.com";
            string phone = "123-456-789";
            string day = "Friday";

            //fill out all the fields
            driver.Navigate().GoToUrl(page);
            driver.FindElementByName("Field1").SendKeys(name);
            driver.FindElementByName("Field2").SendKeys(teamName);
            driver.FindElementByName("Field3").SendKeys(city);
            driver.FindElementByName("Field4").SendKeys(state);
            driver.FindElementByName("Field6").FindElement(By.XPath(".//option[contains(text(),'" + sport + "')]")).Click();
            driver.FindElementByName("Field7").FindElement(By.XPath(".//option[contains(text(),'" + gender + "')]")).Click();
            driver.FindElementByName("Field9").SendKeys(email);
            driver.FindElementByName("Field11").SendKeys(phone);
            driver.FindElementByName("Field14").FindElement(By.XPath(".//option[contains(text(),'" + day + "')]")).Click();

            driver.FindElementByName("saveForm").Click(); //submit the form

            /*verify the form submission was actually generated by querying the db
             * if so, test passes
             * else, test fails
            */
            driver.Quit();
        }
    }
}