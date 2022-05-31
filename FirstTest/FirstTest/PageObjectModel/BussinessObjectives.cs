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
     public class BussinessObjectives
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public BussinessObjectives(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement addButton => _driver.FindElement(By.XPath("//span[.='Add Business Objective']"));
        private By enterObjective => By.Id("mat-input-1");
        private By enterOutput => By.Id("mat-input-2");

        private IWebElement statusButton => _driver.FindElement(By.XPath("//div/div/div[1]/div[1]/mat-form-field/div/div[1]/div"));
        private IWebElement achievedStatus => _driver.FindElement(By.XPath("//span[.=' Achieved ']"));

        private IWebElement priorityButton => _driver.FindElement(By.XPath("//div/div/div/div/div[1]/div[2]/mat-form-field/div/div[1]/div"));
        private IWebElement mediumPriority => _driver.FindElement(By.XPath("//span[.=' Medium ']"));

        private IWebElement deadlineButton => _driver.FindElement(By.XPath("//*[@id='deadline']"));
        private IWebElement date => _driver.FindElement(By.XPath("//div[.=' 31 ']"));

        private IWebElement submitButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        private IWebElement resetFilter => _driver.FindElement(By.XPath("//app-select-with-native//mat-icon"));
        private IWebElement deleteObjective => _driver.FindElement(By.XPath("//mat-row[5]//i[2]"));
        private IWebElement deleteConfirm => _driver.FindElement(By.XPath("//button[@attr.ui-automation-id='confirmationPopUpYesButton']"));
        private By checkAllert => By.XPath("//span[.='Business objective deleted successfully']");
        private By checkAdd => By.XPath("//span[.='Business Objective added successfully.']");

        public void AddObjective()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(addButton)).Click();
        }

        public void EnterObjective(string objective)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(enterObjective)).SendKeys(objective);
        }
        public void EnterOutput(string output)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(enterOutput)).SendKeys(output);
        }

        public void ChooseStatus()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(statusButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(achievedStatus)).Click();
        }
        public void ChoosePriority()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(priorityButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(mediumPriority)).Click();
        }
        public void ChooseDate()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deadlineButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(date)).Click();
        }
        
        public void ClickSubmit()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        }
        public void ResetFilters()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(resetFilter)).Click();
        }
        public void DeteleObjective()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteObjective)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteConfirm)).Click();
        }
        public void CheckAdded(string expected)
        {
            string actualResult1 = _wait.Until(ExpectedConditions.ElementIsVisible(checkAdd)).Text;
            Assert.AreEqual(expected, actualResult1);
        }
        public void CheckDeleted(string expected)
        {
            string actualResult2 = _wait.Until(ExpectedConditions.ElementIsVisible(checkAllert)).Text;
            Assert.AreEqual(expected, actualResult2);
        }

    }

}
