using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Utilities
{
    [Binding]
    public class Hooks
    {
        private IWebDriver? driver;

        // Runs before each scenario, sets up the driver and visits the URL
        [BeforeScenario]
        public void SetUp()
        {
            driver = Drive.GetDriver();
            driver.Navigate().GoToUrl("https://devtest.giganciprogramowania.edu.pl/zapisz-sie");
        }

        // Runs after each scenario, quits and disposes of the driver
        [AfterScenario]
        public void TearDown()
        {
            if (driver != null)
            {
                try
                {
                    System.Threading.Thread.Sleep(5000); // For debugging purposes
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    Drive.QuitDriver();
                }
            }
        }

        // Expose WebDriver to Step Definition if needed
        public IWebDriver Driver => driver!;
    }
}
