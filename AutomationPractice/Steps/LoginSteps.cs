using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NUnit;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using AutomationPractice.PageObjects;

namespace AutomationPractice.Steps
{
    [TestFixture]

    [Binding]
    public class LoginSteps
    {
        IWebDriver Driver;
        //ChromeDriver _driver;
        WebDriverWait wait;
        LoginPage Login;

        [BeforeScenario]
        public void SetUp()
        {
            var VendorDirectory = System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + @"\Vendor";

            //var Service = ChromeDriverService.CreateDefaultService(VendorDirectory);
            var Service = FirefoxDriverService.CreateDefaultService(VendorDirectory);
            // _driver = new ChromeDriver(Service);
            Driver = new FirefoxDriver(Service);
            Driver.Url = ConfigurationManager.AppSettings["baseURL"];
            Login = new LoginPage(Driver);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Close();
        }

        [Given(@"that I am on TheInternet login page")]
        public void GivenThatIAmOnTheInternetLoginPage()
        {
            Assert.That(Driver.FindElement(By.TagName("body")).Text.Contains("This is where you can log into the secure area"));

        }

        [When(@"I login with valid credentials")]
        public void WhenILoginWithValidCredentials()
        {
            Login.With("tomsmith", "SuperSecretPassword!");

        }

        [Then(@"I see the Secure Area page")]
        public void ThenISeeTheSecureAreaPage()
        {
            Assert.That(Login.SuccessMessagePresent);

        }

        [When(@"I login with invalid credentials")]
        public void WhenILoginWithInvalidCredentials()
        {
            Login.With("invalidusername", "invalidpassword");

        }

        [Then(@"I should see an invalid username message")]
        public void ThenIShouldSeeAnInvalidUsernameMessage()
        {
            Assert.That(Login.InvalidUsernameMessagePresent);

        }

    }
}
