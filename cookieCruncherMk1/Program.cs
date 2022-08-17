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
            Console.WriteLine("How many iterations shall be ran?");

            int maxIterations = int.Parse(Console.ReadLine());
            int currentIteration = 0;

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://orteil.dashnet.org/cookieclicker/test/";

            Setup(driver);

            while (isActive)
            {
                CookieClicker(driver);
                ProductPurchase(driver);
                UpgradePurchase(driver);
                currentIteration++;
                if (currentIteration >= maxIterations) { isActive = false; }
            }

            driver.Close();

        }

      static void CookieClicker(IWebDriver driver)
        { //gets the cookie image the user can click on, and continually clicks on it once called
            IWebElement cookieImage = driver.FindElement(By.Id("bigCookie"));
            cookieImage.Click();
        }

        static void ProductPurchase(IWebDriver driver)
        { //Finds all products, which are found in HTML at start of game, then adds them to a list object
            IWebElement parentElem = driver.FindElement(By.Id("products"));
            var products = parentElem.FindElements(By.XPath("./child::*"));

            for (int i = 14; i >= 0; i--)
            {
                //iterates through the list, and checks if the current product can be bought, and buys it if able
                string classOfP = products[i].GetAttribute("class");

                if (classOfP =="product unlocked enabled")
                {
                    products[i].Click();
                }
             
            }

        }
     
        static void UpgradePurchase(IWebDriver driver)
        {
        //Finds the current amount of the upgrades available, as they change based on the products purchased
        IWebElement parentElem = driver.FindElement(By.Id("upgrades"));
        var upgrades = parentElem.FindElements(By.XPath("./child::*"));
        

            //iterates through the upgrades, checking if any of them can be bought, and if able buys the upgrade
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

        static void Setup(IWebDriver driver)
        {
            IWebElement bakeryNameButton = driver.FindElement(By.Id("bakeryName"));
            bakeryNameButton.Click();

            IWebElement nameInput = driver.FindElement(By.Id("bakeryNameInput"));
            IWebElement confirmButton = driver.FindElement(By.Id("promptOption0"));

            nameInput.Clear();

            nameInput.SendKeys("Selenium");

            confirmButton.Click();
        }
    }
}
