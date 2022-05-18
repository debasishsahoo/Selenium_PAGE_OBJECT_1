using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
namespace Test
{
    [TestFixture]
    public class MyFirstTest : TestBase
    {
        [Test]
        public void NopCommerceDummyTest()
        {
            Pages.Home.isAt();
            Pages.Home.GoToComputers();
            Pages.Computers.isAt();
            Pages.Computers.EnterSearchText("Search for me");
            Pages.Computers.ClickSearch();
        }
    }
}
