using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;

namespace AutomationPractice.PageObjects
{
    class LoginPage
    {

        //Properties and Fields
        IWebDriver _driver;
        By UsernameInput = By.Id("username");
        By PasswordInput = By.Id("password");
        By SubmitButton = By.CssSelector("button[type='submit']");
        By SuccessMessage = By.TagName("body");
        By InvalidUsernameMessage = By.CssSelector(".flash.error");
        
        //Constructor
        public LoginPage (IWebDriver Driver)
        {
            _driver = Driver;
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");


        }

        public void With(string username, string password)
        {
            _driver.FindElement(UsernameInput).SendKeys(username);
            _driver.FindElement(PasswordInput).SendKeys(password);
            _driver.FindElement(SubmitButton).Click();
            System.Threading.Thread.Sleep(1000);


        }
        public bool SuccessMessagePresent()
        {
            return _driver.FindElement(SuccessMessage).Text.Contains("Welcome");


        }

        public bool InvalidUsernameMessagePresent()
        {
            return _driver.FindElement(InvalidUsernameMessage).Displayed;

        }




    }
}
