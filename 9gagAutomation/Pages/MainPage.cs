using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using log4net;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;


namespace TestAutomation.Pages
{
    public class MainPage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainPage));

        private const string BASE_URL = "http://9gag.com/";

        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement linkLogIn;

        [FindsBy(How = How.Id, Using = "jsid-search-input")]
        private IWebElement searchInput;

        [FindsBy(How = How.ClassName, Using = "search")]
        private IWebElement searchLink;

        [FindsBy(How = How.LinkText, Using = "My Profile")]
        private IWebElement linkProfile;

        [FindsBy(How = How.ClassName, Using = "avatar-container")]
        private IWebElement userContainer;

        [FindsBy(How = How.ClassName, Using = "info")]
        private IWebElement loggedInUser;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement linkLogout;

        [FindsBy(How = How.CssSelector, Using = " a[class='btn-mute badge-login-button']")]
        private IWebElement loginButton;

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

        public void OpenProfile()
        {
            OpenUserContainerDropDown();
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

        public bool SearchResultsIsFind()
        {
            return driver.FindElement(By.ClassName("section-header")).Displayed;
        }

        public void Logout9gag()
        {
            OpenUserContainerDropDown();
            linkLogout.Click();
            log.Info("Log out is permormed.");
        }

        private void OpenUserContainerDropDown()
        {
            userContainer.Click();
        }

        public bool LoginButtonIsDisplayed()
        {
            return loginButton.Displayed;
        }

    }
}
