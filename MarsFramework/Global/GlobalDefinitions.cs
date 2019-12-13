//using Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;

namespace MarsFramework.Global
{
    class GlobalDefinitions
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

        #region WaitforElement 

        public static void Wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)));
        }
        public static IWebElement WaitForElementClickable(IWebElement element, IWebDriver driver, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        #endregion


        #region Excel 
        public class ExcelLib
        {
            static readonly List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int RowNumber { get; set; }
                public string ColName { get; set; }
                public string ColValue { get; set; }
            }


            public static void ClearData()
            {
                dataCol.Clear();
            }


            private static DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                //// Open file and return as Stream
                //using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                //{
                //    //using (ExcelDataReader.IExcelDataReader excelReader = excelReader.ExcelReaderFactory.CreateOpenXmlReader(stream)) 
                //  using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                //    {
                //        //Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                //        excelReader.IsFirstRowAsColumnNames = true;

                //        //Return as dataset
                //        DataSet result = excelReader.AsDataSet();
                //        //Get all the tables
                //        DataTableCollection table = result.Tables;

                //        // store it in data table
                //        DataTable resultTable = table[SheetName];

                //        //excelReader.Dispose();
                //        //excelReader.Close();
                //        // return
                //        return resultTable;
               // fileName = @"C:\TestData";
               using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                        //Get all the tables
                        var table = result.Tables;
                        // store it in data table
                        var resultTable = table[SheetName];
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                //try
                //{
                //    //Retriving Data using LINQ to reduce much of iterations

                //    rowNumber -= 1;
                //    string data = (from colData in dataCol
                //                   where colData.ColName == columnName && colData.RowNumber == rowNumber
                //                   select colData.ColValue).SingleOrDefault();

                //    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                //    return data.ToString();
                //}

                //catch (Exception e)
                //{
                //    //Added by Kumar
                //    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                //    return null;
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations
                    rowNumber = rowNumber - 1;
                    var data = (from colData in dataCol
                                where (colData.ColName == columnName) && (colData.RowNumber == rowNumber)
                                select colData.ColValue).SingleOrDefault();
                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                    return data;
                }
                catch (Exception e)
                {
                    // ReSharper disable once LocalizableElement
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine +
                                      e.Message);
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            RowNumber = row,
                            ColName = table.Columns[col].ColumnName,
                            ColValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        dataCol.Add(dtTable);

                    }
                }

            }
        }

        #endregion

        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (Base.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion
    }
}
