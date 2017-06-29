using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WilliamHill.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WilliamHill.Pages
{
    class RaceBetPage
    {
        private IWebDriver driver;
        public RaceBetPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.CssSelector, Using = "div[class^='Select_valueText']")]
        public IList<IWebElement> raceLocation;

        [FindsBy(How = How.CssSelector, Using = "div[class^='RaceCardList_gridRow_']")]
        public IList<IWebElement> runnersList;


        [FindsBy(How = How.CssSelector, Using = "span[class^='BetButton_display_']")]
        public IList<IWebElement> betButtonValue;

        By locator = By.CssSelector("span[class^='BetButton_display_']");        

        public bool isRaceLocationPage()
        {
            //TODO: Get the element name on the menu of the race available and then asserting it here
            //work around: check if the title of the div is not racing 
            bool status = true;
            List<IWebElement> raceLocationList = new List<IWebElement>(raceLocation);
            if (!(Utils.returnWebElementByText(raceLocationList, "Racing") == null))
            {
                status = false;
            }
            
            return status;
        }

        public IWebElement getFirstRunnerElement()
        {
            if (runnersList.Count == 0)
            {
                Assert.Fail("No horse racers available");
                return null; 
            }

            List<IWebElement> rList = new List<IWebElement>(runnersList);
            foreach (IWebElement list in rList.Skip(1))
            {
                if (list.Enabled)
                {
                    return list;
                }
            }

            return null;
        }

        public IWebElement getBetButtonDisplayElement(IWebElement runnerElement)
        {
            IReadOnlyCollection<IWebElement> buttonCollection =  runnerElement.FindElements(locator);
            if (buttonCollection.Count == 0)
            {
                Assert.Fail("Button to place race bet not available");
                return null;
            }
            else
            {
                List<IWebElement> buttonList = new List<IWebElement>(buttonCollection);
                return buttonList[0];
            }
        }

    }
}
