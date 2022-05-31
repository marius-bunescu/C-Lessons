using NUnit.Framework;
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
    public class MainPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private By succesfullLogin => By.XPath("//*[.='Hi Automation']");
       
        private By projectsButton => By.Id("projects-tab");

        private By overviewButton => By.Id("overview-tab");

        public void ClickProjects()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(projectsButton))).Click();
        }


        public void AssertLogin(string expectedResult)
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(succesfullLogin)).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }


        public void AssertProjectsButton()
        {
            Assert.IsTrue(_wait.Until(ExpectedConditions.ElementIsVisible(projectsButton)).Displayed);
        }

        public void AssertOverview()
        {
            Assert.IsNotNull(_wait.Until(ExpectedConditions.ElementIsVisible(overviewButton)));
        }

    }
}
