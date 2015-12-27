using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;

namespace TestAutomation.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Close();
            driver = null;
        }
    }
}
