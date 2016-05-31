using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Flight.Tests.Selenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:34302/");

            IWebElement myLink = driver.FindElement(By.LinkText("Log in"));
            myLink.Click();
            driver.Quit();



        }
    }
}
