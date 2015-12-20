using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using log4net;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace TestAutomation.Pages
{
    public class XmasPage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainPage));

        private const string BASE_URL = "http://9gag.com/xmas?ref=9nav";

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'title')]/h2")]
        private IWebElement title;

        private IWebDriver driver;

        public XmasPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            log.Info("Xmas Page opened");
        }

        public string GetTitleText()
        {
            log.Info("Getting of title text is permormed.");
            return title.Text;
        }
    }
}
