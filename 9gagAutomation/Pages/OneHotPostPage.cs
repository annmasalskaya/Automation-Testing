using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using log4net;
using System.Collections.Generic;
using System.Linq;


namespace TestAutomation.Pages
{
    public class OneHotPostPage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OneHotPostPage));

        private const string BASE_URL = "http://9gag.com/gag/aVPjAyO";

        [FindsBy(How = How.CssSelector, Using = "textarea[class='post-text-area badge-post-textarea focus']")]
        private IWebElement commentInput;

        [FindsBy(How = How.CssSelector, Using = "a[class='cmnt-btn size-30 submit-comment badge-post-trigger']")]
        private IWebElement postButton;

        [FindsBy(How = How.CssSelector, Using = "a[class='username badge-author-name badge-normal']")]
        private IList<IWebElement> commentorUsernames;

        [FindsBy(How = How.CssSelector, Using = "div[class='content badge-content']")]
        private IList<IWebElement> commentMessages;

        private IWebDriver driver;

        public OneHotPostPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            log.Info("One Hot Post Page opened");
        }

        public void AddCommentOnLastPost(string commentMessage)
        {
            commentInput.SendKeys(commentMessage);
            postButton.Click();
        }

        public string GetLastCommentMessage()
        {
            var lastCommentMessage = commentMessages.FirstOrDefault();
            if (lastCommentMessage != null)
            {
                return lastCommentMessage.Text;
            }
            return String.Empty;

        }

        public string GetLastCommentAuthor()
        {
            var lastCommentAuthor = commentorUsernames.FirstOrDefault();
            if (lastCommentAuthor != null)
            {
                return lastCommentAuthor.Text;
            }
            return String.Empty;

        }
    }
}
