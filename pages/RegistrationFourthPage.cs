using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationFourthPage
    {
        // Locators
        private By submitButtonLoc = By.Id("registration-step-submit");
        private By registrationButtonsLoc = By.ClassName("registration-btn");
        private By registrationVacanciesLoc = By.ClassName("timetable__date-places-info");
        private By firstNameLoc = By.Name("student_firstname");
        private By lastNameLoc = By.Name("student_lastname");
        private By parentLastNameLoc = By.Name("lastname");
        private By zipCodeLoc = By.Name("zip_code");

        public void ClickSubmitButton()
        {
            IWebElement submitButton = Drive.GetDriver().FindElement(submitButtonLoc);
            submitButton.Click();
        }

        public void InputZipCode(string code)
        {
            IWebElement zipCode = Drive.GetDriver().FindElement(zipCodeLoc);
            zipCode.SendKeys(code);
        }

        public void InputParentLastName(string name)
        {
            IWebElement parentLastName = Drive.GetDriver().FindElement(parentLastNameLoc);
            parentLastName.SendKeys(name);
        }

        public void InputStudentLastName(string name)
        {
            IWebElement lastName = Drive.GetDriver().FindElement(lastNameLoc);
            lastName.SendKeys(name);
        }

        public void InputStudentFirstName(string name)
        {
            IWebElement firstName = Drive.GetDriver().FindElement(firstNameLoc);
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
                    var buttons = d.FindElements(registrationButtonsLoc).ToList();
                    if (buttons != null && buttons.Count > 0)
                    {
                        return buttons;
                    }
                    throw new NoSuchElementException("No registration buttons found.");
                });

                IList<IWebElement> registrationVacancies = wait.Until(d =>
                {
                    var vacancies = d.FindElements(registrationVacanciesLoc).ToList();
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
                    registrationButtons = driver.FindElements(registrationButtonsLoc).ToList();
                    registrationVacancies = driver.FindElements(registrationVacanciesLoc).ToList();
                }
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for elements: {e.Message}");
            }
        }


    }
}
