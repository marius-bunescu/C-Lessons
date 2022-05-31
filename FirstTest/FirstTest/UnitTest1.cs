//using FirstTest.PageObjectModel;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using SeleniumExtras.WaitHelpers;
//using System;
//using System.Threading;

//namespace FirstTest
//{
//    public class Tests : TestSetUp
//    {


//        [Test]
//        public void CollaborationsTest()
//        {



//            MainPage mainPage = new MainPage(_driver, _wait);
//            mainPage.AssertLogin("Hi Automation");
//            mainPage.AssertOverview();
//            mainPage.AssertProjectsButton();
//            mainPage.ClickProjects();


//            ProjectsTab projectsTab = new ProjectsTab(_driver, _wait);
//            projectsTab.IntroduceSearch("Amdaris Test");
//            projectsTab.ClickProject();
//            Thread.Sleep(4000);
//            projectsTab.ClickCollaboration();

//            CollaborationPage collaborationPage = new CollaborationPage(_driver, _wait);
//            Thread.Sleep(2000);
//            collaborationPage.AddRetrospective();
//            Thread.Sleep(1000);
//            collaborationPage.AddSprintName("status");
//            collaborationPage.AddSprintRating();
//            collaborationPage.AddImprovements("very well");
//            collaborationPage.AddStatus();
//            collaborationPage.ClickSubmit();
//            Thread.Sleep(1000);
//            collaborationPage.CheckAdded("Retrospective note added successfully.");
//            collaborationPage.DeleteRetrospective();
//            collaborationPage.CheckDeleted("Retrospective note deleted successfully");


//        }

//        [Test]
//        public void AddRemoveStakeholer()
//        {



//            MainPage mainPage = new MainPage(_driver, _wait);
//            mainPage.ClickProjects();

//            ProjectsTab projectsTab = new ProjectsTab(_driver, _wait);
//            projectsTab.AssertProjects();
//            projectsTab.IntroduceSearch("Amdaris Test");
//            projectsTab.ClickProject();
//            Thread.Sleep(4000);
//            projectsTab.ClickStakeholders();



//            StakeHolders stakeHolders = new StakeHolders(_driver, _wait);
//            stakeHolders.AddRemove();
//            stakeHolders.Search("Max");
//            stakeHolders.chooseStakeholder();
//            stakeHolders.clickSubmit();
//            stakeHolders.AssertAlert("Stakeholders updated successfully.");

//            stakeHolders.AddRemove();
//            stakeHolders.chooseStakeholder();
//            stakeHolders.clickSubmit();
//            stakeHolders.AssertAlert("Stakeholders updated successfully.");



//        }

//        [Test]
//        public void AddRemoveObjectives()
//        {



//            MainPage mainPage = new MainPage(_driver, _wait);
//            mainPage.ClickProjects();

//            ProjectsTab projectsTab = new ProjectsTab(_driver, _wait);
//            projectsTab.AssertProjects();
//            projectsTab.IntroduceSearch("Amdaris Test");
//            projectsTab.ClickProject();
//            Thread.Sleep(4000);
//            projectsTab.ClickObjectives();

//            BussinessObjectives bussinessObjectives = new BussinessObjectives(_driver, _wait);
//            bussinessObjectives.AddObjective();
//            Thread.Sleep(1000);
//            bussinessObjectives.EnterObjective("Objective Input");
//            bussinessObjectives.EnterOutput("Objective Output");
//            bussinessObjectives.ChooseStatus();
//            bussinessObjectives.ChoosePriority();
//            bussinessObjectives.ChooseDate();
//            bussinessObjectives.ClickSubmit();
//            bussinessObjectives.CheckAdded("Business Objective added successfully.");
//            bussinessObjectives.ResetFilters();
//            bussinessObjectives.DeteleObjective();
//            bussinessObjectives.CheckDeleted("Business objective deleted successfully");

//        }
//        [Test]
//        public void RiskRegister()
//        {


//            MainPage mainPage = new MainPage(_driver, _wait);
//            mainPage.ClickProjects();

//            ProjectsTab projectsTab = new ProjectsTab(_driver, _wait);
//            projectsTab.AssertProjects();
//            projectsTab.IntroduceSearch("Amdaris Test");
//            projectsTab.ClickProject();
//            Thread.Sleep(4000);
//            projectsTab.ClickRiskRegister();

//            RiskRegisterPage risk = new RiskRegisterPage(_driver, _wait);
//            Thread.Sleep(2000);
//            risk.AddRisk();
//            risk.AddType();
//            risk.AddTreatment();
//            risk.AddImpact();
//            risk.Addlikehood();
//            risk.AddDetails("New details");
//            risk.SaveChanges();
//            risk.DeleteRisk();
//            risk.ConfirmDelete();
//            risk.CheckDeleted("Project Risk deleted successfully");

//        }

//    }
//}