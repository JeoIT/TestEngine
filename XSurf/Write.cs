using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;

namespace XSurf
{
    public static class Write
    {
        public static void InstantWrite(IWebDriver driver, By byCondition, string text)
        {
            Console.WriteLine("###      InstantWrite: " + byCondition);
            IWebElement webElement = driver.FindElementX(byCondition, 0);
            webElement.SendKeys(text);
        }


        public static void WriteText(IWebDriver driver, By byCondition, int waitUntilSec, string text)
        {
            Console.WriteLine("###      InstantWrite: " + byCondition);
            Thread.Sleep(waitUntilSec * 1000);
            IWebElement webElement = driver.FindElementX(byCondition, waitUntilSec);
            webElement.SendKeys(text);
        }
    }
}
