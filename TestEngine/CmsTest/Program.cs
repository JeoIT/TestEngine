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

            Surf.NavigateToURL(driver, "http://testebys.jeoit.com");

            Click.InstantClick(driver, BySelector.ButtonBy(Enum.Buttons.InboxNew));

            Write.WriteText(driver, BySelector.TextBy(Enum.Textbox.Konu), 3, "deneme");

            string result = Javascript.ExecuteJs(driver, "$('#selTemplate').val(287);$('#selTemplate').trigger('chosen:updated');$('#selTemplate').trigger('chosen:updated');$('#selTemplate').trigger('change');");
            //Console.WriteLine(result);

            Console.WriteLine();
            Console.WriteLine("End Of Process");
            Console.ReadKey();
        }
    }
}
