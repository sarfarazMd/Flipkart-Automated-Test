using System;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FASTSelenium.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;

namespace FASTSelenium.BrowserFactory
{
   public class BrowserDriver
    {

        public static IWebDriver driver;// Initialization of Driver

        public static T GetPage<T>()//page pattern, Created a generaic page method which takes any pageobjects class as a parameter, Here T represents any type
        {
            var Pageclass = Activator.CreateInstance<T>();//Creating an instance of the specified type using constructor
            PageFactory.InitElements(driver, Pageclass);// InitElements is a static method that takes the driver instance of the given class type and return a page objects full of initialized 
            return Pageclass;
        }

        public static void LaunchBrowser(string BrowserName)
        {
            switch (BrowserName)
            {
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;                 
            }
        }

        public static void LoadApplication(string UrlName)
        {
            driver.Navigate().GoToUrl(UrlName);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            
        }

        public static void CloseApplication()
        {
            driver.Quit();
        }

        public static void Login()
        {
            FASTDriver.LaunchBrowser("Chrome");
            driver.Manage().Cookies.DeleteAllCookies();
            FASTDriver.LoadApplication(ConfigurationManager.AppSettings["LaunchFlipkart"]);
        }









        



    }
}
