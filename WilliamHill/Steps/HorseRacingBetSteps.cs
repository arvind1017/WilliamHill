using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WilliamHill.Selenium;
using WilliamHill.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WilliamHill.Steps
{
        
    [Binding]
    public sealed class HorseRacingBetSteps
    {
        public static IWebDriver driver = new ChromeDriver();

        //TODO: write a page base class to instantiate the pages required for the step file
        HomePage homePage= new HomePage(driver);
        QuickBetPage quickBetPage = new QuickBetPage(driver);
        RaceBetPage raceBetPage = new RaceBetPage(driver);
        RacingPage racingPage = new RacingPage(driver);

        IWebElement racerElement;
        
        [Given(@"I open william hill website with out login credentials")]
        public void GivenIOpenWilliamHillWebsiteWithOutLoginCredentials()
        {
            WebDriver.navigateTOURL(driver);
           
        }

        [Given(@"I navigate to horse betting page")]
        public void GivenINavigateToHorseBettingPage()
        {
            homePage.navigateToRacing();
            if (racingPage.isRacingPage()) 
            { 
                //TODO: Horse betting page is loaded by default, if not handle a case to click on the horse link
               if(!racingPage.isHorseRacingHeader())
                {
                    Assert.Fail("Horse Racing div is not loaded");
                }
            }
            else
            {
                Assert.Fail("Racing div is not loaded");
            }
        }

        [When(@"I choose the next available race")]
        public void WhenIChooseTheNextAvailableRace()
        {
            IWebElement availableHorseRace = racingPage.getFirstAvailableRaceElement();
            if (availableHorseRace == null)
            {
                Assert.Fail("No Horse races available");
            }
            else
            {
                availableHorseRace.Click();
            }
        }

        [When(@"I choose to place the bet on a user")]
        public void WhenIChooseToPlaceTheBetOnAUser()
        {
            if(raceBetPage.isRaceLocationPage())
            {
                racerElement =  raceBetPage.getFirstRunnerElement();
            }
            else
            {
                Assert.Fail("Horse bet location page is not available");
            }
        }

        [When(@"I place a stake of '(.*)' \$ bet")]
        public void WhenIPlaceAStakeOfBet(String betValue)
        {
            IWebElement buttonElement = raceBetPage.getBetButtonDisplayElement(racerElement);


            if (buttonElement == null)
            {
                Assert.Fail("None of the racers have the racer button enabled");
            }
            else
            {
                buttonElement.Click();
                if(quickBetPage.isQuickBetPage())
                {
                    quickBetPage.setStakeValue(betValue);
                }
                else
                {
                    Assert.Fail("QuickBet page is not opened");
                }

            }
    

        }

        [Then(@"The confirmbet button should be enabled")]
        public void ThenTheConfirmbetButtonShouldBeEnabled()
        {
            Assert.IsTrue(quickBetPage.confirmbetButton.Enabled, "Confirm Bet button is not enabled");
        }

    }
}
