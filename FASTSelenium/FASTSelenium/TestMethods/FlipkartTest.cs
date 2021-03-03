using System;
using FASTSelenium.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;
using FASTSelenium.Extensions;
using FASTSelenium.Reports;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Interactions;


namespace FASTSelenium
{
    [TestClass]
    public class FlipkartTest
    {

        string userName;
        string brandName = "Gionee";
        string productName = "Gionee Max (Royal Blue, 32 GB)";
        string productSpec = "2 GB RAM | 32 GB ROM | Expandable Upto 256 GB";
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                ReportLoger.Setup();              
                FASTDriver.Login();

                userName = ConfigurationManager.AppSettings["UserName"];
                FASTDriver.FlipKartLoginPage.UserName.SendKeys(userName);
                FASTDriver.FlipKartLoginPage.Password.FASetText(ConfigurationManager.AppSettings["Password"]);              
                FASTDriver.FlipKartLoginPage.LoginButton.Click();              
                Thread.Sleep(3000);
                FASTDriver.Flipkart.SearchBox.SendKeys(ConfigurationManager.AppSettings["SearchValue"]);            
                FASTDriver.Flipkart.SearchBar.Click();
                Thread.Sleep(3000);

                FASTDriver.Flipkart.Ramcheckbox.Click();
                FASTDriver.Flipkart.WaitForScreenToLoad();

                IJavaScriptExecutor scrolldown = (IJavaScriptExecutor)FASTDriver.driver;
                scrolldown.ExecuteScript("window.scrollBy(0,220)", "");

                FASTDriver.Flipkart.SearchBrands.SendKeys(brandName);
                Actions action = new Actions(FASTDriver.driver);
                action.MoveToElement(FASTDriver.Flipkart.BrandsCheckbox);
                FASTDriver.Flipkart.BrandsCheckbox.Click();
                Thread.Sleep(5000);
                
                IWebElement FirstRowResult =FASTDriver.driver.FindElement(By.XPath("//div[@class='_4rR01T']"));
                string FirstRowResultText = FirstRowResult.Text;
                if (FirstRowResultText.Contains(brandName))
                {
                    Assert.AreEqual(productName, FirstRowResultText);
                    ReportLoger.CaptureScreenShot(FASTDriver.driver, "First Row Contains Brand name as Gionee");                 
                }
               
                IList<IWebElement> Alllist = FASTDriver.driver.FindElements(By.TagName("li"));
                foreach(var item in Alllist)
                {
                    if(item.Text.Contains(productSpec))
                    {
                        Assert.AreEqual("2 GB RAM | 32 GB ROM | Expandable Upto 256 GB", productSpec);
                        ReportLoger.CaptureScreenShot(FASTDriver.driver, "First RowContains Ram as 2GBRAM");
                        break;
                    }
                }
                FASTDriver.Flipkart.CancelBrandFilter.Click();
                FASTDriver.Flipkart.WaitForScreenToLoad();
                ReportLoger.PassTestMethod(userName,brandName,productName,productSpec);

            }
            catch (Exception ex)
            {
                ReportLoger.FailTestMethod(userName,brandName,productName,productSpec, ex);
            }

            finally
            {
                ReportLoger.Cleanup();
                FASTDriver.CloseApplication();
            }
         
        }
    }
}

