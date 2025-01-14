using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationThirdPage
    {
        // Locators
        private By buttonPierwszeKrokiWProgramowniuLoc = By.Name("registration-step-select-course-1092");
        public void ClickOnWybierzPierwszeKrokiWProgramowaniu()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the button is available
                IWebElement wybierzButton = wait.Until(d =>
                {
                    var element = d.FindElement(buttonPierwszeKrokiWProgramowniuLoc);
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    throw new NoSuchElementException("The 'Wybierz Pierwsze Kroki W Programowaniu' button is not available.");
                });

                // Click the button
                wybierzButton.Click();
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for 'Wybierz Pierwsze Kroki W Programowaniu' button: {e.Message}");
            }
        }


    }
}
