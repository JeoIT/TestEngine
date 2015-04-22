using System;
using OpenQA.Selenium;
using XSurf;

namespace CmsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Surf.GenerateDriver(1);
            IWebDriver driver = Surf.WebDriver;

            Surf.NavigateToURL(driver, "http://localhost:58477/");

            Click.InstantClick(driver, BySelector.ButtonBy(Enum.Buttons.InboxNew));

            string result = Javascript.ExecuteJs(driver, "return document.title");

            Console.WriteLine();
            Console.WriteLine("End Of Process");
            Console.ReadKey();
        }
    }
}
