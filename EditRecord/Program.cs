using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace EditRecord
{
    internal class EditRecord
    {
        static void Main(string[] args)
        {
            // Open chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Launch TurnUp portal/website
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // Identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // Click on login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            // Check if user is logged in successfully
            IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (hellohari.Text == "Hello hari!")
            {
                Console.WriteLine(" ■ Login successful, test passed");
            }
            else
            {
                Console.WriteLine(" ■ Login failed, test failed");
            }


            // Go to 'Time & Materials' page

            // Click Administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            // Select 'Time & Materials' from Administration dropdown
            IWebElement timeMaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterialsOption.Click();

            // Click Create button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            // Click Typecode dropdown
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typecodeDropdown.Click();

            // Select Material from TypeCode dropdown
            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[contains(text(),'Time')]"));
            materialOption.Click();

            // Input Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("PT022");

            // Input Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Titanium");

            // Input Price
            IWebElement unusualPriceTextboxLayer = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            unusualPriceTextboxLayer.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("47.87");

            // Click Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            // Delay 2 second to complete page loading so that lastpageButton can be found
            Thread.Sleep(2000);


            // Go to last page of the table to load newly entered Material data

            // Click 'Go to the last page' button
            IWebElement lastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpageButton.Click();

            // Delay 1 second to complete page loading to load needed elements
            Thread.Sleep(1000);

            // Check if Material record input is correct
            IWebElement codeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            if ((codeValue.Text == "PT022") && (descriptionValue.Text == "Titanium") && (priceValue.Text == "$47.87"))
            {
                Console.WriteLine(" ■ Material data matched expected value, test passed");
            }
            else
            {
                Console.WriteLine(" ■ Material data mismatched expected value, test failed");
            }


            // Edit record

            // Click edit on previously entered Material record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td/a[1]"));
            editButton.Click();

            // Delay 1 second to complete page loading
            Thread.Sleep(1000);

            // Edit Code
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("PT024");

            // Edit Description
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Chromium");

            // Edit Price
            IWebElement editUnusualPriceTextboxLayer = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editUnusualPriceTextboxLayer.Click();

            IWebElement editPriceTextbox = driver.FindElement(By.Id("Price"));
            editPriceTextbox.Clear();
            editUnusualPriceTextboxLayer.Click();
            editPriceTextbox.SendKeys("52.00");

            // Click Save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            // Delay 2 second to complete page loading so that lastpageButton can be found
            Thread.Sleep(2000);

            // Go to last page of the table to load newly entered Material data

            // Click 'Go to the last page' button
            IWebElement editLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            editLastpageButton.Click();

            // Delay 1 second to complete page loading to load needed elements
            Thread.Sleep(1000);

            // Check if Material record input is correct
            IWebElement editCodeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editDescriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editPriceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            if ((editCodeValue.Text == "PT024") && (editDescriptionValue.Text == "Chromium") && (editPriceValue.Text == "$52.00"))
            {
                Console.WriteLine(" ■ Edited Material record matched expected value, test passed");
            }
            else
            {
                Console.WriteLine(" ■ Edited Material record mismatched expected value, test failed");
            }


            // Quit driver
            //driver.Quit();
        }
    }
}