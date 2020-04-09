using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Core
{
    class ExtentReport
    {

        public static ExtentReports extent = null;
        public static ExtentTest test = null;
        public static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        public static string projectPath = new Uri(actualPath).LocalPath;
        public static string reportPath = projectPath + ConfigurationManager.AppSettings["extentPath"];
        public static string screenshotPath = projectPath + ConfigurationManager.AppSettings["screenshotPath"];

        public static ExtentReports generateExtentReport()
        {

            extent = new ExtentReports(reportPath, true);

            extent.LoadConfig(projectPath + "Extent-Config.xml");

            return extent;
        }

        public static void flushReport()
        {
            extent.Flush();
        }

        public static void addScreenshotToReport(TestStatus status, String message, String testMethodName)
        {
            PageMethods.Test_ScreenShotBrowser(ExtentReport.screenshotPath, testMethodName, out String sName);
            Console.WriteLine("The screenshot name is " + sName);
            UnitTest1.test.Log(LogStatus.Fail, message);
            UnitTest1.test.Log(LogStatus.Fail, "Snapshot below: " + UnitTest1.test.AddScreenCapture(sName));
        }
    }
}
