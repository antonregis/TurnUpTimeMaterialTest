using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeMaterialTest.Utilities;

namespace TimeMaterialTest.Pages
{
    internal class HomePage
    {
        public void GoToTMPage(IWebDriver driver) 
        {
            // Go to 'Time & Materials' page

            // Click Administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 2);
            
            // Select 'Time & Materials' from Administration dropdown
            IWebElement timeMaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterialsOption.Click();
        }
    }
}
