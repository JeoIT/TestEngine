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
                new Tuple<Enum.Buttons, By, Enum.ByMethods>(Enum.Buttons.InboxNew, By.Id("btnInboxNew"), Enum.ByMethods.ById)
            };

            return buttonsTuples;
        }
    }
}
