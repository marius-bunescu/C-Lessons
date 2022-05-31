using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.PageObjectModel
{
    public class SubmitPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public SubmitPage(IWebDriver driver, WebDriverWait wait)
        {

            _driver = driver;
            _wait = wait;
        }

        private IWebElement submitButton => _driver.FindElement(By.XPath("//input[@type='submit']"));


        public void ClickSubmit() => _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        
            
        
    }
}
