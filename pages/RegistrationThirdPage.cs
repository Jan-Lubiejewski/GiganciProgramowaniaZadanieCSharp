using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationThirdPage
    {
        public void ClickOnWybierzPierwszeKrokiWProgramowaniu()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the button is available
                IWebElement wybierzButton = wait.Until(d =>
                {
                    var element = d.FindElement(By.Name("registration-step-select-course-1092"));
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    throw new NoSuchElementException("The 'Wybierz Pierwsze Kroki W Programowaniu' button is not available.");
                });

                // Click the button
                wybierzButton.Click();

                // Refind element if the page has changed (to avoid stale element reference)
                wait.Until(d => d.FindElement(By.Name("someElementOnNextPage")).Displayed);
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for 'Wybierz Pierwsze Kroki W Programowaniu' button: {e.Message}");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Error finding 'Wybierz Pierwsze Kroki W Programowaniu' button: {e.Message}");
            }
        }


    }
}
