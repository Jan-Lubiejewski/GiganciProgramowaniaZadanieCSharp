using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Utilities
{
    [Binding]
    public class Hooks
    {
        private IWebDriver? driver; // Declare the driver as nullable

        // Runs before each scenario, sets up the driver and visits the URL
        [BeforeScenario]
        public void SetUp()
        {
            // Correctly use the static method from Driver.cs to get the driver instance
            driver = Drive.GetDriver();  // Corrected call to the static method
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

        // Expose WebDriver to Step Definitions if necessary
        public IWebDriver Driver => driver!;
    }
}
