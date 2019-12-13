using MarsFramework.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    public class ServiceDetails
    {
        private readonly IWebDriver _driver;
        public ServiceDetails(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement SelectUser=> _driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/section[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/a[1]/img[1]"));      
        //Chat
        IWebElement Chat => _driver.FindElement(By.XPath("//a[contains(@class,'ui teal button')]"));
        IWebElement ChatTextbox => _driver.FindElement(By.XPath("//input[@id='chatTextBox']"));
        IWebElement Send => _driver.FindElement(By.Id("btnSend"));

        public void InitialiseChat()
        {
            try
            {
                //extent Reports              
                Base.test = Base.extent.StartTest("Send Chat message test");
                Search searchuser = new Search(_driver);
                searchuser.SearchByUser();              
                SelectUser.Click();
                //Populate data from excel sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//a[contains(@class,'ui teal button')]"), 60);
                Chat.Click();
                ChatTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ChatText"));
                GlobalDefinitions.WaitForElement(_driver, By.Id("btnSend"), 60);
                Send.Click();
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sent message Successfully");
              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
