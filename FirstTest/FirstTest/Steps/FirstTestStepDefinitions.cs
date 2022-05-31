
using FirstTest.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FirstTest
{



    [Binding]
    public  class FirstTestStepDefinitions
    {


        LoginPage _loginPage = null;
        EmailPage _emailPage = null;
        PasswordPage _passwordPage = null;
        SubmitPage _submitPage = null;
        ProjectsTab _projectsTab = null;
        StakeHolders _stakeHolders = null;
        MainPage _mainPage = null;
        CollaborationPage _collaborationPage = null;
        BussinessObjectives _bussinessObjectives = null;
        RiskRegisterPage _riskRegisterPage = null;

        public IWebDriver _driver;
        public WebDriverWait _wait;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {


            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--incognito");


            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("https://projectplanappweb-stage.azurewebsites.net/");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        }


        //---------------------------------------------------
        [Given(@"I am loged in with credentials")]
        public void GivenIAmLogedInWithCredentials(Table table)
        {


            dynamic data = table.CreateDynamicInstance();

            _loginPage = new LoginPage(_driver);
            _emailPage = new EmailPage(_driver, _wait);
            _passwordPage = new PasswordPage(_driver, _wait);
            _submitPage = new SubmitPage(_driver, _wait);

            _loginPage.ClickLoginButton();
            _emailPage.IntroduceEmail((string)data.email);
            _emailPage.ClickSubmit();
            _passwordPage.IntroducePassword((string)data.password);
            _passwordPage.ClickSubmit();
            _submitPage.ClickSubmit();

           
        }



        [Given(@"i enter Projects page")]
        public void GivenIEnterProjectsPage()
        {
            _mainPage = new MainPage(_driver, _wait);
            _projectsTab = new ProjectsTab(_driver, _wait);

            _mainPage.ClickProjects();
            _projectsTab.IntroduceSearch("Amdaris");
            _projectsTab.ClickProject();

        }

        [Given(@"i click on Stakeholders Tab")]
        public void GivenIClickOnStakeholdersTab()
        {
            _projectsTab.ClickStakeholders();
        }

        [When(@"I search steakholder's name")]
        public void WhenISearchSteakholdersName()
        {
            _stakeHolders = new StakeHolders(_driver, _wait);

            _stakeHolders.SearchStakeholder("Ecaterina");
        }

        [Then(@"the stakeholder appears on the screen")]
        public void ThenTheCheckholderAppearsOnTheScreen()
        {
            _stakeHolders.AssertStakeholder("ecaterina.vizdoaga@amdaris.com");
        }

        //---------------------------------------------

        [Given(@"I'm in Collaboration tab")]
        public void GivenImInCollaborationTab()
        {
            _mainPage = new MainPage(_driver, _wait);
            _projectsTab = new ProjectsTab(_driver, _wait);

            _mainPage.ClickProjects();
            _projectsTab.IntroduceSearch("Amdaris");
            _projectsTab.ClickProject();
            _projectsTab.ClickCollaboration();
        }

        [Given(@"i click edit button")]
        public void GivenIClickEditButtonButton()
        {
            _collaborationPage = new CollaborationPage(_driver, _wait);
            _collaborationPage.ClickEdit();
        }

        [Given(@"i change  sprint rating")]
        public void GivenIChangeSprintRating()
        {
            _collaborationPage.AddSprintRating();
        }

        [Given(@"i change  status")]
        public void GivenIChangeStatus()
        {
            _collaborationPage.AddStatus();
        }

        [When(@"i press Save button")]
        public void WhenIPressSaveButton()
        {
            _collaborationPage.ClickSubmit();
        }

        [Then(@"the changes are saved")]
        public void ThenTheChangesAreSaved()
        {
            _collaborationPage.CheckEdited("4", "In Progress");
        }
        //----------------------------------------------------------

        [Given(@"I click Add Retrospective")]
        public void GivenIClickAddRetrospective()
        {
            _collaborationPage = new CollaborationPage(_driver, _wait);
            _collaborationPage.AddRetrospective();
        }

        [Given(@"I don't introduce any symbols")]
        public void GivenIDontIntroduceAnySymbols()
        {

            _collaborationPage.ClickImprovements();
            _collaborationPage.AddSprintName("da");


        }
        [Then(@"i get the error message")]
        public void ThenIGetTheErrorMessage()
        {
            _collaborationPage.AssertAllert("Field is required");
        }
        //-----------------------------------------------------
        [Given(@"i change the retrospective name in the same one")]
        public void GivenIChangeTheRetrospectiveNameInTheSameOne()
        {
            _collaborationPage.AddSprintName("Sprint ER3");
        }

        [Then(@"the save button should not activate")]
        public void ThenTheSaveButtonShouldNotActivate()
        {
            _collaborationPage.AssertSaveButton();
        }

        //---------------------------------------------------

        [Given(@"I click on notes tab")]
        public void GivenIClickOnNotesTab()
        {
            _collaborationPage = new CollaborationPage(_driver, _wait);
            _collaborationPage.ClickNotes();
        }

        [Given(@"I click add note")]
        public void GivenIClickAddNote()
        {
            _collaborationPage.AddNote();
        }

        [Given(@"I save the note")]
        public void GivenISaveTheNote()
        {
            _collaborationPage.EnterNote("dadadad");
        }

        [Then(@"i delete the note")]
        public void ThenIDeleteTheNote()
        {
            _collaborationPage.DeleteNote();
        }

        //-------------------------------------------
        [Given(@"I add a retrospective note")]
        public void GivenIAddARetrospectiveNote()
        {
            _collaborationPage = new CollaborationPage(_driver, _wait);
            _collaborationPage.AddSprintName("status");
            _collaborationPage.AddSprintRating();
            _collaborationPage.AddImprovements("very well");
            _collaborationPage.AddStatus();
            _collaborationPage.ClickSubmit();
            _collaborationPage.CheckAdded("Retrospective note added successfully.");
        }

        [Then(@"i delete the retrospective note")]
        public void ThenIDeleteTheRetrospectiveNote()
        {
            _collaborationPage.DeleteRetrospective();
            _collaborationPage.CheckDeleted("Retrospective note deleted successfully");
        }

        //---------------------------------------------

        [Given(@"I add stakeholder")]
        public void GivenIAddStakeholder()
        {
            _stakeHolders = new StakeHolders(_driver, _wait);
            _stakeHolders.AddRemove();
            _stakeHolders.Search("Max");
            _stakeHolders.chooseStakeholder();
            _stakeHolders.clickSubmit();
            _stakeHolders.AssertAlert("Stakeholders updated successfully.");
        }

        [Then(@"I detele the stakeholder")]
        public void ThenIDeteleTheStakeholder()
        {
            _stakeHolders.AddRemove();
            _stakeHolders.chooseStakeholder();
            _stakeHolders.clickSubmit();
            _stakeHolders.AssertAlert("Stakeholders updated successfully.");
        }
//---------------------------------------------------------------
        [Given(@"I'm in Objectives tab")]
        public void GivenImInObjectivesTab()
        {
            _projectsTab = new ProjectsTab(_driver, _wait);
            _bussinessObjectives = new BussinessObjectives(_driver, _wait);
            _projectsTab.ClickObjectives();
        }

        [Given(@"I add an objective")]
        public void GivenIAddAnObjective()
        {
            _bussinessObjectives.AddObjective();
            _bussinessObjectives.EnterObjective("Objective Input");
            _bussinessObjectives.EnterOutput("Objective Output");
            _bussinessObjectives.ChooseStatus();
            _bussinessObjectives.ChoosePriority();
            _bussinessObjectives.ChooseDate();
            _bussinessObjectives.ClickSubmit();
            _bussinessObjectives.CheckAdded("Business Objective added successfully.");
        }

        [Then(@"I delete the objective")]
        public void ThenIDeleteTheObjective()
        {
            _bussinessObjectives.ResetFilters();
            _bussinessObjectives.DeteleObjective();
            _bussinessObjectives.CheckDeleted("Business objective deleted successfully");
        }
 //-----------------------------------------------------
        [Given(@"i enter Risk tab")]
        public void GivenIEnterRiskTab()
        {
            _projectsTab = new ProjectsTab(_driver, _wait);
            _riskRegisterPage = new RiskRegisterPage(_driver, _wait);
            _projectsTab.ClickRiskRegister();
        }

        [Given(@"i add a risk")]
        public void GivenIAddARisk()
        {
            _riskRegisterPage.AddRisk();
            _riskRegisterPage.AddType();
            _riskRegisterPage.AddTreatment();
            _riskRegisterPage.AddImpact();
            _riskRegisterPage.Addlikehood();
            _riskRegisterPage.AddDetails("New details");
            _riskRegisterPage.SaveChanges();
        }

        [Then(@"i delete the risk")]
        public void ThenIDeleteTheRisk()
        {
            _riskRegisterPage.DeleteRisk();
            _riskRegisterPage.ConfirmDelete();
            _riskRegisterPage.CheckDeleted("Project Risk deleted successfully");
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

    }
}
