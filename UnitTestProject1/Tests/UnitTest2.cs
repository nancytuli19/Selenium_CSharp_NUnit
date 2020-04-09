using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Core;

namespace UnitTestProject1.Tests
{
    class UnitTest2 : BaseTest
    {
        [Test, Category("Sanity Testing")]
        [Author("Nancy Tuli", "nancytuli19@gmail.com")]
        public void TestMethod2()
        {
            test.AssignAuthor("Nancy Tuli");
            BrowserMethods.Goto(ConfigurationManager.AppSettings["url"]);
            test.Log(LogStatus.Info, "Opened Browser");
            BrowserMethods.getDriver.Manage().Window.Maximize();
            test.Log(LogStatus.Pass, "Test Case passd");
        }

    }
}
