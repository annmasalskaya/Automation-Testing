using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using log4net;

namespace TestAutomation
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();
        private static readonly ILog log = LogManager.GetLogger(typeof(Tests));
        private const string USERNAME = "testautomation";
        private const string EMAIL = "mas.anna25@gmail.com";
        private const string PASSWORD = "testautomation";
        private const string SEARCH_TERM_POPULAR = "gif";
        private const string SEARCH_TERM_UNPOPULAR = "azaza";
        private const string SECTION_XMAS = "Xmas";

        [SetUp]
        public void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [TestCase(Description = "Successful loged in.")]
        public void OneCanLogin9gag9()
        {
            log.Info("One Can Login Test Case is started.");
            steps.Login(EMAIL, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
        }


        [TestCase(Description = "Search for popular query is not empty.")]
        public void SearchPopular()
        {
            log.Info("Search Popular Test Case is started.");
            steps.Search(SEARCH_TERM_POPULAR);
            Assert.True(steps.SearchIsNotEmpty());
        }

        [TestCase(Description = "Search for unpopular query is empty.")]
        [ExpectedException("OpenQA.Selenium.NoSuchElementException")]
        public void SearchUnpopular()
        {
            log.Info("Search Unpopular Test Case is started.");
            steps.Search(SEARCH_TERM_UNPOPULAR);
            Assert.False(steps.SearchIsNotEmpty());
        }

        [TestCase(Description = "Comment is added successfully.")]
        public void AddCommentForPost()
        {
            log.Info("Add Comment Test Case is started.");
            string message = "Awesome!";
            steps.Login(EMAIL, PASSWORD);
            steps.AddCommentForPost(message);
            Assert.True(steps.CommentIsAdded(message, USERNAME));
        }

        [TestCase(Description = "Successful loged out.")]
        public void OneCanLogout9gag9()
        {
            log.Info("One Can Logout Test Case is started.");
            steps.Login(EMAIL, PASSWORD);
            steps.Logout();
            Assert.True(steps.WasLogout());
        }

    }
}
