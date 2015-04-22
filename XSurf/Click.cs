using System;
using OpenQA.Selenium;

namespace XSurf
{
    public class Click
    {
        public static void InstantClick(IWebDriver driver, By byCondition)
        {
            Console.WriteLine("###      InstantClick: " + byCondition);
            IWebElement webElement = driver.FindElementX(byCondition, 0);
            webElement.Click();
        }
    }
}
