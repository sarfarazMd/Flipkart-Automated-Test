using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FASTSelenium.PageObjects
{
    public class FlipKartLoginPage
    {

        [FindsBy(How = How.XPath, Using = "//input[@class='_2IX_2- VJZDxU']")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='_2IX_2- _3mctLh VJZDxU']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='_2KpZ6l _2HKlqd _3AWRsL']")]
        public IWebElement LoginButton { get; set; }
    }
}
