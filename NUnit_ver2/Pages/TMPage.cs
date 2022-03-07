using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeMaterialTest.Utilities;

namespace TimeMaterialTest.Pages
{
    internal class TMPage
    {
        public void CreateTM(IWebDriver driver) 
        {
            // Create record
            
            // Click Create button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            // Click Typecode dropdown
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typecodeDropdown.Click();

            // Waiting for Material option to be visible
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TypeCode_listbox']/li[contains(text(),'Material')]", 2);

            // Select Material from TypeCode dropdown
            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[contains(text(),'Material')]"));
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

            // Waiting for the page to load (particularly the first row @ Code column) 
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            // Click 'Go to the last page' button
            IWebElement lastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpageButton.Click();

            // Waiting for the page to load (particularly the last row @ Price column)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 2);

            // Check if Material record input is correct
            IWebElement codeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement typecodeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion - Option 1
            Assert.That(codeValue.Text == "PT022", "Code mismatched expected value, test failed");
            Assert.That(typecodeValue.Text == "M", "TypeCode mismatched expected value, test failed");
            Assert.That(descriptionValue.Text == "Titanium", "Description mismatched expected value, test failed");
            Assert.That(priceValue.Text == "$47.87", "Price mismatched expected value, test failed");

            //// Assertion - Option 2. This is another way to do assertion.
            //if ((codeValue.Text == "PT022") && (descriptionValue.Text == "Titanium") && (priceValue.Text == "$47.87"))
            //{
            //    Assert.Pass("Material record matched expected value, test passed");
            //}
            //else
            //{
            //    Assert.Fail("Material record mismatched expected value, test failed");
            //}

            //// Assertion - Option 
            //if ((codeValue.Text == "PT022") && (descriptionValue.Text == "Titanium") && (priceValue.Text == "$47.87"))
            //{
            //    Console.WriteLine(" ■ Material record matched expected value, test passed");
            //}
            //else
            //{
            //    Console.WriteLine(" ■ Material record mismatched expected value, test failed");
            //}

            //Console.WriteLine(codeValue.Text);
            //Console.WriteLine(descriptionValue.Text);
            //Console.WriteLine(priceValue.Text);
        }

        public void EditTM(IWebDriver driver)
        {
            // Edit record      

            // Refresh page and click 'Go to the last page' button
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            IWebElement lastpage1Button = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage1Button.Click();

            // Waiting for the page to load (particularly the last row @ Price column)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 2);
 
            // Verifying if the record to edit exist
            IWebElement descValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (descValue.Text == "Titanium") 
            {
                // Click edit on previously entered Material record
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td/a[1]"));
                editButton.Click();
            }
            else 
            {
                Assert.Fail("Record to edit not found");
            }

            // Waiting for Code textbox to be visible
            Wait.WaitToBeVisible(driver, "Id", "Code", 2);

            // Edit Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("PT024");

            // Edit Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("Chromium");

            // Edit Price
            IWebElement unusualPriceTextboxLayer = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            unusualPriceTextboxLayer.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.Clear();
            unusualPriceTextboxLayer.Click();
            priceTextbox.SendKeys("52.00");

            // Click Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            // Waiting for the page to load (particularly the first row @ Code column) 
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            // Click 'Go to the last page' button
            IWebElement lastpage2Button = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage2Button.Click();

            // Waiting for the page to load (particularly the last row @ Price column)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 2);

            // Check if Material record input is correct
            IWebElement codeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement typecodeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            
            // Assertion
            Assert.That(codeValue.Text == "PT024", "Edited Code mismatched expected value, test failed");
            Assert.That(typecodeValue.Text == "M", "Edited TypeCode mismatched expected value, test failed");
            Assert.That(descriptionValue.Text == "Chromium", "Edited Description mismatched expected value, test failed");
            Assert.That(priceValue.Text == "$52.00", "Edited Price mismatched expected value, test failed");
        }

        public void DeleteTM(IWebDriver driver)
        {
            // Delete record

            // Click 'Go to the last page' button
            IWebElement lastpage3Button = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage3Button.Click();

            // Waiting for the page to load (particularly the last row @ Price column)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 2);

            // Verifying if the record to edit exist
            IWebElement descValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (descValue.Text == "Chromium")
            {
                // Click delete previously entered record
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td/a[2]"));
                deleteButton.Click();

                // Click Ok to PopUp Alert
                driver.SwitchTo().Alert().Accept();

                // Delaying to give time for the loading animation to finish
                Thread.Sleep(1000);
            }
            else
            {
                Assert.Fail("Record to delete not found");
            }

            // Refresh page and click 'go to the last page' 
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            IWebElement lastpage4Button = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage4Button.Click();

            // Waiting for the page to load (particularly the last row @ Price column)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 2);

            // Check deleted Material record is still there or not
            IWebElement codeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(codeValue.Text != "PT024", "Material record not deleted, test failed");
            Assert.That(descriptionValue.Text != "Chromium", "Edited Description mismatched expected value, test failed");
            Assert.That(priceValue.Text != "$52.00", "Edited Price mismatched expected value, test failed");
        }
    }
}
