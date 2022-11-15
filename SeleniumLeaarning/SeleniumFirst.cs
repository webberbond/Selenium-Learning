using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLeaarning
{
    class SeleniumFirst
    {
        IWebDriver driver; 

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);         
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Close();
        }

    }
}
