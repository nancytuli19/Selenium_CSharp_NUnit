using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OnlineStores.PageObjects;
using OnlineStoresProject.Tests;
using RelevantCodes.ExtentReports;
using OnlineStoresProject.Core;
using OnlineStoresProject.TestDataAccess;

namespace OnlineStoresProject
{
    public class SmokeTests : BaseTest
    {


        [Test, Category("Smoke Test")]
        [Author("Nancy Tuli", "nancytuli19@gmail.com")]
        public void LoginToTheApplicationWithCorrectCredentials()
        {
            test.AssignAuthor("Nancy Tuli");
            BrowserMethods.getDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            BrowserMethods.Goto(ConfigurationManager.AppSettings["url"]);
            test.Log(LogStatus.Info, "Opened Browser");
            BrowserMethods.getDriver.Manage().Window.Maximize();
            Assert.That(BrowserMethods.Title, Contains.Substring("ToolsQA Demo Site"));
            var homePage = new HomePage(BrowserMethods.getDriver);
            homePage.clickOnDismissButton();
            homePage.clickOnMyAccountTab();
            var userData = ExcelDataAccess.GetTestData("LoginTest");
            homePage.loginToApplicationWithCredentials(userData.Username, userData.Password);
            var accountPage = new MyAccountPage(BrowserMethods.getDriver);
            Assert.That(accountPage.getTextFromHelloTxt, Contains.Substring(String.Format("Hello {0}", userData.Username)));
            test.Log(LogStatus.Info, "Successfully login to the application");
            test.Log(LogStatus.Pass, TestContext.CurrentContext.Test.MethodName + "Test Case passed");
        }
    }
}
