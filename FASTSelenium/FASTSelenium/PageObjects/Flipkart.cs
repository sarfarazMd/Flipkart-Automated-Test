using System;
using FASTSelenium.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace FASTSelenium.PageObjects
{
  public class Flipkart 
    {
        [FindsBy(How =How.Name,Using = "q")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How =How.XPath,Using = "//button[@type='submit']")]
        public IWebElement SearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'mobile')]")]
        public IWebElement ResultOnSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search Brand']")]
        public IWebElement SearchBrands { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Gionee')]//preceding::div[1]")]
        public IWebElement BrandsCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'2 GB')]//preceding::div[1]")]
        public IWebElement Ramcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='_151IuQ']")]
        public IWebElement CancelBrandFilter { get; set; }

        public void WaitForScreenToLoad()
        {
            WebDriverWait wait = new WebDriverWait(FASTDriver.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(),'Filters')]")));
        }

        

    }



}
