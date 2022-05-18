using NUnit.Framework;
using OpenQA.Selenium;
using ReportingLibrary;
using SeleniumExtras.PageObjects;
using SeleniumHelperLibrary;
namespace Test
{
    public class Home
    {
        public Home()
        {
            driver = null;
            extentReportsHelper = null;
        }
        public Home(IWebDriver webDriver, ExtentReportsHelper reportsHelper)
        {
            driver = webDriver;
            extentReportsHelper = reportsHelper;
        }




        //Driver
        private IWebDriver driver;
        private ExtentReportsHelper extentReportsHelper;
        //Locators
        [FindsBy(How = How.XPath, Using = "//ul[@class='top-menu notmobile']//a[@href='/computers']")]
        private IWebElement ComputersLink;
        //Actions
        public Home isAt()
        {
            Assert.IsTrue(driver.ValidatePageTitle(extentReportsHelper, "nopCommerce demo store"));
            return this;
        }
        public Home GoToComputers()
        {
            ComputersLink.ClickWrapper(driver, extentReportsHelper, "Computers link");
            return this;
        }
    }
}