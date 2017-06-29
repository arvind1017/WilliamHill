using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WilliamHill.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WilliamHill.Pages
{
    class RacingPage
    {
        private IWebDriver driver;

        public RacingPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.CssSelector, Using = "h1[class^='Header_title']")]
        public IWebElement racingHeaderText;

        [FindsBy(How = How.CssSelector, Using = "div[class^='EventTypeHeader_content'] > span")]
        public IWebElement horseRacingText;

        [FindsBy(How = How.CssSelector, Using = "div[class^='RacingHome_available_']")]
        public IList<IWebElement> availableRaceList;

        WebDriverWait wait;

        public bool isRacingPage()
        {
            bool status = false;
           //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           //bool isDisplayed = (bool)wait.Until(racingHeaderText.Displayed);
            if (racingHeaderText.Text.Equals("Racing"))
            {
                status = true;
            }
            return status;
        }

        public bool isHorseRacingHeader()
        {
            bool status = false;

            if (horseRacingText.Text.Equals("Horse Racing"))
            {
                status = true;
            }
            return status;
        }

        public IWebElement getFirstAvailableRaceElement()
        {
            IWebElement raceElement;
            if (availableRaceList.Count == 0)
            {
                raceElement = null;
            }
            else
            {
                raceElement = availableRaceList[0];
            }

            return raceElement;
        }
    }
}
