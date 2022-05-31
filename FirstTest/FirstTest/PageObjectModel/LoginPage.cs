using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace FirstTest.PageObjectModel
{
    public class LoginPage
    {

        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

       IWebElement loginButton => _driver.FindElement(By.CssSelector("body > app-root > app-login > div > div.main > div"));

        public  void ClickLoginButton() => loginButton.Click();
        
    }
}
