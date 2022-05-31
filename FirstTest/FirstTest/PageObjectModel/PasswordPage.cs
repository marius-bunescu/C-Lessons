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
    public class PasswordPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public PasswordPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private By passwordButton => By.Name("passwd");
        private IWebElement submitButton => _driver.FindElement(By.XPath("//input[@type='submit']"));

        public void IntroducePassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(passwordButton)).SendKeys(password);

        }
        public void ClickSubmit()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        }
    }
}
