using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OnlineStores.PageObjects;
using RelevantCodes.ExtentReports;
using UnitTestProject1.Core;
using UnitTestProject1.TestDataAccess;
using UnitTestProject1.Tests;

namespace UnitTestProject1
{
    public class UnitTest1 : BaseTest
    {


        [Test, Category("Sanity Testing")]
        [Author("Nancy Tuli", "nancytuli19@gmail.com")]
        public void TestMethod1()
        {
            test.AssignAuthor("Nancy Tuli");
            /*NUnit.Framework.TestContext.Progress.WriteLine("The url is " + ConfigurationManager.AppSettings["url"]);
           */
            BrowserMethods.Goto(ConfigurationManager.AppSettings["url"]);
            test.Log(LogStatus.Info, "Opened Browser");
            BrowserMethods.getDriver.Manage().Window.Maximize();
            var homePage = new HomePage(BrowserMethods.getDriver);
            homePage.Dismiss.Click();
            homePage.MyAccount.Click();
            var userData = ExcelDataAccess.GetTestData("LoginTest");
            homePage.UserName_txtBox.SendKeys(userData.Username);
            homePage.Passwd_txtBox.SendKeys(userData.Password);
            homePage.Login_btn.Click();
            test.Log(LogStatus.Info, "Entered Credentials");
            test.Log(LogStatus.Pass, "Test Case passd");
        }
    }
}
