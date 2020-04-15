using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoresProject.Core
{
        public class BrowserMethods
        {
            private static IWebDriver webDriver;
            private static string baseURL = ConfigurationManager.AppSettings["url"];
            private static string browser = ConfigurationManager.AppSettings["browser"];
            private static string extentPath = ConfigurationManager.AppSettings["extentPath"];
            public static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            public static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            public static string projectPath = new Uri(actualPath).LocalPath;
            public static string reportPath = projectPath + "Reports\\TestRunReport.html";

            public static void Init()
            {

            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            switch (browser)
                {
                    case "Chrome":
                        webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                        break;
                    case "IE":
                        webDriver = new InternetExplorerDriver();
                        break;
                    case "Firefox":
                        webDriver = new FirefoxDriver();
                        break;
                }
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3600);
        }
            public static string Title
            {
                get { return webDriver.Title; }
            }
            public static IWebDriver getDriver
            {
                get { return webDriver; }
            }

            public static void SetImplicitTimeout(int seconds)
            {
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }

            public static void Goto(string url)
            {
                webDriver.Url = url;
            }
            public static void Close()
            {
                webDriver.Quit();
            }
    }
 }
