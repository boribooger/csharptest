using System;
using System.Threading;
using OpenQA.Selenium;

namespace TestProject1.TestPages
{
    public class IjglobalCom
    {
        private IWebDriver _driver;
        private By iJGlobalTable = By.XPath("//section[@class=\"league-tables\"]");
        private By tableItem = By.XPath("//*[@id=\"leagueTable\"]/tbody/tr[1]/td[2]");
        public IjglobalCom( IWebDriver driver)
        {
            _driver = driver;
        }
        
        /*
        * Function checks a url IJGlobal is displayed correctly.
        */
        public Boolean isUrlIJGlobal()
        {
            String url = _driver.Url;
            Boolean result = url.Contains("ijglobal");
            return result;
        }
        
        /*
        * Function checks a IJGlobal project finance league table exists.
        */
        public Boolean isIJGlobalProjectFinanceLeagueTableExists()
        {
            Thread.Sleep(4000);
            IWebElement iJGlobalProjectFinanceLeagueTable = _driver.FindElement(iJGlobalTable);
            IWebElement itemFromTable = 
                iJGlobalProjectFinanceLeagueTable.FindElement(tableItem);
            Boolean result = 
                itemFromTable.Text.Contains("Sumitomo Mitsui Financial Group");
            return result;
        }
    }
}