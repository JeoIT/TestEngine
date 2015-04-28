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

            Surf.NavigateToURL(driver, "http://test.jeoit.com");

            Click.InstantClick(driver, BySelector.ButtonBy(Enum.Buttons.InboxNew));

            string result = Javascript.ExecuteJs(driver, "$('#selTemplate').val(356);$('#selTemplate').trigger('chosen:updated');$('#selTemplate').trigger('chosen:updated');$('#selTemplate').trigger('change');");

            Write.WriteText(driver, BySelector.TextBy(Enum.Textbox.Konu), 3, "deneme konu");
            Write.InstantWrite(driver, BySelector.TextBy(Enum.Textbox.anahtar_kelime), "deneme anahtar kelime");
            

            Write.InstantWrite(driver, BySelector.TextBy(Enum.Textbox.belge_tarihi), "24.05.2014");

            //Javascript.ExecuteJs(driver, "$('#txtDistributionAgency2').autocomplete({source: yerler, select: function (event, ui) { $('#txtDistributionAgency2').val(ui.item.value); return false;} });");
            
            



            //belge içeriği girişi
            Javascript.ExecuteJs(driver, "CKEDITOR.instances.jquery_ckeditor.insertText('deneme içerik')");


            Click.InstantClick(driver, BySelector.ButtonBy(Enum.Buttons.imza_ekle));

            AutoComplete.Choose(driver, "bili", "txtDistributionAgency2", "ui-id-125");
            
            //Console.WriteLine(result);

            //Write.InstantWrite(driver, BySelector.TextBy(Enum.Textbox.nereye), "bili");

            //Click.InstantClick(driver, BySelector.ButtonBy(Enum.Buttons.nereye_secimi));
            

            Console.WriteLine();
            Console.WriteLine("End Of Process");
            Console.ReadKey();
        }
    }
}
