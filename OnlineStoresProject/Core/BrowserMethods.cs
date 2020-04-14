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
            /*public static ExtentReports extent = null;*/
            private static string baseURL = ConfigurationManager.AppSettings["url"];
            private static string browser = ConfigurationManager.AppSettings["browser"];
            private static string extentPath = ConfigurationManager.AppSettings["extentPath"];
            /*public static ExtentTest extentTest = null;
            public static ExtentHtmlReporter htmlReporter = null;*/
            public static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            public static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            public static string projectPath = new Uri(actualPath).LocalPath;
            public static string reportPath = projectPath + "Reports\\TestRunReport.html";

            public static void Init()
            {
            switch (browser)
                {
                    case "Chrome":
                        webDriver = new ChromeDriver();
                        break;
                    case "IE":
                        webDriver = new InternetExplorerDriver();
                        break;
                    case "Firefox":
                        webDriver = new FirefoxDriver();
                        break;
                }
            }
            public static string Title
            {
                get { return webDriver.Title; }
            }
            public static IWebDriver getDriver
            {
                get { return webDriver; }
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
