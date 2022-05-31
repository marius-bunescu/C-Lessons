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
    public class CollaborationPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public CollaborationPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement retrospectiveAddButton => _driver.FindElement(By.XPath("//div[@class='icon-btn ng-star-inserted']"));
        private IWebElement sprintName => _driver.FindElement(By.XPath("//input[@formcontrolname='sprintName']"));
        private IWebElement sprintRating => _driver.FindElement(By.XPath("//mat-select[@formcontrolname='sprintRating']"));
        private IWebElement mark => _driver.FindElement(By.XPath("//mat-option[5]/span"));
        private IWebElement improvements => _driver.FindElement(By.XPath("//textarea[@placeholder='Improvements']"));
        private IWebElement staus => _driver.FindElement(By.XPath("//mat-select[@formcontrolname='status']"));
        private IWebElement statusChoose => _driver.FindElement(By.XPath("//span[.=' In Progress ']"));
        private IWebElement submitButton => _driver.FindElement(By.XPath("//button[@type='submit']"));       
        private IWebElement deleteButton => _driver.FindElement(By.XPath("//mat-row[1]//i[2]"));
        private IWebElement confirmDelete => _driver.FindElement(By.XPath("//button[@attr.ui-automation-id='confirmationPopUpYesButton']")); 
        private IWebElement EditButon => _driver.FindElement(By.XPath("//mat-row[1]//i[1]"));
        private IWebElement notesTab => _driver.FindElement(By.XPath("//a[. = ' Notes ']"));
        private IWebElement textArea => _driver.FindElement(By.XPath("//textarea[@placeholder = 'Enter a note']"));
        private IWebElement notesAdd => _driver.FindElement(By.XPath("//span[. = 'Add Note']"));
        private IWebElement notesDelete => _driver.FindElement(By.XPath("//mat-row[3]//i[2]"));
        private By errorMessage => By.XPath("//mat-error");
        private By actualRating => By.XPath("//mat-row[1]/mat-cell[3]/span[2]");
        private By allertMessage => By.XPath("//span[.='Retrospective note added successfully.']");
        private By allertMessageDelete => By.XPath("//span[.='Retrospective note deleted successfully']");
        private By actualStatus => By.XPath("//mat-row[1]/mat-cell[5]/span[2]");


        public void AddRetrospective()
        {
            Thread.Sleep(1000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(retrospectiveAddButton)).Click();
            Thread.Sleep(1000);
        }

        public void ClickNotes()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(notesTab)).Click();
            Thread.Sleep(1000);
        }

        public void AddNote()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(notesAdd)).Click();
            
        }


        public void EnterNote(string note)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(textArea)).SendKeys(note);
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
            Thread.Sleep(1000);
        }

        public void DeleteNote()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(notesDelete)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(confirmDelete)).Click();
        }

        public void AddSprintName(string status)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(sprintName)).Clear();
            _wait.Until(ExpectedConditions.ElementToBeClickable(sprintName)).SendKeys(status);
        }

        public void AddSprintRating()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(sprintRating)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(mark)).Click();
        }

        public void AddImprovements(string improvementstext)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(improvements)).SendKeys(improvementstext);
        }

        public void ClickImprovements()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(improvements)).Click();
            Thread.Sleep(1000);
        }

        public void ClickSName()
        {
                _wait.Until(ExpectedConditions.ElementToBeClickable(sprintName)).Click();         
        }

        public void AddStatus()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(staus)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(statusChoose)).Click();
        }



        public void ClickEdit()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(EditButon)).Click();
        }

        public void ClickSubmit()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
            Thread.Sleep(1000);
        }

        

        public void CheckAdded(string expected)
        {

            string actualResult1 = _wait.Until(ExpectedConditions.ElementIsVisible(allertMessage)).Text;
            Assert.AreEqual(expected, actualResult1);
        }

        public void DeleteRetrospective()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteButton)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(confirmDelete)).Click();

        }

        public void CheckDeleted(string expected)
        {
            string actualResult2 = _wait.Until(ExpectedConditions.ElementIsVisible(allertMessageDelete)).Text;
            Assert.AreEqual(expected, actualResult2);
        }

        public void AssertAllert(string expectedError)
        {
            string actualError = _wait.Until(ExpectedConditions.ElementIsVisible(errorMessage)).Text;
            Assert.AreEqual(expectedError, actualError);
        }

        public void AssertSaveButton()
        {
            Assert.AreEqual("true", submitButton.GetAttribute("disabled"));    
        }

        public void CheckEdited(string expectedRating, string expectedStatus)
        {
            string _actualRating = _wait.Until(ExpectedConditions.ElementIsVisible(actualRating)).Text;
            Assert.AreEqual(expectedRating, _actualRating);

            string _actualStatus = _wait.Until(ExpectedConditions.ElementIsVisible(actualStatus)).Text;
            Assert.AreEqual(expectedStatus, _actualStatus);
        }
    }
}
