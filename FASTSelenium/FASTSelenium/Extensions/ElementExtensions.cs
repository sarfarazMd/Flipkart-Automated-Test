using OpenQA.Selenium;
using FASTSelenium.Reports;
using FASTSelenium.Common;


namespace FASTSelenium.Extensions
{
   public static class ElementExtensions
    {
        public static void FASetText(this IWebElement element, string text)
        {
            
            element.Clear();
            element.SendKeys(text);
            ReportLoger.CaptureScreenShot(FASTDriver.driver, "Screenshot");


        }


    }
}
