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
    public class RiskRegisterPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public RiskRegisterPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement riskButton => _driver.FindElement(By.XPath("//div[@class='icon-btn ng-star-inserted']"));

        private IWebElement typeButton => _driver.FindElement(By.XPath("//span[.='Type']"));
        private IWebElement typeChoose => _driver.FindElement(By.XPath("//span[.=' Internal ']"));

        private IWebElement treatmentButton => _driver.FindElement(By.XPath("//span[.='Treatment']"));
        private IWebElement treatmentChoose => _driver.FindElement(By.XPath("//span[.=' Transfer ']"));

        private IWebElement impactButton => _driver.FindElement(By.XPath("//span[.='Impact']"));
        private IWebElement impactChoose => _driver.FindElement(By.XPath("//span[.=' High ']"));

        private IWebElement likelihoodButton => _driver.FindElement(By.XPath("//span[.='Likelihood']"));
        private IWebElement likelihoodChoose => _driver.FindElement(By.XPath("//span[.=' Medium ']"));

        private IWebElement detailsButton => _driver.FindElement(By.XPath("//div[4]//textarea"));

        private IWebElement deleteButton => _driver.FindElement(By.XPath("//mat-row[1]//i[2]"));

        private IWebElement submitButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        private IWebElement confirmButton => _driver.FindElement(By.XPath("//button[@attr.ui-automation-id='confirmationPopUpYesButton']"));

        private By allertMessage => By.XPath("//span[.='Project Risk deleted successfully']");

        public void AddRisk()
        {
            Thread.Sleep(1000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(riskButton)).Click();
        }

        public void AddType()
        {
            
            _wait.Until(ExpectedConditions.ElementToBeClickable(typeButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(typeChoose)).Click();
        }

        public void AddTreatment()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(treatmentButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(treatmentChoose)).Click();
        }

        public void AddImpact()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(impactButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(impactChoose)).Click();
        }

        public void Addlikehood()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(likelihoodButton)).Click();
            Thread.Sleep(1000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(likelihoodChoose)).Click();
        }

        public void AddDetails(string details)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(detailsButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(detailsButton)).SendKeys(details);
        }

        public void SaveChanges()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        }
        public void DeleteRisk()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteButton)).Click();
        }
        public void ConfirmDelete()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(confirmButton)).Click();
        }
        public void CheckDeleted(string expected)
        {
            string actualResult1 = _wait.Until(ExpectedConditions.ElementIsVisible(allertMessage)).Text;
            Assert.AreEqual(expected, actualResult1);
        }
    }
}
