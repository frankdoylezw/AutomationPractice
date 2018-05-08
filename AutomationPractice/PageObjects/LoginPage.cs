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
        IWebDriver Driver;
        By UsernameInput = By.Id("username");
        By PasswordInput = By.Id("password");
        By SubmitButton = By.CssSelector("button[type='submit']");
        By SuccessMessage = By.TagName("body");
        By InvalidUsernameMessage = By.CssSelector(".flash.error");

        public LoginPage (IWebDriver driver)
        {
            Driver = driver;
            driver.Url = ConfigurationManager.AppSettings["baseURL"];
            Driver.Navigate().GoToUrl(driver.Url + "/login");

        }

        public void With(string username, string password)
        {
            Driver.FindElement(UsernameInput).SendKeys(username);
            Driver.FindElement(PasswordInput).SendKeys(password);
            Driver.FindElement(SubmitButton).Click();
            System.Threading.Thread.Sleep(1000);


        }
        public bool SuccessMessagePresent()
        {
            return Driver.FindElement(SuccessMessage).Text.Contains("Welcome");


        }

        public bool InvalidUsernameMessagePresent()
        {
            return Driver.FindElement(InvalidUsernameMessage).Displayed;

        }




    }
}
