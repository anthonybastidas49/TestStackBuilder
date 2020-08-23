using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Chome
    {
        IWebElement inputPlate { get; set; }
        IWebElement inputDate { get; set; }
        IWebElement inputTime { get; set; }
        IWebElement btnSearch { get; set; }
        IWebDriver driver { get; set; }
        public Chome(IWebDriver webDriver)
        {
            Thread.Sleep(3000);
            this.driver = webDriver;
            this.inputPlate = driver.FindElement(By.Id("formLayout_txtPlaca_I"));
            this.inputDate = driver.FindElement(By.Id("formLayout_date_I"));
            this.inputTime = driver.FindElement(By.Id("formLayout_time_I"));
            this.btnSearch = driver.FindElement(By.Id("btnSearch"));
        }
        /// <summary>
        /// Method in charge of initializing components
        /// </summary>
        /// <param name="plate">Plate</param>
        /// <param name="dateTime">DateSele</param>
        public void testData(String plate, DateTime dateTime)
        {
            try
            {
                inputPlate.Clear();
                inputDate.Clear();
                inputTime.Clear();
                inputPlate.SendKeys(plate);
                inputDate.SendKeys(dateTime.ToShortDateString());
                inputTime.SendKeys(dateTime.ToShortDateString());
                btnSearch.Click();
                Thread.Sleep(3000);
                IWebElement btnClose = driver.FindElement(By.Id("poupMensaje_TPCFm1_cmdClose"));
                btnClose.Click();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
