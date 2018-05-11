using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationPractice.Features
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        IWebDriver _driver;
        WebDriverWait wait;

        [BeforeScenario]
        public void Setup()
        {
            var VendorDirectory = System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + @"\Vendor";
            //var Service = ChromeDriverService.CreateDefaultService(VendorDirectory);
            var Service = FirefoxDriverService.CreateDefaultService(VendorDirectory);
            // _driver = new ChromeDriver(Service);
            _driver = new FirefoxDriver(Service);
            //Driver.Url = ConfigurationManager.AppSettings["baseURL"];
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            ScenarioContext.Current.Add("currentDriver", _driver);
            ScenarioContext.Current.Add("currentwait", wait);

        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
