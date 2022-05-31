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
    public class ProjectsTab
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public  ProjectsTab(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement searchBar => _driver.FindElement(By.XPath("//input[@class='input-search']"));
        private IWebElement _projectName => _driver.FindElement(By.XPath("//a[.='Amdaris Test']"));
        private IWebElement stakeholders => _driver.FindElement(By.XPath("//a[.=' Stakeholders ']"));
        private IWebElement projectsNumber => _driver.FindElement(By.XPath("//div[@class='num']"));
        private IWebElement tabName => _driver.FindElement(By.CssSelector("#main-scrollbar > div > div > div > div > main > app-project-tabs > div:nth-child(2) > app-project-stakeholder > div > div > div > div.title-and-button > app-breadcrumbs > div > ul > li:nth-child(2) > h4"));
        private IWebElement objectives => _driver.FindElement(By.XPath("//a[.=' Business Objectives ']"));
        private IWebElement riskRegister => _driver.FindElement(By.XPath("//a[.=' Risk Register ']"));
        private IWebElement collaborations => _driver.FindElement(By.XPath("//a[8]"));

        public void IntroduceSearch(string projectName)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchBar)).SendKeys(projectName);
        }
        
        public void ClickProject()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_projectName)).Click();
            Thread.Sleep(2000);
        }

        public void ClickStakeholders()
        {      
            _wait.Until(ExpectedConditions.ElementToBeClickable(stakeholders)).Click();
        }
        
        public void AssertProjects()
        {
            Thread.Sleep(5000);
            string numberOfProjects = projectsNumber.Text;
            Assert.GreaterOrEqual(Convert.ToInt32(numberOfProjects), 1);
        }
        public void CheckIfInStakeholders(string expectedTab)
        {
            string actualTab = tabName.Text;
            Assert.AreEqual(expectedTab, actualTab );
        }

        public void ClickObjectives()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(objectives)).Click();
        }
        public void ClickRiskRegister()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(riskRegister)).Click();
        }
       public void ClickCollaboration()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(collaborations)).Click();
        }
    }
}
