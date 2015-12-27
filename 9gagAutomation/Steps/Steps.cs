using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace TestAutomation.Steps
{
    public class Steps
    {
        IWebDriver driver;

        private static readonly ILog log = LogManager.GetLogger(typeof(Steps));

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
            log.Info("Browser is started.");
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
            log.Info("Browser is closed.");
        }

        public void Login(string email, string password)
        {
            Pages.LoginPage mainPage = new Pages.LoginPage(driver);
            mainPage.OpenPage();
            mainPage.Login9gag(email, password);
            log.Info("Login step is performed.");
        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenProfile();
            return (mainPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }

        public void Search(String searchTerm)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Search(searchTerm);
            log.Info("Search step is performed.");
        }

        public bool SearchIsNotEmpty()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.SearchResultsIsFind();
        }

        public void AddCommentForPost(string comment)
        {
            Pages.OneHotPostPage postPage = new Pages.OneHotPostPage(driver);
            postPage.OpenPage();
            postPage.AddCommentOnLastPost(comment);
            log.Info("Add comment step is performed.");
        }

        public bool CommentIsAdded(string comment, string username)
        {
            Pages.OneHotPostPage postPage = new Pages.OneHotPostPage(driver);
            return postPage.GetLastCommentAuthor().Equals(username) && postPage.GetLastCommentMessage().Equals(comment);
        }

        public void Logout()
        {   
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Logout9gag();
        }

        public bool WasLogout()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.LoginButtonIsDisplayed();
        }

        
    }
}
