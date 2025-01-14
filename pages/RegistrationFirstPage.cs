using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationFirstPage
    {
        // Locators
        private By formLoc = By.Id("submit-payment");
        private By parentNameLoc = By.Name("parentName");
        private By parentNameErrorLoc = By.XPath("//input[@name='parentName']/ancestor::div[@class='formControls']//span[@class='formValidation']");
        private By emailLoc = By.Name("email");
        private By emailErrorLoc = By.XPath("//input[@name='email']/ancestor::div[@class='formControls']//span[@class='formValidation']");
        private By phoneNumberLoc = By.Name("phoneNumber");
        private By phoneNumberErrorLoc = By.XPath("//input[@name='phoneNumber']/ancestor::div[@class='formControls']//span[@class='formValidation']");
        private By birthYearLoc = By.Name("birthYear");
        private By birthYearErrorLoc = By.XPath("//input[@name='birthYear']/ancestor::div[@class='formControls']//span[@class='formValidation']");
        private By statueAgreedLoc = By.Id("statuteAgreed");
        private By statueAgreedErrorLoc = By.XPath("//input[@id='statuteAgreed']/parent::div//div[@class='formValidation']//span[@class='formError']");
        private By advertisementAgreedLoc = By.Id("advertisementAgreed");
        private By advertisementAgreedErrorLoc = By.XPath("//input[@id='advertisementAgreed']/parent::div//div[@class='formValidation']//span[@class='formError']");
        private By alertMessageLoc = By.XPath("//div[@id='system-message-container']/div[contains(@class, 'alert')]");
        private By dalejButtonLoc = By.Id("agreement-step-submit");

        // Check if the advertisement agreed checkbox is selected
        public void CheckAdvertisementAgreed()
        {
            IWebElement advertisementAgreed = Drive.GetDriver().FindElement(advertisementAgreedLoc);
            // Execute JS script to click since the Selenium click is intercepted by label
            ((IJavaScriptExecutor)Drive.GetDriver()).ExecuteScript("arguments[0].click();", advertisementAgreed);
        }

        // Check if the statue agreed checkbox is selected
        public void CheckStatueAgreedCheckbox()
        {
            IWebElement statueAgreed = Drive.GetDriver().FindElement(statueAgreedLoc);
            // Execute JS script to click since the Selenium click is intercepted by label
            ((IJavaScriptExecutor)Drive.GetDriver()).ExecuteScript("arguments[0].click();", statueAgreed);
        }

        // Input the birth year
        public void InputBirthYear(string year)
        {
            IWebElement birthYear = Drive.GetDriver().FindElement(birthYearLoc);
            birthYear.SendKeys(year);
        }

        // Input the parent name
        public void InputParentName(string name)
        {
            IWebElement parentName = Drive.GetDriver().FindElement(parentNameLoc);
            parentName.SendKeys(name);
        }

        // Check if the phone format error appears
        public bool IsErrorPhoneFormatAppears()
        {
            IWebElement phoneNumberError = Drive.GetDriver().FindElement(phoneNumberErrorLoc);
            string expectedText = "Niepoprawny numer telefonu. Numer powinien zawierać 9 cyfr, z opcjonalnym kierunkowym +48 lub +380 na początku.";
            return phoneNumberError.Displayed && phoneNumberError.Text.Equals(expectedText);
        }

        // Input the phone number
        public void InputPhoneNumber(string phone)
        {
            IWebElement phoneNumber = Drive.GetDriver().FindElement(phoneNumberLoc);
            phoneNumber.SendKeys(phone);
        }

        // Check if the email format error appears
        public bool IsErrorEmailFormatAppears()
        {
            IWebElement emailError = Drive.GetDriver().FindElement(emailErrorLoc);
            string expectedText = "Nieprawidłowy adres e-mail";
            return emailError.Displayed && emailError.Text.Equals(expectedText);
        }

        // Input the email
        public void InputEmail(string mail)
        {
            IWebElement email = Drive.GetDriver().FindElement(emailLoc);
            email.SendKeys(mail);
        }

        // Check if we are still at the first registration page
        public bool IsRemainAtFirstRegistrationPage()
        {
            IWebElement form = Drive.GetDriver().FindElement(formLoc);
            string expectedUrl = "https://devtest.giganciprogramowania.edu.pl/zapisz-sie";
            string currentUrl = Drive.GetDriver().Url;
            return form.Displayed && currentUrl.Equals(expectedUrl);
        }

        // Check if the alert message is displayed
        public bool IsAlertMessageAppears()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                // Wait until the element is available (displayed)
                wait.Until(d => d.FindElement(alertMessageLoc).Displayed);

                // Finds the element after the wait
                IWebElement formHeading = driver.FindElement(alertMessageLoc);

                return formHeading.Displayed;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return false;
            }
        }

        // Check if the form has been submitted
        public bool IsFormSubmitted()
        {
            IWebElement form = Drive.GetDriver().FindElement(formLoc);
            return !form.Displayed; // If form is not displayed, it means it's submitted
        }

        // Check if error messages appear under all fields
        public bool IsErrorMessageAppearsUnderAllFields()
        {
            IWebElement parentNameError = Drive.GetDriver().FindElement(parentNameErrorLoc);
            IWebElement emailError = Drive.GetDriver().FindElement(emailErrorLoc);
            IWebElement phoneNumberError = Drive.GetDriver().FindElement(phoneNumberErrorLoc);
            IWebElement birthYearError = Drive.GetDriver().FindElement(birthYearErrorLoc);
            IWebElement statueAgreedError = Drive.GetDriver().FindElement(statueAgreedErrorLoc);
            IWebElement advertisementAgreedError = Drive.GetDriver().FindElement(advertisementAgreedErrorLoc);

            // Create list of errorMessages
            var errorMessages = new List<IWebElement>
            {
                parentNameError,
                emailError,
                phoneNumberError,
                birthYearError,
                statueAgreedError,
                advertisementAgreedError
            };

            // Iterate trough list of errorMessage and check if any of them doesn't appear
            foreach (var errorMessage in errorMessages)
            {
                // Error message differ between regular input and checkbox, therefore there are two Equals checks
                if (!errorMessage.Displayed || 
                    !(errorMessage.Text.Equals("Pole jest wymagane") || errorMessage.Text.Equals("To pole jest wymagane")))
                {
                    return false;
                }
            }

            return true;
        }
        // Clicks 'Dalej' button
        public void ClickDalej()
        {
            IWebElement dalejButton = Drive.GetDriver().FindElement(dalejButtonLoc);
            // Execute JS script to scroll to and click dalej Button since the Selenium click may get intercepted
            ((IJavaScriptExecutor)Drive.GetDriver()).ExecuteScript("arguments[0].scrollIntoView();", dalejButton);
            ((IJavaScriptExecutor)Drive.GetDriver()).ExecuteScript("arguments[0].click();", dalejButton);
        }
    }
}
