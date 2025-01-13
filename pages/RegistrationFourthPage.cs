using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationFourthPage
    {
        // Locators
        private IWebElement? submitButton;
        private IWebElement? firstName;
        private IWebElement? lastName;
        private IWebElement? parentLastName;
        private IWebElement? zipCode;

        public void ClickSubmitButton()
        {
            submitButton = Drive.GetDriver().FindElement(By.Id("registration-step-submit"));
            submitButton.Click();
        }

        public void InputZipCode(string code)
        {
            zipCode = Drive.GetDriver().FindElement(By.Name("zip_code"));
            zipCode.SendKeys(code);
        }

        public void InputParentLastName(string name)
        {
            parentLastName = Drive.GetDriver().FindElement(By.Name("lastname"));
            parentLastName.SendKeys(name);
        }

        public void InputStudentLastName(string name)
        {
            lastName = Drive.GetDriver().FindElement(By.Name("student_lastname"));
            lastName.SendKeys(name);
        }

        public void InputStudentFirstName(string name)
        {
            firstName = Drive.GetDriver().FindElement(By.Name("student_firstname"));
            firstName.SendKeys(name);
        }
        public void SelectCourseDateNotInStandbyList()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the list of registration buttons and vacancies are available
                IList<IWebElement> registrationButtons = wait.Until(d =>
                {
                    var buttons = d.FindElements(By.ClassName("registration-btn")).ToList();
                    if (buttons != null && buttons.Count > 0)
                    {
                        return buttons;
                    }
                    throw new NoSuchElementException("No registration buttons found.");
                });

                IList<IWebElement> registrationVacancies = wait.Until(d =>
                {
                    var vacancies = d.FindElements(By.ClassName("timetable__date-places-info")).ToList();
                    if (vacancies != null && vacancies.Count > 0)
                    {
                        return vacancies;
                    }
                    throw new NoSuchElementException("No registration vacancy elements found.");
                });

                // Iterate through available course dates
                for (int i = 0; i < registrationButtons.Count; i++)
                {
                    // Re-find the elements to avoid stale element reference
                    IWebElement button = registrationButtons[i];
                    IWebElement vacancy = registrationVacancies[i];

                    // Check if the vacancy does not contain "Zapisy na listę rezerwową"
                    if (!vacancy.Text.Contains("Zapisy na listę rezerwową"))
                    {
                        // Wait until the button is visible and clickable
                        wait.Until(driver => button.Displayed && button.Enabled);

                        // Click the button
                        button.Click();
                        break; // Exit the loop after finding the first available date
                    }

                    // Re-find the elements in case the DOM has changed after clicking
                    registrationButtons = driver.FindElements(By.ClassName("registration-btn")).ToList();
                    registrationVacancies = driver.FindElements(By.ClassName("timetable__date-places-info")).ToList();
                }
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for elements: {e.Message}");
            }
        }


    }
}
