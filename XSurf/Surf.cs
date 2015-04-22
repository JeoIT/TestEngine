using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace XSurf
{
    public static class Surf
    {
        public static IWebDriver WebDriver;

        public static void GenerateDriver(int driverKind)
        {
            try
            {
                if (WebDriver == null)
                {
                    if (driverKind == 0) // PhantomJS
                    {
                        PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
                        service.IgnoreSslErrors = true;
                        service.LoadImages = false;
                        service.ProxyType = "none";
                        WebDriver = new PhantomJSDriver(service);
                    }
                    else if (driverKind == 1) //Chrome
                    {
                        var chromeDriverService = ChromeDriverService.CreateDefaultService();
                        chromeDriverService.HideCommandPromptWindow = true;
                        WebDriver = new ChromeDriver(chromeDriverService, new ChromeOptions());
                        Console.WriteLine("###      Driver generated.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static WebDriverWait Wait(IWebDriver driver, int second)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(second));
        }

        public static void WaitForWhile(IWebDriver driver, int second)
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(second));
        }

        public static void NavigateToURL(IWebDriver driver, string url)
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                // ignored
            }

            Console.WriteLine("###      Navigate: " + url);
            Console.WriteLine("###      Waiting for page load.");
            DateTime now = DateTime.Now;
            driver.Navigate().GoToUrl(url);

            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                // ignored
            }

            driver.WaitForPageToLoad();

            Console.WriteLine("###      Page load done.");
            Console.WriteLine("###      Taken: " + (DateTime.Now - now).TotalSeconds + " second.");
        }

        public static bool WaitForTitle(IWebDriver driver, int waitSecond)
        {
            try
            {
                Wait(driver, waitSecond).Until((d) => { return !string.IsNullOrWhiteSpace(d.Title); });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WaitForExactTitle(IWebDriver driver, string title, int waitSecond)
        {
            try
            {
                Wait(driver, waitSecond).Until((d) => { return d.Title == title; });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WaitForTitleContain(IWebDriver driver, string contains, int waitSecond)
        {
            try
            {
                Wait(driver, waitSecond).Until((d) => { return d.Title.ToLower().Contains(contains.ToLower()); });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool WaitForContentContain(IWebDriver driver, string contains, int waitSecond)
        {
            try
            {
                Wait(driver, waitSecond).Until((d) => { return d.PageSource.Contains(contains); });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WaitForAnElement(IWebDriver driver, string xPath, int waitSecond)
        {
            try
            {
                Wait(driver, waitSecond).Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static IWebElement FindElementX(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> FindElementsX(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }
    }
}
