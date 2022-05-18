//SeleniumHelperLibrary.cs
using OpenQA.Selenium;
namespace SeleniumHelperLibrary
{
    public static class WebDiverExtensions
    {
        public static string ScreenCaptureAsBase64String(this IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}