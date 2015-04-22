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
    }
}
