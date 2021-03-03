using FASTSelenium.PageObjects;


namespace FASTSelenium.Common 
{
   public class FASTDriver : BrowserFactory.BrowserDriver
    {
        public static Flipkart Flipkart => GetPage<Flipkart>();

        public static FlipKartLoginPage FlipKartLoginPage => GetPage<FlipKartLoginPage>();

    }


}


// To add config we have to add system configuration. selecte reference and do right click and click on Add Reference and add system configuration.


