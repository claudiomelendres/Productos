using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Export1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:12679/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheExport1Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.LinkText("Balones")).Click();
            driver.FindElement(By.Name("add")).Click();
            driver.FindElement(By.LinkText("Continue shopping")).Click();
            driver.FindElement(By.LinkText("Prendas")).Click();
            driver.FindElement(By.XPath("(//button[@name='add'])[2]")).Click();
            driver.FindElement(By.LinkText("Zapatos")).Click();
            driver.FindElement(By.Name("add")).Click();
            driver.FindElement(By.LinkText("Continue shopping")).Click();
            driver.FindElement(By.Id("ctl04_csLink")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Checkout')])[2]")).Click();
            driver.FindElement(By.CssSelector("button.actionButtons")).Click();
            Assert.AreEqual("Please enter your name", driver.FindElement(By.CssSelector("li")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
