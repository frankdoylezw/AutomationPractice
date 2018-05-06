using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NUnit;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace AutomationPractice.Steps
{
    [TestFixture]

    [Binding]
    public class LoginSteps
    {
        IWebDriver _driver;
        //ChromeDriver _driver;
        IJavaScriptExecutor JSDriver;
        WebDriverWait wait;

        [BeforeScenario]
        public void SetUp()
        {
            var VendorDirectory = System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + @"\Vendor";

            //var Service = ChromeDriverService.CreateDefaultService(VendorDirectory);
            var Service = FirefoxDriverService.CreateDefaultService(VendorDirectory);
            // _driver = new ChromeDriver(Service);
            _driver = new FirefoxDriver(Service);

            JSDriver = (IJavaScriptExecutor)_driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Close();
        }

        [Given(@"that I am on TheInternet login page")]
        public void GivenThatIAmOnTheInternetLoginPage()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");

        }

        [When(@"I login with valid credentials")]
        public void WhenILoginWithValidCredentials()
        {
            _driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            _driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"I see the Secure Area page")]
        public void ThenISeeTheSecureAreaPage()
        {
            string welcomemessage = _driver.FindElement(By.TagName("body")).Text;
            Assert.That(welcomemessage.Contains("Welcome"));
        }
    }
}
