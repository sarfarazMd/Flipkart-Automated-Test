using System;
using FASTSelenium.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace FASTSelenium.Reports
{
    [TestClass]
    public class ReportLoger
    {
        static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("index"+DateTime.Now.ToString("yyyyMMddHHmmss")+".html");
        static ExtentReports extent = new ExtentReports();

        [TestInitialize]
        public static void Setup()
        {
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Operating System: ", "Win 10");  
            extent.AddSystemInfo("HostName: ", "Computer Name");
            extent.AddSystemInfo("Browser: ", "Chrome");
        }
        public static string CaptureScreenShot(IWebDriver driver, string ScreenshotName)
        {

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)FASTDriver.driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string Uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshot\\" + "ScreenshotName" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string localpath = new Uri(Uptobinpath).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
        [TestMethod]
        public static void PassTestMethod(string userName)
        {
            
            string screenshotPath = CaptureScreenShot(FASTDriver.driver, "Screenshot");
            var test = extent.CreateTest("<div style='color:green;font -weight :bold'>PassTestMethod</div>", "<h3>This test method gets passed</h3>");
            test.Log(Status.Info, "<h4>First step of PassedTestMethod for </h4> " + userName);
            test.Pass("<div style='color:green;font -weight :bold'> Test Passed</div>");
            test.AddScreenCaptureFromPath(screenshotPath, "Login Screenshot");
        }

        [TestMethod]
        public static void PassTestMethod(string userName,string brandName,string productName,string productSpec)
        {

            string screenshotPath = CaptureScreenShot(FASTDriver.driver, "Screenshot");
            var test = extent.CreateTest("<div style='color:green;font -weight :bold'>PassTestMethod</div>", "<h3>This test method gets passed</h3>");
            test.Log(Status.Info, "<h4>First step of PassedTestMethod for </h4> " + userName+"Passed For brand "+brandName+" and for Product "+productName+" with Specification"+productSpec);
            test.Pass("<div style='color:green;font -weight :bold'> Test Passed</div>");
            test.AddScreenCaptureFromPath(screenshotPath, "Login Screenshot");
        }

        [TestMethod]
        public static void FailTestMethod(string userName,Exception ex)
        {
            string screenshotPath = CaptureScreenShot(FASTDriver.driver, "Screenshot");
            var test = extent.CreateTest("<div style='color:red;font -weight :bold'>FailTestMethod</div>", "This test method gets Failed");
            test.Log(Status.Info, "<h4>First step of FailedTestMethod for</h4> " + userName);
            test.Log(Status.Info, "<h4>First step of FailedTestMethod reason</h4> " + ex);
            test.Fail("Test Failed");
            test.AddScreenCaptureFromPath(screenshotPath, "Login Screenshot");
        }

        [TestMethod]
        public static void FailTestMethod(string userName, string brandName, string productName, string productSpec, Exception ex)
        {
            string screenshotPath = CaptureScreenShot(FASTDriver.driver, "Screenshot");
            var test = extent.CreateTest("<div style='color:red;font -weight :bold'>FailTestMethod</div>", "This test method gets Failed");
            test.Log(Status.Info, "<h4>First step of FailedTestMethod for</h4> " + userName+ "Failed For brand " + brandName + " and for Product " + productName + " with Specification" + productSpec);
            test.Log(Status.Info, "<h4>First step of FailedTestMethod reason</h4> " + ex);
            test.Fail("Test Failed");
            test.AddScreenCaptureFromPath(screenshotPath, "Login Screenshot");
        }


        [TestCleanup]
        //[OneTimeTearDown]
        public static void Cleanup()
        {
            extent.Flush();
        }

    }
}
