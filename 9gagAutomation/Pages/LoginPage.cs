using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using log4net;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;


namespace TestAutomation.Pages
{
    public class LoginPage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginPage));

        private const string BASE_URL = "http://9gag.com/login";

        [FindsBy(How = How.Id, Using = "jsid-login-email-name")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login-email-password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@value='Log in']")]
        private IWebElement buttonSubmit;

        private Actions action;
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            log.Info("Login Page opened");
        }

        public void Login9gag(string email, string password)
        {
            inputLogin.SendKeys(email);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
            log.Info("Log in is permormed.");
        }
    }
}
