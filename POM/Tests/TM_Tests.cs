using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TimeMaterialTest.Pages
{
    internal class TM_Tests
    {
        static void Main(string[] args)
        {
            // Open chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login to website
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Click from home page: Administration > Time & Materials
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // Create Time & Material (TM) record in TM page
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);

            // Edit TM record
            tMPageObj.EditTM(driver);

            // Delete TM record
            tMPageObj.DeleteTM(driver);
        }
    }
}