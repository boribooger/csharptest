using System;
using System.Threading;
using OpenQA.Selenium;

namespace TestProject1.TestPages
{
    public class DataAndMarketIntelegencePage
    {
        private IWebDriver _driver;

        public DataAndMarketIntelegencePage( IWebDriver driver)
        {
            _driver = driver;
        }

        private By containerDescriptionDataAndMarketIntelegence = By.XPath("//div[@id=\"conftext-1565\"]/p");
        private By IJGlobalLink = By.XPath("//div[@id=\"conftext-1612\"]//a[@href=\"https://ijglobal.com/\"]");
        
        /*
        * Function checks a container description data and market intelegence exists.
        */
        
        public Boolean isContainerDescriptionDataAndMarketIntelegenceExists()
        {
            IWebElement webElementContainerDescriptionDataAndMarketIntelegence = 
                _driver.FindElement(containerDescriptionDataAndMarketIntelegence);
            Boolean result = 
                webElementContainerDescriptionDataAndMarketIntelegence.Text.Contains("The Data and Market");
            return result;
        }
        
        /*
        * Function checks a IJGlobal link exists.
        */
        public Boolean isIJGlobalLinkExists()
        {
            IWebElement webElementContainerDescriptionDataAndMarketIntelegence = 
                _driver.FindElement(IJGlobalLink);
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("document.querySelector('#conftext-1612 > p:nth-child(3) > a').scrollIntoView();");
            Boolean result = 
                webElementContainerDescriptionDataAndMarketIntelegence.GetAttribute("href").Contains("https://ijglobal.com/");
            return result;
        }

        /*
        * Function clicks link IJ Global and returns object IjglobalCom class.
        */
        public IjglobalCom clickLinkIJGlobal()
        {
            Thread.Sleep(1000);
            IWebElement linkIJGlobalElement = _driver.FindElement(IJGlobalLink);
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("document.querySelector('#conftext-1612 > p:nth-child(3) > a').scrollIntoView()");
            linkIJGlobalElement.Click();
            Thread.Sleep(3000);
            return new IjglobalCom(_driver);
        }
    }
}