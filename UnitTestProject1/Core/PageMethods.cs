using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Core
{
    class PageMethods : BrowserMethods
    {

        private static IWebDriver webDriver = BrowserMethods.getDriver;
        private static string baseURL = ConfigurationManager.AppSettings["url"];
        private static string browser = ConfigurationManager.AppSettings["browser"];

        public string PageSource => webDriver.PageSource;
        public string CurrentWindowHandle => webDriver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;


        public IEnumerable<IWebElement> FindElements(By by)
        {
            return webDriver.FindElements(by);
        }

        public void NavigateBack()
        {
            webDriver.Navigate().Back();
        }

        public void Refresh()
        {
            webDriver.Navigate().Refresh();
        }

        public void CloseBrowser()
        {
            webDriver.Close();
        }

        public IWebElement FindElement(By by)
        {
            return webDriver.FindElement(by);
        }

        public IOptions Manage()
        {
            return webDriver.Manage();
        }

        public INavigation Navigate()
        {
            return webDriver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return webDriver.SwitchTo();
        }

        public static void Test_ScreenShotBrowser(String screenshotPath, String name, out String ssName)
        {
            ssName = screenshotPath + name + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ". png";
            try
            {
                Screenshot sc = ((ITakesScreenshot)BrowserMethods.getDriver).GetScreenshot();
                sc.SaveAsFile(ssName, ScreenshotImageFormat.Png);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail("Failed with Exception: " + e);
        }
        }

        public void switchToFrame()
        {
            IWebElement iframe = FindElement(By.CssSelector("#modal>iframe"));

            //Switch to the frame
            webDriver.SwitchTo().Frame(iframe);
        }

        public void switchToDefaultContent()
        {
            webDriver.SwitchTo().DefaultContent();
        }

        public void minimizeWindow()
        {
            webDriver.Manage().Window.Minimize();
        }

        public void acceptAlert()
        {
            webDriver.SwitchTo().Alert().Accept();
        }

        public void dismissAlert()
        {
            webDriver.SwitchTo().Alert().Dismiss();
        }

        public String getTextFromAlert()
        {
            return webDriver.SwitchTo().Alert().Text;
        }

        [Obsolete]
        public bool checkIfAlertIsPresent()
        {
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(webDriver);
            return (alert != null);
        }

    }
}
