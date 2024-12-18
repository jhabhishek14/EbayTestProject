using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using System.Linq.Expressions;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.DevTools.V129.Audits;
using OpenQA.Selenium.Support.UI;
using Ebay_Test_OR;
using OpenQA.Selenium.Interactions;

namespace Ebay_Test
{
    public class Tests : TestBase
    {
        CommonActions CommonActions = new CommonActions();
        LandingPage LandingPage;
        
        [SetUp]
        public void Setup()
        {
            

            string url = "https://www.ebay.com";
            driver.Navigate().GoToUrl(url);
            string SearchBox = LandingPage.VerifySearchBox;

            if (CommonActions.IsElementPresent(SearchBox))
            {
                TestContext.WriteLine("user is on landing page");

            }
            else { TestContext.WriteLine("navigation to landing page failed"); }

        }

        [Test]
                
        public void VerifyList()
        {

            driver.FindElement(By.XPath(LandingPage.VerifySearchBox)).SendKeys("Books");
                
          
            driver.FindElement(By.XPath(LandingPage.SubmitBtn)).Click();

            CommonActions.IsElementPresent(LandingPage.BookList);//verifying the first book in list

                        
            driver.FindElement(By.XPath(LandingPage.BookList)).Click();

                    
            
            string windowHandle = driver.WindowHandles.Last(); //handling windows
            driver.SwitchTo().Window(windowHandle);



            driver.FindElement(By.XPath(LandingPage.Cart)).Click();

            string BlankCart = driver.FindElement(By.XPath(LandingPage.BlankCart)).Text;
            if (BlankCart == "You don't have any items in your cart.")
            { TestContext.WriteLine("Cart is empty"); }
            else { TestContext.WriteLine("Cart already have item(S))"); } //this is to verify Cart is empty or not
            driver.Navigate().Back();




            driver.FindElement(By.XPath(LandingPage.AddToCart)).Click();

            string itemsCountA = driver.FindElement(By.XPath(LandingPage.CartValue)).Text;// Verifying the cart value
            int itemsCountAfter = int.Parse(itemsCountA);

            TestContext.WriteLine("total items in cart is " + itemsCountAfter);


        }
        
    }
}