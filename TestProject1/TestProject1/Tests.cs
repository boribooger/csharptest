using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestProject1.TestPages;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private AboutUsPage _aboutUsPage;
        private DataAndMarketIntelegencePage _dataAndMarketIntelegencePage;
        private IjglobalCom _ijglobalCom;
        private ManagerTeamPage _managerTeamPage;
        private OurBusinessPage _ourBusinessPage;
        
        
        [SetUp]
        public void SetUp()
        {
            //This option allows to open pages in one tab.
            var options = new FirefoxOptions();
            options.SetPreference("browser.link.open_newwindow", 1);               
            _driver = new FirefoxDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.euromoneyplc.com");
        }

        [Test]
        public void story1ManagerDataIsDisplayedCorrectly()
        {
            _homePage = new HomePage(_driver);
            _aboutUsPage = _homePage.clickAboutUsPage();
            _managerTeamPage = _aboutUsPage.clickLidershipLink();
            Boolean result = _managerTeamPage.checkingAllManagersHaveNameJobTitlePhotoDescription();
            Assert.True(result);
        }
        
        [Test]
        public void story2isIJGlobalLinkExistsOnEuromoneyplcCom()
        {
            _homePage = new HomePage(_driver);
            _ourBusinessPage = _homePage.clickOurBusiness();
            _dataAndMarketIntelegencePage = _ourBusinessPage.clickLinkDataAndMarketIntelegence();
            Boolean result = _dataAndMarketIntelegencePage.isIJGlobalLinkExists();
            Assert.True(result);
        }
        
        [Test]
        public void story2LinkIjglobalComGoesToValidPage()
        {
            _homePage = new HomePage(_driver);
            _ourBusinessPage = _homePage.clickOurBusiness();
            _dataAndMarketIntelegencePage = _ourBusinessPage.clickLinkDataAndMarketIntelegence();
            _ijglobalCom = _dataAndMarketIntelegencePage.clickLinkIJGlobal();
            Boolean result = _ijglobalCom.isUrlIJGlobal();
            Assert.True(result);
        }
        
        [Test]
        public void story2IjglobalComHasProjectFinanceLeagueTable()
        {
            _homePage = new HomePage(_driver);
            _ourBusinessPage = _homePage.clickOurBusiness();
            _dataAndMarketIntelegencePage = _ourBusinessPage.clickLinkDataAndMarketIntelegence();
            _ijglobalCom = _dataAndMarketIntelegencePage.clickLinkIJGlobal();
            Boolean result = _ijglobalCom.isIJGlobalProjectFinanceLeagueTableExists();
            Assert.True(result);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }    
}