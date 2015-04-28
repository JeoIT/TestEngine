using System;
using System.Linq;
using OpenQA.Selenium;

namespace CmsTest
{
    public class BySelector
    {
        public static By ButtonBy(Enum.Buttons button)
        {
            By result = null;

            Tuple<Enum.Buttons, By, Enum.ByMethods> theButtonTuple = DynamicDictionary.ButtonList().SingleOrDefault(a => a.Item1 == button);

            if (theButtonTuple != null)
            {
                result = theButtonTuple.Item2;
            }

            return result;
        }


        public static By TextBy(Enum.Textbox text)
        {
            By result = null;

            Tuple<Enum.Textbox, By, Enum.ByMethods> theButtonTuple = DynamicDictionary.TextList().SingleOrDefault(a => a.Item1 == text);

            if (theButtonTuple != null)
            {
                result = theButtonTuple.Item2;
            }

            return result;
        }
    }
}
