using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Utilities
{
    public static class Drive
    {
        private static ThreadLocal<IWebDriver?> driver = new ThreadLocal<IWebDriver?>();

        // Static method to get the WebDriver instance
        public static IWebDriver GetDriver()
        {
            if (driver.Value == null)
            {
                InitializeDriver();
            }
            return driver.Value!;  // Non-nullable return type
        }
        
        private static void InitializeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized");

            // Initializing the driver per thread
            driver.Value = new ChromeDriver(options);
        }

        // Method to quit the WebDriver
        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}
