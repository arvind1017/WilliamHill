using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WilliamHill.Selenium;

namespace WilliamHill.Pages
{
    class QuickBetPage
    {
        private IWebDriver driver;

        public QuickBetPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(15)));
        }

        [FindsBy(How = How.CssSelector, Using = "img[alt='QuickBet']")]
        public IWebElement quickBetHeader;

        [FindsBy(How = How.XPath, Using = "//span[starts-with(@class,'QuickBet_competitorName_')]/text()")]
        public IWebElement competitorName;

        [FindsBy(How = How.CssSelector, Using = "div[class^='CurrencyBox_inputContainer_'] > input[placeholder='Stake']")]
        public IWebElement stakeInputField;

        [FindsBy(How = How.CssSelector, Using = "button[data-redesign-ga='QuickBet/Click/ConfirmBet']")]
        public IWebElement confirmbetButton;

        By locator = By.CssSelector("img[alt='QuickBet']");
        WebDriverWait wait;

        public void confirmbetButtonClick()
        {
            confirmbetButton.Click(); 
        }
        
        public void setStakeValue(string betAmount)
        {
            stakeInputField.SendKeys(betAmount);
        }

        public bool isQuickBetPage()
        {
            bool status = false;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(locator));
            if (confirmbetButton.Displayed)
            {
                status = true;
            }
            return status;
        }

    }
}
