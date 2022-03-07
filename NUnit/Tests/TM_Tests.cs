using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TimeMaterialTest.Utilities;

namespace TimeMaterialTest.Pages
{

    [TestFixture]
    internal class TM_Tests: CommonDriver
    {
        [OneTimeSetUp]
        //[SetUp]
        public void LoginFunctions()
        {
            // Open chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login to website
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Click from home page: Administration > Time & Materials
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [Test]
        public void T01_CreateTM_Test()
        {
            // Create Time & Material (TM) record in TM page
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);
        }

        [Test]
        public void T02_EditTM_Test()
        {
            // Edit TM record
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver);
        }

        [Test]
        public void T03_DeleteTM_Test()
        {
            // Delete TM record
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTM(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {

        }
    }
}