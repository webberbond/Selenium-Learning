using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLeaarning
{
    class AlertsActionsAutoSuggestive
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            //Implicit wait can be declared globally

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void TestAlert()
        {
            String name = "Sergey";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("#confirmbtn")).Click();

            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //driver.SwitchTo().Alert().Dismiss();

            //driver.SwitchTo().Alert().SendKeys("Hello");
            StringAssert.Contains(name, alertText);
        }

        [Test]
        public void AutoSuggestiveDropDowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);

            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))

                {
                    option.Click();
                }
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }

        [Test]
        public void DropdownExample()
        {
            IWebElement dropDown = driver.FindElement(By.Id("dropdown-class-example"));
            SelectElement s = new SelectElement(dropDown);
            s.SelectByValue("option1");
            s.SelectByValue("option2");
            s.SelectByValue("option3");
        }
    }
}
