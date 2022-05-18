//SeleniumHelperLibrary.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReportingLibrary;
using System;
using WaitHelpers = SeleniumExtras.WaitHelpers;
namespace SeleniumHelperLibrary
{
    public static class WebElementExtension
    {
        public static bool ControlDisplayed(this IWebElement element, IWebDriver driver, ExtentReportsHelper extentReportsHelper, string elementName, bool displayed = true, uint timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return wait.Until(drv =>
            {
                if (!displayed && !element.Displayed || displayed && element.Displayed)
                {
                    extentReportsHelper.SetStepStatusPass($"[{elementName}] is displayed on the page.");
                    return true;

                }
                extentReportsHelper.SetStepStatusPass($"[{elementName}] is displayed on the page.");
                return false;
            });
        }
        public static void ClearWrapper(this IWebElement element, ExtentReportsHelper extentReportsHelper, string elementName)
        {
            element.Clear();
            if (element.Text.Equals(string.Empty))
            {
                extentReportsHelper.SetStepStatusPass($"Cleared element [{elementName}] content.");
            }
            else
            {
                extentReportsHelper.SetStepStatusWarning($"Element [{elementName}] content is not cleared. Element value is [{element.Text}]");
            }
        }
        public static bool ElementlIsClickable(this IWebElement element, IWebDriver driver, ExtentReportsHelper extentReportsHelper, string elementName, uint timeoutInSeconds = 60, bool displayed = true)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv =>
                {
                    if (WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                    {
                        extentReportsHelper.SetStepStatusPass($"Element [{elementName}] is clickable.");
                        return true;
                    }
                    extentReportsHelper.SetStepStatusWarning($"Element [{elementName}] is not clickable.");
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }
        public static void ClickWrapper(this IWebElement element, IWebDriver driver, ExtentReportsHelper extentReportsHelper, string elementName)
        {
            if (element.ElementlIsClickable(driver, extentReportsHelper, elementName))
            {
                element.Click();
                extentReportsHelper.SetStepStatusPass($"Clicked on the element [{elementName}].");
            }
            else
            {
                throw new Exception($"Element [{elementName}] is not displayed");
            }
        }
        public static void SendKeysWrapper(this IWebElement element, ExtentReportsHelper extentReportsHelper, string value, string elementName)
        {
            element.SendKeys(value);
            extentReportsHelper.SetStepStatusPass($"SendKeys value [{value}] to  element [{elementName}].");
        }
        public static bool ValidatePageTitle(this IWebDriver driver, ExtentReportsHelper extentReportsHelper, string title, uint timeoutInSeconds = 300)
        {
            bool result = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return result = wait.Until(drv =>
            {
                if (drv.Title.Contains(title))
                {
                    extentReportsHelper.SetStepStatusPass($"Page title [{drv.Title}] contains [{title}].");
                    return true;
                }
                extentReportsHelper.SetStepStatusWarning($"Page title [{drv.Title}] does not contain [{title}].");
                return false;
            });
        }
        public static bool ValidateURLContains(this IWebDriver driver, ExtentReportsHelper extentReportsHelper, string urlPart, uint timeoutInSeconds = 120)
        {
            bool result = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return result = wait.Until(drv =>
            {
                if (drv.Url.Contains(urlPart))
                {
                    extentReportsHelper.SetStepStatusPass($"Page URL [{drv.Url}] contains [{urlPart}].");
                    return true;
                }
                extentReportsHelper.SetStepStatusWarning($"Page URL [{drv.Url}] does not contain [{urlPart}].");
                return false;
            });
        }
    }
}