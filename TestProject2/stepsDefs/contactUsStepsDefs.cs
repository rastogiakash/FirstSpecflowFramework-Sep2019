using System;
using System.IO;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TestProject2.utility;

namespace TestProject2.stepsDefs
{
    [Binding]
    public class contactUsStepsDefs
    {
        public IWebDriver driver;
        fileUploadHandler fileHandler = new fileUploadHandler();
        propertiesHandler propHandler = new propertiesHandler(@"\config\static.properties"); 

        [Given(@"I launch a Browser")]
        public void GivenILaunchABrowser()
        {
            // Launch Browser
            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Softwares\drivers", "geckodriver.exe");
            //or
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(fileHandler.fileUploadPath(@"\drivers\"), "geckodriver.exe");
            driver = new FirefoxDriver(service);
        }

        [Given(@"Navigate to the URL")]
        public void GivenNavigateToTheURL()
        {
            // Navigate to the URL
            System.Threading.Thread.Sleep(100);
            driver.Manage().Window.Maximize();

            //driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
            //Or
            driver.Navigate().GoToUrl(propHandler.get("url"));
        }

        [When(@"I populate every field in this form with an acceptable value")]
        public void WhenIPopulateEveryFieldInThisFormWithAnAcceptableValue()
        {
            // Select a value from Subject Heading from dropdown - id_contact
            var option = driver.FindElement(By.Id("id_contact"));
            var selectElement = new SelectElement(option);
            System.Threading.Thread.Sleep(100);
            selectElement.SelectByIndex(1);


            // Enter Email address - email
            //driver.FindElement(By.Id("email")).SendKeys("rastogi.akash@gmail.com");
            //Or
            driver.FindElement(By.Id("email")).SendKeys(propHandler.get("email"));


            // Enter order reference number - id_order
            //driver.FindElement(By.Id("id_order")).SendKeys("ABC0001");
            //Or
            driver.FindElement(By.Id("id_order")).SendKeys(propHandler.get("orderId"));
            

            // Attach a file - fileUpload
            IWebElement fileUpload = driver.FindElement(By.Id("fileUpload"));
            string filePath = fileHandler.fileUploadPath(@"\config\TestMail.docx");
            fileUpload.SendKeys(filePath);


            // Enter value in Message Box - message
            //driver.FindElement(By.Id("message")).SendKeys("Test Mail");
            //Or
            driver.FindElement(By.Id("message")).SendKeys(propHandler.get("MsgBox"));
        }
        
        [When(@"Click on the Send button")]
        public void WhenClickOnTheSendButton()
        {
            // Click on the Send button - submitMessage
            driver.FindElement(By.Id("submitMessage")).Click();
        }
        
        [Then(@"The result should be confirmation message")]
        public void ThenTheResultShouldBeConfirmationMessage()
        {
            // Verify the confirmation message
            IWebElement thing = driver.FindElement(By.Id("center_column"));
            Assert.IsTrue(thing.Text.Contains("Your message has been successfully sent to our team."));

            System.Threading.Thread.Sleep(100);
            driver.Quit();
        }
    }
}
