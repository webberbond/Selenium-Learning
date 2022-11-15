using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLeaarning
{
    class SortWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTable()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            ArrayList a = new ArrayList();
            //Step1: Get all vegetable names to an arrayList A
            IList<IWebElement> vegetables = driver.FindElements(By.XPath("//tr//td[1]"));
            foreach( IWebElement vegetable in vegetables)
            {
                a.Add(vegetable.Text);
            }

            //Step2: Sort the arrayList         
            a.Sort();
            foreach(String element in a )
            {
                TestContext.Progress.WriteLine(element);
            }
            //Step3: Go and click column
            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();

            //Step4: Get all vegetable names to an arrayList B
            ArrayList b = new ArrayList();

            IList<IWebElement> sortedVegetables = driver.FindElements(By.XPath("//tr//td[1]"));
            foreach (IWebElement vegetable in sortedVegetables)
            {
                b.Add(vegetable.Text);
            }

            //arrayList A to B = equal
            Assert.AreEqual(a, b);
        }
    }
}
