using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Core;

namespace UnitTestProject1.Tests
{
    [TestFixture]
    public class BaseTest: BrowserMethods
    {
        public static ExtentReports extent = null;
        public static ExtentTest test = null;


        [OneTimeSetUp]
        public void SetupReporting()
        {
            try
            {
                if (extent == null)
                {
                    extent = ExtentReport.generateExtentReport();
                }
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            try
            {
                ExtentReport.flushReport();
            }
            catch(Exception E)
            {
                throw (E);
            }
        }

        [SetUp]
        public void startTest()
        {
            try
            {
                test = extent.StartTest(TestContext.CurrentContext.Test.MethodName + " started");
                BrowserMethods.Init();
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        [TearDown]
        public void endTest()
        {
            try
            {

                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var testMethod = TestContext.CurrentContext.Test.FullName;
                if (status == TestStatus.Failed)
                {
                    var errorMessage = TestContext.CurrentContext.Result.Message;
                    ExtentReport.addScreenshotToReport(status, errorMessage, testMethod);
                }

                Close();
            }
            catch(Exception e)
            {
                throw (e);
            }
        }
    }
}
