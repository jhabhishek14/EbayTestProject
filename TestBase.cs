using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Ebay_Test
{
    public class TestBase
    {
        public IWebDriver driver;//{ get; private set; }

       

        [OneTimeSetUp]
        public  void BrowserLaunch()
        {

           // new WebDriverManager.drivermanager().setupdriver(new chromeconfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }

        //CommonActions CommonActions;
        //LandingPage LandingPage = new LandingPage();


        [OneTimeTearDown]
        public void TearDown()
        {
           driver.Quit();
        }


    }
    


}
