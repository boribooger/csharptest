using System;
using OpenQA.Selenium;

namespace TestProject1.TestPages
{
    public class OurBusinessPage
    {
        private IWebDriver _driver;

        public OurBusinessPage( IWebDriver driver)
        {
            _driver = driver;
        }

        private By containerDescriptionOurBusiness = By.XPath("//*[@id=\"conftext-1411\"]");
        private By dataAndMarketIntelegenceLink = By.XPath("//p[@class=\"more-link\"]/a[@href=\"/our-business/data-and-market-intelligence\"]");
        
        /*
         * Function checks a manager container description our business exists.
         */
        public Boolean isManagercontainerDescriptionOurBusinessExists()
        {
            IWebElement contantContainerElement = _driver.FindElement(containerDescriptionOurBusiness);
            Boolean result = contantContainerElement.Text.Contains("Euromoney is a global");
            return result;
        }

        /*
        * Function clicks link data and market intelegence and returns object
        * data and market intelegence page class.
        */
        public DataAndMarketIntelegencePage clickLinkDataAndMarketIntelegence()
        {
            IWebElement linkLidershipElement = _driver.FindElement(dataAndMarketIntelegenceLink);
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("document.querySelector('#conftext-1414 > p.more-link > a').scrollIntoView();");
            linkLidershipElement.Click();
            return new DataAndMarketIntelegencePage(_driver);
        }
    }
}