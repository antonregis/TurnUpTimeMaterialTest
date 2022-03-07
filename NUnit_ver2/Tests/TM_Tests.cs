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

        [Test, Order(1), Description("Check if user is able to create a material record w/ a valid data")]
        public void CreateTM_Test()
        {
            // Create Time & Material (TM) record in TM page
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);
        }

        [Test, Order(2), Description("Check if user is able to edit a material record w/ a valid data")]
        public void EditTM_Test()
        {
            // Edit TM record
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver);
        }

        [Test, Order(3), Description("Check if user is able to delete a material record")]
        public void DeleteTM_Test()
        {
            // Delete TM record
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTM(driver);
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}