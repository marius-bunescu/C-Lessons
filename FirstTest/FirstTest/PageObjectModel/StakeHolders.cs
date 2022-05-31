using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTest.PageObjectModel
{
    public class StakeHolders
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public StakeHolders(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement addButton => _driver.FindElement(By.XPath("//span[.='Add/Remove Stakeholders']"));
        private IWebElement searchBar => _driver.FindElement(By.CssSelector("#mat-tab-content-0-0 > div > div > div > div > div > input"));       
        private IWebElement stakeHolder => _driver.FindElement(By.XPath("//span[.='max test']"));
        private IWebElement submitButton => _driver.FindElement(By.XPath("//button[@type='submit']"));
        private By allertPopup => By.XPath("//span[.='Stakeholders updated successfully.']");
        private IWebElement stakeholdersearch => _driver.FindElement(By.XPath("//input[@attr.ui-automation-id='projectsStakeholdersSearchBar']"));
        private By stakeholderEmail => By.XPath("//span[.='ecaterina.vizdoaga@amdaris.com']");

        public void AddRemove()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(addButton)).Click();
        }

        public void Search(string stakeholder)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchBar)).SendKeys(stakeholder);
        }
        public void SearchStakeholder(string name)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(stakeholdersearch)).SendKeys(name);
        }

        public void chooseStakeholder()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(stakeHolder)).Click();
        }
        public void clickSubmit()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        }

        public void AssertAlert(string expected )
        {
            string actualResult1 = _wait.Until(ExpectedConditions.ElementIsVisible(allertPopup)).Text;
            Assert.AreEqual(expected, actualResult1);
        }

        public void AssertStakeholder(string expected)
        {
            string actualResult2 = _wait.Until(ExpectedConditions.ElementIsVisible(stakeholderEmail)).Text;
            Assert.AreEqual(expected, actualResult2);
        }
    }
}
