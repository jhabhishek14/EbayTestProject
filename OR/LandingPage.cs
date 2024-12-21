using Ebay_Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay_Test_OR
{
    public class LandingPage : TestBase
    {

        public static string VerifySearchBox => "//input[@type='text']";
        public static string SubmitBtn => "//input[@type='submit']";

        public static string BookList => "//span[@role='heading']/following::span[@role='heading'][2]";

        public static string  BookTextCart => "//h1[@class='x-item-title__mainTitle']";

        public static string AddToCart => "//a[@id='atcBtn_btn_1']";

        public static string CartValue => "//i[@id='gh-cart-n']";

        public static string Cart => "//li[@id='gh-minicart-hover']";

        public static string BlankCart => "//span[@class='text-display-span']/span/span";

        //h1[@class='x-item-title__mainTitle']
    }

}













