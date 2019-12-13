using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class Search
    {
        private readonly IWebDriver _driver;
        public Search(IWebDriver driver)
        {
            _driver = driver;
        }
        //Search skills by Category and Subcategory     
        IWebElement SearchSkills => _driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input"));
        //search user
        IWebElement SearchUser => _driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
        //Get the list of users
        IList<IWebElement> SearchUserList => _driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div"));
        IWebElement SearchIcon => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"));
        IWebElement DisplayMessage => _driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/h3"));
        //Online
        IWebElement Online => _driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]"));
        //Onsite
        IWebElement Onsite => _driver.FindElement(By.XPath("//button[contains(.,'Onsite')]"));
        //ShowAll
        IWebElement ShowAll => _driver.FindElement(By.XPath("//button[contains(.,'ShowAll')]"));

        public void SearchByCategory()
        {
            try
            {

                GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkills");
                Profile profileDetails = new Profile(_driver);
                profileDetails.Search();
                SearchSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
                SearchSkills.SendKeys(Keys.Enter);
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Search by Category is Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SearchByUser()
        {
            try
            {
                //Populate with excel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"), 1000);
                SearchIcon.Click();
                SearchUser.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchUser"));
                SearchUser.SendKeys(Keys.Enter);
                GlobalDefinitions.WaitForElement(_driver, By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div"), 1000);
                bool Exist = false;
                string FirstXpath = "//html/body/div/div/div/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[";
                string SecondXpath = "]/div[1]/span[1]";
                for (int rowNum = 1; rowNum <= SearchUserList.Count; rowNum++)
                {
                    SearchUser.SendKeys(Keys.Enter);
                    GlobalDefinitions.WaitForElement(_driver, By.XPath(FirstXpath + rowNum + SecondXpath), 10000);
                    IWebElement userList = _driver.FindElement(By.XPath(FirstXpath + rowNum + SecondXpath));
                    if (GlobalDefinitions.ExcelLib.ReadData(2, "SearchUser") == userList.Text)
                    {
                        userList.Click();
                        try
                        {
                            if (DisplayMessage.Text == "No results found, please select a new category!")
                            {
                                //do nothing
                            }
                        }
                        catch (NoSuchElementException)
                        {
                            Exist = true;
                            return;
                        }
                        // GlobalDefinitions.Wait(2000);
                    }
                }
                if (Exist == true)
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Search by user is Successful");
                else
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "No results found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SearchOtherOptions()
        {
            GlobalDefinitions.WaitForElement(_driver, By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"), 1000);
            SearchIcon.Click();
            //Click on Online
            Online.Click();
            GlobalDefinitions.Wait(5000);
            Onsite.Click();
            GlobalDefinitions.Wait(5000);
            ShowAll.Click();
        }
    }
}
