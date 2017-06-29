using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WilliamHill.Selenium;
using WilliamHill.Steps;

namespace WilliamHill
{
    [Binding]
    public sealed class SenarioHooks
    {
        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.quitWebDriver(HorseRacingBetSteps.driver);
        }
    }
}
