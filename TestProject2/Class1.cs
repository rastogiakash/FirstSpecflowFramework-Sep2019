using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestProject2
{
    public class Class1
    {
        [Test]
        public void contactUs_Test()
        {
            // Launch Browser
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Softwares\drivers", "geckodriver.exe");
            IWebDriver driver = new FirefoxDriver(service);

            // Navigate to the URL
            System.Threading.Thread.Sleep(100);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");

            // Select a value from Subject Heading from dropdown - id_contact
            var option = driver.FindElement(By.Id("id_contact"));
            var selectElement = new SelectElement(option);
            System.Threading.Thread.Sleep(100);
            selectElement.SelectByIndex(1);

            // Enter Email address - email
            driver.FindElement(By.Id("email")).SendKeys("rastogi.akash@gmail.com");




            // Enter order reference number - id_order
            driver.FindElement(By.Id("id_order")).SendKeys("ABC0001");

            // Attach a file - fileUpload
            IWebElement fileUpload = driver.FindElement(By.Id("fileUpload"));

            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            filePath = Directory.GetParent(filePath).FullName;
            filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            filePath += @"\config\TestMail.docx";
            fileUpload.SendKeys(filePath);

            // Enter value in Message Box - message
            driver.FindElement(By.Id("message")).SendKeys("Test Mail");

            // Click on the Send button - submitMessage
            driver.FindElement(By.Id("submitMessage")).Click();

            // Verify the confirmation message - Your message has been successfully sent to our team.   
            IWebElement thing = driver.FindElement(By.Id("center_column"));
            Assert.IsTrue(thing.Text.Contains("Your message has been successfully sent to our team."));

            driver.Quit();
        }
    }
}
