using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WilliamHill.Selenium
{
    public static class Utils
    {
        public static IWebElement FindByText(this IWebDriver driver, List<IWebElement> elementList, String text)
        {
            var element = ((IJavaScriptExecutor)driver).ExecuteScript(String.Format(" var x = $(arguments[0]).find(\":contains('{0}')\"); return x;", text), elementList);
            return ((System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>)element)[0];
        }

        public static IWebElement returnWebElementByText( List<IWebElement> elementList, String text)
        {
            foreach (IWebElement e in elementList)
            {
                if (!String.IsNullOrEmpty(e.Text))
                {
                    if (e.Text.Equals(text))
                    {
                        return e;
                        break;
                    }
                }
            }
            return null;
        }
    }
}
