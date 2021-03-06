﻿using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using AutomationPractice.PageObjects;

namespace AutomationPractice.Steps
{
    [TestFixture]

    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        LoginPage Login;

        public LoginSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            Login = new LoginPage(_driver);
        }

        [Given(@"that I am on TheInternet login page")]
        public void GivenThatIAmOnTheInternetLoginPage()
        {

            Assert.That(_driver.FindElement(By.TagName("body")).Text.Contains("This is where you can log into the secure area"));

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
