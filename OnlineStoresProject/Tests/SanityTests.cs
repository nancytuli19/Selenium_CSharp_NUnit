using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OnlineStoresProject.Tests;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoresProject.Core;

namespace OnlineStoresProject.Tests
{
    class SanityTests : BaseTest
    {
        [Test, Category("Sanity Test")]
        [Author("Nancy Tuli", "nancytuli19@gmail.com")]
        public void RedirectionToLoginPage()
        {
            test.AssignAuthor("Nancy Tuli");
            BrowserMethods.Goto(ConfigurationManager.AppSettings["url"]);
            BrowserMethods.getDriver.Manage().Window.Maximize();
            Assert.That(BrowserMethods.Title, Contains.Substring("ToolsQA Demo Site"));
            test.Log(LogStatus.Info, "Opened Browser");
            test.Log(LogStatus.Pass, TestContext.CurrentContext.Test.MethodName+ "Test Case passd");
        }

    }
}
