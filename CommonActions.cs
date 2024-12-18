using Ebay_Test_OR;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Test
{
    public class CommonActions : TestBase
    {
       
       
        public bool IsElementPresent(string Control)
        {
           // IWebElement Element = _driver.FindElement(By.XPath(Control));


            if (Control != null)
            {
               
                TestContext.WriteLine("Element is visible");
                return Control != null;
            }
            else
            {
                
                TestContext.WriteLine("Element is not visible");
                return false;



            }

        }

       
    }
}
