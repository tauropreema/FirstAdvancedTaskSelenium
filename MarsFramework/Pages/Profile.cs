using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class Profile
    {

        private readonly IWebDriver _driver;

        public Profile(IWebDriver driver)
        {
            _driver = driver;
        }

        #region SkillWebElements
        IWebElement skillsButton => _driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Skills')]"));

        IWebElement ShareSkillBtn => _driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]"));

        //  Thread.Sleep(1500);
        //Click on Add New button

        //Add skill
        IWebElement nameField => _driver.FindElement(By.XPath("//input[@name='name']"));
        IWebElement levelField => _driver.FindElement(By.Name("level"));
        IWebElement valueField => _driver.FindElement(By.XPath("//option[@value='Intermediate']"));

        IWebElement addButton => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));

        IWebElement updateBtn => _driver.FindElement(By.XPath("//input[@value='Update']"));
        #endregion

        #region EducationWebElements

        IWebElement eduTab => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        //click on add new
        IWebElement addEdu => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));

        IWebElement editEdu => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td[6]/span[1]/i"));

        IWebElement deleteEdu => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td[6]/span[2]/i"));

        IWebElement dropDownListuni => _driver.FindElement(By.XPath("//input[@name='instituteName']"));

        IWebElement bachelor => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));

        IWebElement dropDowntitle3 => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));

        IWebElement dropDownListBox => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));

        IWebElement dropDowntitle => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));

        #endregion

        #region CertificationWebElements
        //clicking on profile tab
        IWebElement profileTab => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]"));
        //clicking on Cerification tab
        IWebElement certTab => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));

        //click on add new
        IWebElement addNew => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        // add certificate or award
        IWebElement cert => _driver.FindElement(By.XPath("//input[@class='certification-award capitalize']"));
        // add certified from
        IWebElement certFrom => _driver.FindElement(By.XPath("//input[@class='received-from capitalize']"));

        IWebElement certText => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));


        #endregion

        #region LanguageWebElements

        #endregion

        #region Change Password WebElements
        IWebElement HiMessage => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        IWebElement ChangePassword => _driver.FindElement(By.XPath("//a[contains(.,'Change Password')]"));
        IWebElement OldPassword => _driver.FindElement(By.Name("oldPassword"));
        IWebElement NewPassword => _driver.FindElement(By.Name("newPassword"));
        IWebElement ConfirmPassword => _driver.FindElement(By.Name("confirmPassword"));
        IWebElement ProfileSave => _driver.FindElement(By.XPath("//button[@role='button']"));
        //Add description
        IWebElement EditDescription => _driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[1]"));
        IWebElement ProfileDescription => _driver.FindElement(By.XPath("//textarea[@name='value']"));
        IWebElement SaveDescription => _driver.FindElement(By.XPath("//button[contains(@type,'button')]"));
        //Search skills     
        IWebElement SearchSkills => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));

        IWebElement SearchIcon => _driver.FindElement(By.XPath("//i[@class='search link icon']"));
        #endregion

        #region SkillMethods
        internal void AddSkill()
        {
            skillsButton.Click();
            GlobalDefinitions.Wait(1000);

            ShareSkillBtn.Click();

            nameField.SendKeys("selenium c#");

            levelField.Click();

            valueField.Click();

            addButton.Click();


            // CommonMethods.ExtentReports();
            // GlobalDefinitions.Wait(1000);
            //    CommonMethods.test = CommonMethods.extent.StartTest("Add a skill");


            GlobalDefinitions.Wait(2000);


            var table = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

            var skillsList = table.FindElements(By.TagName("tbody")).ToList();

            for (int i = 1; i <= skillsList.Count; i++)
            {

                var skill = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                //create test cases
                if (skill.Text == "selenium c#")
                {

                    //    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a skill Successfully");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "SkillAdded");
                    break;
                }
                else
                {
                    //  CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Skill is not added");
                    //Assert.Fail("failed");
                }



            }

        }
        internal void EditSkill()
        {
            skillsButton.Click();
            //Start the Reports
            // CommonMethods.ExtentReports();
            GlobalDefinitions.Wait(1000);
            //  CommonMethods.test = CommonMethods.extent.StartTest("Edit a skill");
            try
            {
                //  GlobalDefinitions.Wait(1000);


                var table = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table")); //table

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();   //all rows picked

                var isFound = false;

                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var oldskill = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));  //each row and coloum

                    //click on edit button with specific row and column

                    if (oldskill.Text == "selenium c#")
                    {
                        isFound = true;

                        _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]")).Click();   //edit button



                        break;
                    }
                }

                if (isFound)
                {

                    //  edit value update from (selenium C#)
                    nameField.Clear();
                    nameField.SendKeys("Manual Testing");

                    //Click on skill Level
                    levelField.Click();

                    //Choose the skill level (Expert) {edit value update}
                    _driver.FindElement(By.XPath("//option[@value='Expert']")).Click();
                    //Wait
                    GlobalDefinitions.Wait(1500);

                    //click on update button

                    updateBtn.Click();
                }
                else
                {
                    //  CommonMethods.test.Log(LogStatus.Fail, "Test Failed, skill not found");
                }

                GlobalDefinitions.Wait(1000);

                //validate
                var table1 = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

                var skillsList1 = table1.FindElements(By.TagName("tbody")).ToList();

                for (int i = 1; i <= skillsList1.Count; i++)
                {

                    var skill = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));

                    //create test cases
                    if (skill.Text == "Manual Testing")
                    {

                        //  CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a skill Successfully");
                        GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "SkillEdited");
                        break;
                    }
                    else
                    {
                        // CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Code not edited");
                        //Assert.Fail("failed-code not edited");
                    }

                }
            }
            catch (Exception ex)
            {
                //Log
            }
        }
        internal void DeleteSkill()
        {
            skillsButton.Click();
            //Start the Reports
            // CommonMethods.ExtentReports();
            GlobalDefinitions.Wait(2000);
            //   CommonMethods.test = CommonMethods.extent.StartTest("Edit a skill");

            try
            {
                GlobalDefinitions.Wait(1000);


                var table = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table")); //table

                var skillsList = table.FindElements(By.TagName("tbody")).ToList();   //all rows picked



                for (int i = 1; i <= skillsList.Count; i++)
                {

                    var skillname = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));  //each row and coloum

                    //click on delete button on specific row 

                    if (skillname.Text == "selenium java")
                    {


                        _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]")).Click();   //delete button

                        break;
                    }
                }

                GlobalDefinitions.Wait(1000);


                var table1 = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));   //table

                var skillsList1 = table1.FindElements(By.TagName("tbody")).ToList();

                for (int i = 1; i <= skillsList1.Count; i++)
                {

                    var skill = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));  //each row with coloum

                    //create test cases
                    if (skill.Text == "selenium java")
                    {

                        // CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a skill Successfully");
                        GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "SkillDeleted");
                        break;
                    }
                    else
                    {
                        // CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Code not deleted");
                        //Assert.Fail("failed");
                    }

                }

            }
            catch (Exception ex)
            {
                // CommonMethods.test.Log(LogStatus.Fail, $"Test Failed due to exception. {ex.Message}");
                //  Assert.Fail(ex.Message);

            }
        }
        #endregion

        #region EducationMethods
        internal void AddEducation()
        {
            GlobalDefinitions.Wait(3000);
            //clicking on profile tab
            //Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //clicking on Education Tab 
            eduTab.Click();
            //click on add new
            addEdu.Click();
            GlobalDefinitions.Wait(1000);
            dropDownListuni.SendKeys("JNTU");
            //Console.WriteLine(dropDownListuni.Text);

            GlobalDefinitions.Wait(1000);
            SelectElement clickThis = new SelectElement(dropDownListBox);
            clickThis.SelectByText("Brazil");
            //Console.WriteLine(dropDownListBox.Text);

            GlobalDefinitions.Wait(1000);
            SelectElement click = new SelectElement(dropDowntitle);
            click.SelectByText("B.A");
            //Console.WriteLine(dropDowntitle.Text);

            GlobalDefinitions.Wait(1000);
            bachelor.SendKeys("Bachelor Degree");
            //Console.WriteLine(bachelor.Text);

            GlobalDefinitions.Wait(1000);
            SelectElement click2 = new SelectElement(dropDowntitle3);
            click2.SelectByText("2016");
            //Console.WriteLine(dropDowntitle3.Text);
            //clicking add 
            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();

            //Start the Reports
            //  CommonMethods.ExtentReports();
            GlobalDefinitions.Wait(1000);
            // CommonMethods.test = CommonMethods.extent.StartTest("Add a Education Details");
            int count;
            GlobalDefinitions.Wait(1000);
            {
                count = 1;
                count++;
                int i;
                for (i = 1; i <= count++; i++)
                {
                    //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    IWebElement ActualValue = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                    GlobalDefinitions.Wait(1000);
                    Console.WriteLine(ActualValue.Text);
                    //string ExpectedValue = "Spanish";
                    if (ActualValue.Text == "Brazil")

                    {
                        //   CommonMethods.test.Log(LogStatus.Pass, "Test Passed, added Successfully");
                        GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "added");
                        Console.WriteLine("Passed");
                        return;
                    }

                    else

                        Console.WriteLine("Failed");
                }

            }

        }
        internal void EditEducation()
        {
            GlobalDefinitions.Wait(3000);
            //clicking on Education Tab 
            eduTab.Click();
            //click on modify button
            editEdu.Click();

            IWebElement modify2 = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td/div[1]/div[2]/select"));
            //modify2.Clear();
            SelectElement clickThis2 = new SelectElement(modify2);
            clickThis2.SelectByText("India");

            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td/div[3]/input[1]")).Click();

            //Start the Reports
            //CommonMethods.ExtentReports();
            GlobalDefinitions.Wait(1000);
            // CommonMethods.test = CommonMethods.extent.StartTest("modify a education Details");

            int count;
            GlobalDefinitions.Wait(1000);

            count = 1;
            count++;
            int i;
            for (i = 1; i <= count++; i++)
            {
                //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                IWebElement ActualValue = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                GlobalDefinitions.Wait(1000);
                Console.WriteLine(ActualValue.Text);
                //string ExpectedValue = "sitar";
                if (ActualValue.Text == "India")

                {
                    //  CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modified Successfully");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "modified");
                    Console.WriteLine("Success");
                    return;
                }


                else

                    Console.WriteLine("Failed");

            }

        }
        internal void DeleteEducation()
        {
            GlobalDefinitions.Wait(3000);

            eduTab.Click();

            deleteEdu.Click();
            // CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            // CommonMethods.test = CommonMethods.extent.StartTest("delete a education Details");

            int count;
            GlobalDefinitions.Wait(1000);

            count = 1;
            // count++;
            int i;
            for (i = 1; i <= count++; i++)
            {
                //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                IWebElement ActualValue = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                GlobalDefinitions.Wait(1000);
                Console.WriteLine(ActualValue.Text);
                //string ExpectedValue = "Spanish";
                if (ActualValue.Text == "India")

                {

                    //CommonMethods.test.Log(LogStatus.Fail, "Test Failed, not deleted Successfully");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "notdeleted");
                    Console.WriteLine("Fail");
                    Assert.Fail("failed");
                    // return;
                }


                else
                    //   CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "deleted");
                // Console.WriteLine("Success");


            }
        }
        #endregion

        #region LanguageMethods

        internal void AddLanguage()
        {

        }
        internal void EditLanguage()
        {

        }
        internal void DeleteLanguage()
        {

        }
        #endregion

        #region CertificationMethods

        internal void AddCertification()
        {
            int count;
            //clicking on profile tab
            profileTab.Click();
            //clicking on Cerification tab
            certTab.Click();
            //click on add new
            addNew.Click();
            // add certificate or award
            cert.SendKeys("ISTQB");
            // add certified from
            certFrom.SendKeys("ANZTB");
            // add or select year
            IWebElement addCerification = _driver.FindElement(By.XPath("//select[@name='certificationYear']"));
            SelectElement addcerificationyear = new SelectElement(addCerification);
            addcerificationyear.SelectByText("2018");
            //Console.WriteLine(addCerification.Text);
            certText.Click();
            //Start the Reports
            // CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            // CommonMethods.test = CommonMethods.extent.StartTest("Add a certification Details");

            Thread.Sleep(1000);
            count = 1;
            count++;
            int i;
            for (i = 1; i <= count++; i++)
            {
                //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                IWebElement ActualValue = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                Thread.Sleep(1000);
                Console.WriteLine(ActualValue.Text);
                //string ExpectedValue = "Spanish";
                if (ActualValue.Text == "ISTQB")

                {
                    // CommonMethods.test.Log(LogStatus.Pass, "Test Passed, added Successfully");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "added");
                    Console.WriteLine("Passed");
                    return;
                }

                else

                    Console.WriteLine("Failed");
            }




        }
        internal void EditCertification()
        {
            certTab.Click();
            //click on modify button
            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td[4]/span[1]/i")).Click();

            //clear and enter new data
            IWebElement certificationmodify = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td/div/div/div[1]/input"));
            certificationmodify.Clear();
            certificationmodify.SendKeys("QTP");

            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td/div/span/input[1]")).Click();

            int count;

            //Start the Reports
            //  CommonMethods.ExtentReports();
            GlobalDefinitions.Wait(1000);
            // CommonMethods.test = CommonMethods.extent.StartTest("modify a certification Details");

            GlobalDefinitions.Wait(1000);

            count = 1;
            count++;
            int i;
            for (i = 1; i <= count++; i++)
            {
                //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                IWebElement ActualValue = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                GlobalDefinitions.Wait(1000);
                Console.WriteLine(ActualValue.Text);
                //string ExpectedValue = "sitar";
                if (ActualValue.Text == "QTP")
                {
                    // CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modified Successfully");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "modified");
                    Console.WriteLine("Success");
                    return;
                }


                else

                    Console.WriteLine("Failed");

            }

        }
        internal void DeleteCertification()
        {
            certTab.Click();

            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td[4]/span[2]/i")).Click();

            // CommonMethods.ExtentReports();
            GlobalDefinitions.Wait(1000);
            // CommonMethods.test = CommonMethods.extent.StartTest("delete a certification Details");

            int count;
            GlobalDefinitions.Wait(1000);
            count = 1;
            // count++;
            int i;
            for (i = 1; i <= count++; i++)
            {
                //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                IWebElement ActualValue = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                GlobalDefinitions.Wait(1000);
                Console.WriteLine(ActualValue.Text);
                //string ExpectedValue = "Spanish";
                if (ActualValue.Text == "QTP")
                {
                    //CommonMethods.test.Log(LogStatus.Fail, "Test Failed, not deleted Successfully");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "notdeleted");
                    Console.WriteLine("Fail");
                    Assert.Fail("failed");
                    // return;
                }


                else
                    // CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(_driver, "deleted");
                // Console.WriteLine("Success");

            }


        }
        #endregion

        #region Profile Description

        public void EditProfileDescription()
        {
            try
            {

                //Change Profile description
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditDescription");
                EditDescription.Click();               
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//textarea[@name='value']"), 60);
                ProfileDescription.Clear();
                ProfileDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//button[contains(@type,'button')]"), 60);
               // SaveDescription.WaitForElementClickable(_driver, 60);
                SaveDescription.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region Search
        public void Search()
        {
            try
            {
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
                //Search on Search skills               
                SearchSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkillsByCategory"));
                SearchIcon.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region Change Password
        public void ChangePasswordDetails()
        {
            try
            {
                //extent Reports              
                Base.test = Base.extent.StartTest("Change Password test");
                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ChangePassword");
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"), 60);
                HiMessage.Click();
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//a[contains(.,'Change Password')]"), 60);             
                ChangePassword.Click();
                OldPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"));
                NewPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));
                ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//button[@role='button']"), 60);              
                ProfileSave.Click();
                string ChangePasswordSuccess = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3")).Text;
                if (ChangePasswordSuccess == "Description")
                {
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Password changed successfully");
                }
                else
                {
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Password not changed successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion


    }
}