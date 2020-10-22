using System;
using OpenQA.Selenium;

namespace TestProject1.TestPages
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage( IWebDriver driver)
        {
            _driver = driver;
        }

        private By menuwrap = By.XPath("//div[@class=\"row menuwrap\"]");
        private By aboutUs = By.XPath("//li[@class=\"we-mega-menu-li dropdown-menu\"]/a[@href=\"/about-us\"]");
        private By ourBusiness = By.XPath("//a[@href=\"/our-business\"]");
        

        public Boolean isHeaderExists()
        {
            IWebElement footer = _driver.FindElement(menuwrap);
            Boolean result = footer.Text.Contains("Investors");
            return result;
        }

        /*
        * Function clicks link About Us and returns object
        * About Us page class.
        */
        public AboutUsPage clickAboutUsPage()
        {
            IWebElement footeElementAboutUs = _driver.FindElement(aboutUs);
            footeElementAboutUs.Click();
            return new AboutUsPage(_driver);
        }  
        
        /*
        * Function clicks link Our Business and returns object
        * Our Business page class.
        */
        public OurBusinessPage clickOurBusiness()
        {
            IWebElement headerElementOurBusiness = _driver.FindElement(ourBusiness);
            headerElementOurBusiness.Click();
            return new OurBusinessPage(_driver);
        }
    }
}