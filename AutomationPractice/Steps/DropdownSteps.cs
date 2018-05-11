using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace AutomationPractice
{
    [TestFixture]

    [Binding]
    public class DropdownSteps
    {
        private readonly IWebDriver _driver;
        private string _dropdownText;
        WebDriverWait _wait;

        
        public DropdownSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            _wait = ScenarioContext.Current.Get<WebDriverWait>("currentwait");
        }

        [Given(@"I am on the dropdown example page")]
        public void GivenIAmOnTheDropdownExamplePage()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            _wait.Until(ExpectedConditions.ElementExists(By.Id("dropdown")));
            Assert.That(_driver.FindElement(By.Id("dropdown")).Text.Contains("Please select"));
        }
        
        [When(@"I click on the second item in the dropdown list")]
        public void WhenIClickOnTheSecondItemInTheDropdownList()
        {
            SelectElement Dropdown = new SelectElement(_driver.FindElement(By.Id("dropdown")));
            Dropdown.SelectByText("Option 2");
        }
        
        [Then(@"Option (.*) should be selected")]
        public void ThenOptionShouldBeSelected(int dropdownoption)
        {
            _dropdownText = dropdownoption.ToString();
            SelectElement Dropdown = new SelectElement(_driver.FindElement(By.Id("dropdown")));
            Assert.That(Dropdown.SelectedOption.Text.Equals("Option "  + _dropdownText));


        }
    }
}
