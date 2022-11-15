using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLeaarning
{
    class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            //Implicit wait can be declared globally
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void GeneralInfo()
        {
            driver.FindElement(By.Id("username")).SendKeys("webberbond");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("webber");

            driver.FindElement(By.Name("password")).SendKeys("webber1");
            driver.FindElement(By.Name("password")).Clear();

            //takes 8 seconds to execute
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
        }

        [Test]
        public void ButtonsChecker()
        {
            //Finding element through CSS
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            
            //Finding element through XPath
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            //driver.FindElement(By.XPath("//input[@value='Sign In']"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String actuelUrl = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(expectedUrl, actuelUrl);
        }    
    }
}
