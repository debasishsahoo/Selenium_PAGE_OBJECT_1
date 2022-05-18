using ReportingLibrary;
using SeleniumExtras.PageObjects;
using System;
namespace Test
{
    public class Pages
    {
        public Pages(Browsers browser, ExtentReportsHelper extentReportsHelper)
        {
            _browser = browser;
            _extentReportsHelper = extentReportsHelper;
        }
        Browsers _browser { get; }
        ExtentReportsHelper _extentReportsHelper { get; set; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.getDriver, _extentReportsHelper);
            PageFactory.InitElements(_browser.getDriver, page);
            return page;
        }
        public Home Home => GetPages<Home>();
        public Computers Computers => GetPages<Computers>();
    }
}