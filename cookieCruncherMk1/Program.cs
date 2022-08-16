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
            bool isActive = true;
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://orteil.dashnet.org/cookieclicker/test/";

            while (isActive) {
                CookieClicker(driver);
                ProductPurchase(driver);
                UpgradePurchase(driver);
            }

            driver.Quit();

        }

      static void CookieClicker(IWebDriver driver)
        {
            IWebElement cookieImage = driver.FindElement(By.Id("bigCookie"));
            cookieImage.Click();
        }

        static void ProductPurchase(IWebDriver driver)
        {
            IWebElement product0 = driver.FindElement(By.Id("product0"));
            IWebElement product1 = driver.FindElement(By.Id("product1"));
            IWebElement product2 = driver.FindElement(By.Id("product2"));
            IWebElement product3 = driver.FindElement(By.Id("product3"));
            IWebElement product4 = driver.FindElement(By.Id("product4"));
            IWebElement product5 = driver.FindElement(By.Id("product5"));
            IWebElement product6 = driver.FindElement(By.Id("product6"));
            IWebElement product7 = driver.FindElement(By.Id("product7"));
            IWebElement product8 = driver.FindElement(By.Id("product8"));
            IWebElement product9 = driver.FindElement(By.Id("product9"));
            IWebElement product10 = driver.FindElement(By.Id("product10"));
            IWebElement product11 = driver.FindElement(By.Id("product11"));
            IWebElement product12 = driver.FindElement(By.Id("product12"));
            IWebElement product13 = driver.FindElement(By.Id("product13"));
            IWebElement product14 = driver.FindElement(By.Id("product14"));

            List<IWebElement> products = new List<IWebElement>
            {
                product0,product1,product2,product3,product4,product5,product6,product7
                ,product8,product9,product10,product11,product12, product13,product14

            };

            for (int i = 14; i >= 0; i--)
            {
                string classOfP = products[i].GetAttribute("class");

                if (classOfP =="product unlocked enabled")
                {
                    products[i].Click();
                }
             
            }

        }
     
        static void UpgradePurchase(IWebDriver driver)
        {

        IWebElement parentElem = driver.FindElement(By.Id("upgrades"));
        var upgrades = parentElem.FindElements(By.XPath("./child::*"));
        
        for(int i = 0; i < upgrades.Count; i++)
            {
                try
                {

                string classOfU = upgrades[i].GetAttribute("class");

                if (classOfU == "crate upgrade enabled")
                {
                upgrades[i].Click();
                }
                }
                catch {break; }
            }

            

        }
    }
}
