using System;
using OpenQA.Selenium;


namespace TestProject1.TestPages
{
    public class AboutUsPage
    {
        private IWebDriver _driver;

        public AboutUsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By contentContainer = By.XPath("//div[@class=\"content\"]");
        public By linkLidership = By.XPath("//*[@id=\"featured-content-1425\"]/section/div[1]/p[2]/a");
        
        /*
         * Function checks a content container exists.
         */
        public Boolean iscontentContainerExists()
        {
            IWebElement contantContainerElement = _driver.FindElement(contentContainer);
            Boolean result = contantContainerElement.Text.Contains("Euromoney is run");
            return result;
        }

        /*
        * Function clicks lidership link and returns object manager team page class.
        */
        public ManagerTeamPage  clickLidershipLink()
        { 
            IWebElement lidershipElement = _driver.FindElement(linkLidership);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.querySelector('#featured-content-1425 > section > div.news-box.news-text-wrap.gg-taken.gg-g-2 > p.more-link > a').scrollIntoView();");

            lidershipElement.Click();
            
            return new ManagerTeamPage(_driver);
        }
    }
}