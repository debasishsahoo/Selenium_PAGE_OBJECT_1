//TestBase.cs
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ReportingLibrary;
using SeleniumHelperLibrary;
using System;
namespace Test
{
    [TestFixture]
    public abstract class TestBase
    {
        protected Browsers browser;
        protected Pages Pages;
        protected ExtentReportsHelper extent;
        [OneTimeSetUp]
        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
        }
        [SetUp]
        public void StartUpTest()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browser = new Browsers(extent);
            browser.Init();
            Pages = new Pages(browser, extent);
        }
        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        extent.AddTestFailureScreenshot(browser.getDriver.ScreenCaptureAsBase64String());
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                browser.Close();
            }
        }
        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                extent.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw (e);
            }
        }
    }
}