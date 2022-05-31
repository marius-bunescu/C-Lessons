//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System.Threading;
//using System;
//using FirstTest.PageObjectModel;

//namespace FirstTest
//{
//    public class TestSetUp
//    {


//        public IWebDriver _driver;
//        public WebDriverWait _wait;


//        [SetUp]
//        public void Setup()
//        {
//            ChromeOptions options = new ChromeOptions();
//            options.AddArguments("--start-maximized");
//            options.AddArguments("--disable-extensions");
//            options.AddArguments("--disable-notifications");
//            options.AddArguments("--incognito");


//            _driver = new ChromeDriver(options);
//            _driver.Navigate().GoToUrl("https://projectplanappweb-stage.azurewebsites.net/");

//            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
//            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));


//            LoginPage loginPage = new LoginPage(_driver);
//            loginPage.ClickLoginButton();


//            EmailPage emailPage = new EmailPage(_driver, _wait);
//            emailPage.IntroduceEmail("AUTOMATION.PP@AMDARIS.COM");
//            emailPage.ClickSubmit();

//            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
//            passwordPage.IntroducePassword("10704-observe-MODERN-products-STRAIGHT-69112");
//            passwordPage.ClickSubmit();

//            SubmitPage submitPage = new SubmitPage(_driver, _wait);
//            submitPage.ClickSubmit();

//            MainPage mainPage = new MainPage(_driver, _wait);
//            mainPage.AssertLogin("Hi Automation");
//        }


//        [TearDown]
//        public void TearDown()
//        {
//            _driver.Close();
//            _driver.Quit();
//        }
//    }
//}


































