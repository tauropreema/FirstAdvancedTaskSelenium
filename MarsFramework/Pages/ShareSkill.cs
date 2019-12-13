using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;
using System;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
       
        private readonly IWebDriver _driver;
        public ShareSkill(IWebDriver driver)
        {
            _driver = driver;
        }

        //Click on ShareSkill Button
        IWebElement ShareSkillBtn => _driver.FindElement(By.LinkText("Share Skill"));
        //Enter the Title in textbox
        IWebElement Title => _driver.FindElement(By.Name("title"));
        //Enter the Description in textbox
        IWebElement Description => _driver.FindElement(By.Name("description"));
        //Click on Category Dropdown
        IWebElement Category => _driver.FindElement(By.Name("categoryId"));
        //Click on SubCategory Dropdown
        IWebElement SubCategory => _driver.FindElement(By.Name("subcategoryId"));
        //Enter Tag names in textbox
        IWebElement Tag => _driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
        //Select the Service type
        IWebElement Service => _driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));
        //Select the Location Type
        IWebElement Location => _driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        //Event title
        IWebElement EventTitle => _driver.FindElement(By.XPath("//input[@title='Title']"));
        //Click on Start Date dropdown 
        IWebElement StartDate => _driver.FindElement(By.Name("startDate"));
        //Click on End Date dropdown
        IWebElement EndDate => _driver.FindElement(By.Name("endDate"));
        //Storing the table of available days
        IWebElement table => _driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]"));
        //Storing and clicking the starttime
        IWebElement StartTime => _driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));
        //Click on EndTime dropdown
        IWebElement EndTime => _driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));
        //Click on Skill Trade option
        IWebElement SkillTrade => _driver.FindElement(By.XPath("//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        //Enter Skill Exchange
        IWebElement SkillExchange => _driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
        //Enter the amount for Credit
        IWebElement CreditAmount => _driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        //Click on Active/Hidden option
        IWebElement Active => _driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        //Click on Save button
        IWebElement Save => _driver.FindElement(By.XPath("//input[@value='Save']"));

        //click on management listing
        IWebElement ManagementListingBtn => _driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Manage Listings')]"));

        //title edit
        IWebElement EditTitle => _driver.FindElement(By.XPath("//input[contains(@name,'title')]"));

        //Description edit
        IWebElement EditDescrp => _driver.FindElement(By.XPath("//textarea[contains(@name,'description')]"));

        //Service type edit
        IWebElement OneOff => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

        //Skill Trade edit

        IWebElement EditCredit => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        public object CommonMethods { get; private set; }

        internal void EnterShareSkill()
        {
            //Thread.Sleep(3000);

            GlobalDefinitions.WaitForElement(_driver, By.LinkText ("Share Skill"), 3000);
            //GlobalDefinitions.Wait(3000);

            //click share skill button
            ShareSkillBtn.Click();

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EnterShareSkill");
            //Thread.Sleep(3000);
            //GlobalDefinitions.Wait(3000);
            GlobalDefinitions.WaitForElement(_driver, By.Name("title"), 3000);


            //Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            //Thread.Sleep(1000);
            GlobalDefinitions.Wait(1000);

            //Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Category
            Category.Click();

            Category.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]")).Click();
            GlobalDefinitions.Wait(1000);


            //Sub-Category
            SubCategory.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]")).Click();
            GlobalDefinitions.Wait(1000);

            //Tag
            Tag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag"));
            Tag.SendKeys(Keys.Enter);

            //Service
            Service.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();     // [Hourly basis service]
            GlobalDefinitions.Wait(3000);
            // Thread.Sleep(1000);


            //Service.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();      [One-off Service]


            //Location
            // Location.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();       [On-site]
            Location.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();       // [Online]
            GlobalDefinitions.Wait(5000);

            //Available Days
            GlobalDefinitions.WaitForElement(_driver, By.Name("startDate"), 2000);

            //Start Date
            StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            GlobalDefinitions.WaitForElement(_driver, By.Name("endDate"), 2000);

           // End Date
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            GlobalDefinitions.Wait(2000);

            //Skill Trade
            SkillTrade.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();     // [Skill-exchange]          

            //Skill Exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Enter);
            //Thread.Sleep(1000);
            GlobalDefinitions.Wait(1000);


            //Active
            Active.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();        // [Active]
            //Thread.Sleep(1000);
            GlobalDefinitions.Wait(1000);


            //Save
            Save.Click();
            //Thread.Sleep(1000);
            GlobalDefinitions.Wait(1000);



        }
    

        internal void EditShareSkill()
        {
            //Thread.Sleep(3000);
            GlobalDefinitions.Wait(3000);
            ManagementListingBtn.Click();
            //Thread.Sleep(2000);
            GlobalDefinitions.Wait(2000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");

            try
            {
                //Thread.Sleep(1000);
                GlobalDefinitions.Wait(1000);


                var table = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody")); //table

                var manageListRow = table.FindElements(By.TagName("tr")).ToList();   //all rows picked
                                                                                    

                var isFound = false;
                // var rows = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr"));  //each row and coloum


                for (int i = 1; i <= manageListRow.Count; i++)
                {

                    var row = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]"));  //each row and coloum

                    var columnList = row.FindElements(By.TagName("td")).ToList(); //all coloum

                    for (int j = 1; j <= columnList.Count; j++)
                    {


                        var oldManageList = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[" + j + "]"));  //each row and coloum

                        //click on edit button with specific row and column

                        if (oldManageList.Text == "Code")
                        {


                            isFound = true;

                            _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[2]/i")).Click();   //edit button



                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }

                }

                if (isFound)
                {
                    Thread.Sleep(1000);
                    //Add Title {edit value update from (Code)}
                    EditTitle.Clear();
                    EditTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"EditTitle"));
                    //Thread.Sleep(1000);
                    GlobalDefinitions.Wait(1000);


                    //Add Description
                    EditDescrp.Clear();
                    EditDescrp.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Description"));
                    //Thread.Sleep(1000);
                    GlobalDefinitions.Wait(1000);


                    //Service type
                    OneOff.Click();
                    //Thread.Sleep(1000);
                    GlobalDefinitions.Wait(1000);


                    //Skill Trade
                    EditCredit.Click();
                    CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"CreditAmount"));
                    //Thread.Sleep(1000);
                    GlobalDefinitions.Wait(1000);


                    Save.Click();
                }
                else
                {
                    Console.WriteLine("Test Fail, Edit un-successful");
                }


            }
            catch (Exception ex)
            {
                throw;
            }

        }
        internal void DeleteShareSkill()
        {
            //Thread.Sleep(3000);
            GlobalDefinitions.Wait(3000);
            ManagementListingBtn.Click();
            //Thread.Sleep(2000);
            GlobalDefinitions.Wait(2000);


            try
            {
                //Thread.Sleep(1000);
                GlobalDefinitions.Wait(1000);


                var table = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody")); //table

                var manageListRow = table.FindElements(By.TagName("tr")).ToList();   //all rows picked
                                                                                    

                var isFound = false;
                // var rows = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr"));  //each row and coloum


                for (int i = 1; i <= manageListRow.Count; i++)
                {

                    var row = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]"));  //each row and coloum

                    var columnList = row.FindElements(By.TagName("td")).ToList(); //all coloum

                    for (int j = 1; j <= columnList.Count; j++)
                    {


                        var oldManageList = _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[" + j + "]"));  //each row and coloum

                        //click on edit button with specific row and column

                        if (oldManageList.Text == "Edited Code")
                        {


                            isFound = true;

                            _driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i")).Click();   //Delete button
                           //IAlert alert = _driver.SwitchTo().Alert();
                              Thread.Sleep(2000);
                            _driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]")).Click();

                            //alert.Accept();

                            break;
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
    
    
