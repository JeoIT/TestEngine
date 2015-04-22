using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace XSurf
{
    public class Javascript
    {
        public static string ExecuteJs(IWebDriver driver, string javaScriptCode)
        {
            string result = string.Empty;

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (js != null)
            {
                result = (string)js.ExecuteScript(javaScriptCode);
            }

            return result;
        }
    }
}
