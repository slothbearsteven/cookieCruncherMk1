using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace cookieCruncherMk1
{
    class program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://orteil.dashnet.org/cookieclicker/test/";

            driver.Quit();

        }

        void CookieClicker(IWebDriver driver)
        {


        }
     
    }
}
