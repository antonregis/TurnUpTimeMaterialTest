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
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Option 1
            Assert.That(codeValue.Text == "PT022", "Material record mismatched expected value, test failed");

            //// Option 2. This is another way to do assertion.
            //if ((codeValue.Text == "PT022") && (descriptionValue.Text == "Titanium") && (priceValue.Text == "$47.87"))
            //{
            //    Assert.Pass("Material record matched expected value, test passed");
            //}
            //else
            //{
            //    Assert.Fail("Material record mismatched expected value, test failed");
            //}

            //// Option 3
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

            // Click edit on previously entered Material record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td/a[1]"));
            editButton.Click();

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
            IWebElement lastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpageButton.Click();

            // Waiting for the page to load (particularly the last row @ Price column)
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 2);

            // Check if Material record input is correct
            IWebElement codeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            
            // Option 1
            Assert.That(codeValue.Text == "PT024", "Edited Material record mismatched expected value, test failed");

            //// Option 2
            //if ((codeValue.Text == "PT024") && (descriptionValue.Text == "Chromium") && (priceValue.Text == "$52.00"))
            //{
            //    Console.WriteLine(" ■ Edited Material record matched expected value, test passed");
            //}
            //else
            //{
            //    Console.WriteLine(" ■ Edited Material record mismatched expected value, test failed");
            //}

            //Console.WriteLine(codeValue.Text);
            //Console.WriteLine(descriptionValue.Text);
            //Console.WriteLine(priceValue.Text);
        }

        public void DeleteTM(IWebDriver driver)
        {
            // Delete record

            // Delete previously entered record
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td/a[2]"));
            deleteButton.Click();

            // Click Ok to PopUp Alert
            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();
           
            // Delaying to give time for the loading animation to finish
            Thread.Sleep(1000);

            // Check deleted Material record is still there
            IWebElement codeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement descriptionValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Option 1
            Assert.That(codeValue.Text != "PT024", "Material record not deleted, test failed");

            //// Option 2
            //if ((codeValue.Text != "PT024") && (descriptionValue.Text != "Chromium") && (priceValue.Text != "$52.00"))
            //{
            //    Console.WriteLine(" ■ Material record deleted, test passed");
            //}
            //else
            //{
            //    Console.WriteLine(" ■ Material record not deleted, test failed");
            //}

            //Console.WriteLine(codeValue.Text);
            //Console.WriteLine(descriptionValue.Text);
            //Console.WriteLine(priceValue.Text);
        }
    }
}
