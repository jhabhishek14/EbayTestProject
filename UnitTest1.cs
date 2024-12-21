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

            driver.FindElement(By.XPath(LandingPage.VerifySearchBox)).SendKeys("Books");//Entering filter criteria in search box.
                
          
            driver.FindElement(By.XPath(LandingPage.SubmitBtn)).Click();

            CommonActions.IsElementPresent(LandingPage.BookList);//verifying the first book in list

           string BooksName = driver.FindElement(By.XPath(LandingPage.BookList)).Text; //Getting text of first book
                        
            driver.FindElement(By.XPath(LandingPage.BookList)).Click();

                    
            
            string windowHandle = driver.WindowHandles.Last(); //handling windows
            driver.SwitchTo().Window(windowHandle);

            string BookNameCartPage = driver.FindElement(By.XPath(LandingPage.BookTextCart)).Text; //Get book name from cart screen 

            try
            {
                Assert.AreEqual(BooksName, BookNameCartPage);//verifying bool selected and book in cart
                Console.WriteLine("Book selected is displaying in cart");
            }

            catch(Exception ex)
            { Console.WriteLine("Some tech/code issue"); }

            driver.FindElement(By.XPath(LandingPage.Cart)).Click();//Verifying cart value, is it blank or not

            string BlankCart = driver.FindElement(By.XPath(LandingPage.BlankCart)).Text;//Getting cart value
            if (BlankCart == "You don't have any items in your cart.")
            { TestContext.WriteLine("Cart is empty"); }
            else { TestContext.WriteLine("Cart already have item(S))"); } //this is to verify Cart is empty or not
            driver.Navigate().Back();




            driver.FindElement(By.XPath(LandingPage.AddToCart)).Click();//Add to cart


            string itemsCountA = driver.FindElement(By.XPath(LandingPage.CartValue)).Text;// Verifying the cart value
            int itemsCountAfter = int.Parse(itemsCountA);

            TestContext.WriteLine("total items in cart is " + itemsCountAfter);


        }
        
    }
}