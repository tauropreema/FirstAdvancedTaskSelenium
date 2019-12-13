using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {

      
        //public SignIn()
        //{
        //    PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        //}

        // #region  Initialize Web Elements 
        // Finding the Sign Link
        // [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        // private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        //[FindsBy(How = How.Name, Using = "email")]
        // private IWebElement Email { get; set; }

        // Finding the Password Field
        // [FindsBy(How = How.Name, Using = "password")]
        // private IWebElement Password { get; set; }

        // Finding the Login Button
        // [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        // private IWebElement LoginBtn { get; set; }

        // #endregion
        //private IWebDriver driver; // constructor
        //public SignIn()
        //{
        //    this.driver = GlobalDefinitions.driver;
        //}
      
    

        internal void LoginSteps()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Initialize Web Elements
            IWebElement SignLink = GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Sign In')]"));
            SignLink.Click();

            IWebElement Email = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.Clear();

            //type the user name as [mvpstudio.qa@gmail.com] 
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Username"));

            IWebElement Password = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));

            // identify and type the password as [SydneyQa2018] 
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Password"));

            IWebElement LoginBtn = GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='fluid ui teal button'][contains(.,'Login')]"));

            // Populate create collection during runtime
            // ExcelUtility.PopulateInCollection(@"C:\Users\shaik\Downloads\marsframework-master\MarsFramework\ExcelData\SignIn.xls", "SignIn");

            //click on login button 
            LoginBtn.Click();
                                          
        }
    }
}


//IWebElement Email = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
//IWebElement Password = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
//IWebElement LoginBtn = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

//Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
//            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));