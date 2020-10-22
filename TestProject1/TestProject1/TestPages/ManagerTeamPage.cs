using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace TestProject1.TestPages
{
    public class ManagerTeamPage
    {
        private IWebDriver _driver;
        
        private By managersContainerElement =  By.XPath("class=\"row mainWrapperT t2_bod_wrap\"");
        private By managerPictureElement = By.XPath("//div[@class=\"bod-image-placeholder\"]");
        private By managerNameElement = By.XPath("//div[@class=\"bod-title\"]");
        private By managerJobTitleElement = By.XPath("//div[@class=\"bod-position\"]");
        private By managerDescriptionElement = By.XPath("//div[@class=\"bod-inner-content\"]/p[3]");
        
        public ManagerTeamPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /*
        * Function checks a managers container exists.
        */
        public Boolean isManagersContainerElementExist()
        {
            IWebElement webElement = _driver.FindElement(managersContainerElement);
            Boolean result = webElement.Text.Contains("Director");
            return result;
        }

        /*
        * Function checks all managers have name, job title, photo, description.
        */
        public Boolean checkingAllManagersHaveNameJobTitlePhotoDescription()
        {
            HashSet<Boolean> managerContentIsDispayedCorrectly = new HashSet<Boolean>();
            Boolean result = false;
            
            //create lists for names, pictures, job titles, description
            ReadOnlyCollection<IWebElement> picturesWebElements = 
                new ReadOnlyCollection<IWebElement>(_driver.FindElements(managerPictureElement));
            
            ReadOnlyCollection<IWebElement> namesWebElements = 
                new ReadOnlyCollection<IWebElement>(_driver.FindElements(managerNameElement));
            
            ReadOnlyCollection<IWebElement> jobTitleWebElements = 
                new ReadOnlyCollection<IWebElement>(_driver.FindElements(managerJobTitleElement));
            
            ReadOnlyCollection<IWebElement> desctiptionWebElements = 
                new ReadOnlyCollection<IWebElement>(_driver.FindElements(managerDescriptionElement));

            managerContentIsDispayedCorrectly.UnionWith(checkingWebElement(picturesWebElements, "picture"));
            managerContentIsDispayedCorrectly.UnionWith(checkingWebElement(namesWebElements, "name, jobTitle, description"));
            managerContentIsDispayedCorrectly.UnionWith(checkingWebElement(jobTitleWebElements, "name, jobTitle, description"));
            managerContentIsDispayedCorrectly.UnionWith(checkingWebElement(desctiptionWebElements, "name, jobTitle, description"));
            

            if (managerContentIsDispayedCorrectly.Count == 1 && managerContentIsDispayedCorrectly.Contains(true))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            
            return result;

        }

        /*
        * Function checks web elements name, pictures, job title, description aren't empty.
        */
        private HashSet<Boolean> checkingWebElement(ReadOnlyCollection<IWebElement> arrayWebElements,
            String typeOfArrayElement)
        {
            HashSet<Boolean> hashSet = new HashSet<Boolean>();
            
            switch(typeOfArrayElement){
                case "picture": 
                    foreach (IWebElement managerWebElement in arrayWebElements)
                    {
                        Boolean res = managerWebElement.GetAttribute("style").Contains("sites");
                        hashSet.Add(res);
                    }
                    break;
                case "name, jobTitle, description": 
                    foreach (IWebElement managerWebElement in arrayWebElements)
                    {
                        String res = managerWebElement.Text;
                        if (res != null)
                        {
                            hashSet.Add(true);
                        }
                        else
                        {
                            hashSet.Add(false);

                        }
                    }
                    break;                
                case "jobTitle": 
                    foreach (IWebElement managerWebElement in arrayWebElements)
                    {
                        Boolean res = managerWebElement.GetAttribute("style").Contains("sites");
                        hashSet.Add(res);
                    }
                    break;                
                case "description": 
                    foreach (IWebElement managerWebElement in arrayWebElements)
                    {
                        Boolean res = managerWebElement.GetAttribute("style").Contains("sites"); 
                        hashSet.Add(res);
                    }
                    break;
            }
            return hashSet;
        }
    }
}