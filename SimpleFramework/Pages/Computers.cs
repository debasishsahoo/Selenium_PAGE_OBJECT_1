using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Test
{
    public class Computers
    {
        public Computers()
        {
            driver = null;
        }
        public Computers(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        //Driver
        IWebDriver driver;
        //Locators
        [FindsBy(How = How.Id, Using = "small-searchterms")]
        private IWebElement SearchInput;
        [FindsBy(How = How.XPath, Using = "//input[@value='Search']")]
        private IWebElement SearchButton;
        //Actions
        public Computers isAt()
        {
            Assert.IsTrue(driver.Title.Equals("nopCommerce demo store. Computers"));
            return this;
        }
        public Computers EnterSearchText(string searchText)
        {
            SearchInput.SendKeys(searchText);
            return this;
        }
        public Computers ClickSearch()
        {
            SearchButton.Click();
            return this;
        }
    }
}