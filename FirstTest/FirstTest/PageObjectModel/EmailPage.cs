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
    public class EmailPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public EmailPage(IWebDriver driver, WebDriverWait wait)
        {

            _driver = driver;
            _wait = wait;
        }

        IWebElement emailButton => _driver.FindElement(By.XPath("//input[@name='loginfmt']"));
        IWebElement submitButton => _driver.FindElement(By.XPath("//input[@type='submit']"));
        
        public void IntroduceEmail(string email) => _wait.Until(ExpectedConditions.ElementToBeClickable(emailButton)).SendKeys(email);

        public void ClickSubmit() => _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();

    }
}
