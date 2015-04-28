using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CmsTest
{
    class DynamicDictionary
    {
        public static List<Tuple<Enum.Buttons, By, Enum.ByMethods>> ButtonList()
        {
            List<Tuple<Enum.Buttons, By, Enum.ByMethods>> buttonsTuples = new List<Tuple<Enum.Buttons, By, Enum.ByMethods>>
            {
                new Tuple<Enum.Buttons, By, Enum.ByMethods>(Enum.Buttons.InboxNew, By.Id("btnInboxNew"), Enum.ByMethods.ById),                
                new Tuple<Enum.Buttons, By, Enum.ByMethods>(Enum.Buttons.imza_ekle, By.Id("cke_52"), Enum.ByMethods.ById)
                
                
            };

            return buttonsTuples;
        }

        public static List<Tuple<Enum.Textbox, By, Enum.ByMethods>> TextList()
        {
            List<Tuple<Enum.Textbox, By, Enum.ByMethods>> buttonsTuples = new List<Tuple<Enum.Textbox, By, Enum.ByMethods>>
            {
                new Tuple<Enum.Textbox, By, Enum.ByMethods>(Enum.Textbox.Konu, By.Id("txtSubject"), Enum.ByMethods.ById),
                new Tuple<Enum.Textbox, By, Enum.ByMethods>(Enum.Textbox.anahtar_kelime, By.Id("txtTags"), Enum.ByMethods.ById),
                new Tuple<Enum.Textbox, By, Enum.ByMethods>(Enum.Textbox.belge_tarihi, By.Id("txtDueDate"), Enum.ByMethods.ById)
                //new Tuple<Enum.Textbox, By, Enum.ByMethods>(Enum.Textbox.nereye, By.Id("txtDistributionAgency2"), Enum.ByMethods.ById)
               
            };

            return buttonsTuples;
        }
    }
}
