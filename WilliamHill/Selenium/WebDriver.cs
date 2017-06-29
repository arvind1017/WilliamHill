using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;


namespace WilliamHill.Selenium
{
    public class WebDriver
    {

        public static void setWebDriver(IWebDriver driver)
        {
            //TODO: set other drivers as necessary
            driver = new ChromeDriver();
        }


        public static void quitWebDriver(IWebDriver driver)
        {
            driver.Quit();
        }

        public static void navigateTOURL(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("URL"));
            driver.Manage().Window.Maximize();
        }
    }
}
