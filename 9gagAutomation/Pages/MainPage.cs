using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using log4net;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace TestAutomation.Pages
{
    public class MainPage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainPage));

        private const string BASE_URL = "http://9gag.com/";

        [FindsBy(How = How.Id, Using = "jsid-login-email-name")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login-email-password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@value='Log in']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement linkLogIn;

        [FindsBy(How = How.Id, Using = "jsid-search-input")]
        private IWebElement searchInput;

        [FindsBy(How = How.ClassName, Using = "search")]
        private IWebElement searchLink;

        [FindsBy(How = How.LinkText, Using = "My Profile")]
        private IWebElement linkProfile;

        [FindsBy(How = How.ClassName, Using = "avatar-container")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.ClassName, Using = "info")]
        private IWebElement loggedInUser;

        private Actions action;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            action = new Actions(driver);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            log.Info("Main Page opened");
        }

        public void Login9gag(string email, string password)
        {
            linkLogIn.Click();
            inputLogin.SendKeys(email);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
            log.Info("Log in is permormed.");
        }

        public void OpenProfile()
        {
            linkLoggedInUser.Click();
            linkProfile.Click();
            log.Info("Profile opened");
        }

        public string GetLoggedInUserName()
        {
            var loggedInUserName = loggedInUser.Text;
            log.Info("Profile username is" + loggedInUserName);
            return loggedInUserName;
        }

        public void Search(String searchTerm)
        {
            searchLink.Click();
            searchInput.SendKeys(searchTerm + Keys.Enter);
            log.Info("Search is performed.");
        }

        public string SearchResults()
        {
            try
            {
                var searchResultAmountLabel = driver.FindElement(By.ClassName("section-header")).Text;
                return searchResultAmountLabel;
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
