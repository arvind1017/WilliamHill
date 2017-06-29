using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WilliamHill.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WilliamHill.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }
        
        //[FindsBy(How = How.CssSelector, Using = "div[class^='MenuItem_root_QGB MenuItem_rootMain']")]
        //public IList<IWebElement> mainMenuItems;
        
        [FindsBy(How = How.CssSelector, Using = "span[class^='MenuItem_text']")]
        public IList<IWebElement> menuItems;

        public void navigateToRacing()
        {
            List<IWebElement> menuItemsList = new List<IWebElement>(menuItems);

            IWebElement racingElement = Utils.returnWebElementByText(menuItemsList, "RACING");

            if (racingElement == null)
            {
                Assert.Fail("Unable to find Racing link in home page");
            }
            else
            {
                racingElement.Click();
            }
        }
    }
}
