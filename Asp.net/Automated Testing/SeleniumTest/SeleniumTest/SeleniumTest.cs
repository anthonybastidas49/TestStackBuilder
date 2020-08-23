using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumTest
{
    class SeleniumTest
    {
        static void Main(string[] args)
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://localhost:64273");
                driver.Manage().Window.Maximize();
                Chome chome = new Chome(driver);
                chome.testData("P", DateTime.Now);
                chome = new Chome(driver);
                chome.testData("ABC1234", DateTime.Now);
                chome = new Chome(driver);
                chome.testData("ABC1234", Convert.ToDateTime("21-08-2020 08:00"));
                chome = new Chome(driver);
                chome.testData("ABC1230", Convert.ToDateTime("21-08-2020 08:00"));
                chome = new Chome(driver);
                chome.testData("ABC1239", Convert.ToDateTime("21-08-2020 15:00"));
                chome = new Chome(driver);
                chome.testData("ABC123A", Convert.ToDateTime("21-08-2020 08:00"));
                Environment.Exit(0);

            }
            catch
            {
                Environment.Exit(0);
            }

        }
    }
}
