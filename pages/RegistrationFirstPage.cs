using OpenQA.Selenium;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationFirstPage
    {
        // Locators
        private IWebElement? form;
        private IWebElement? parentName;
        private IWebElement? parentNameError;
        private IWebElement? email;
        private IWebElement? emailError;
        private IWebElement? phoneNumber;
        private IWebElement? phoneNumberError;
        private IWebElement? birthYear;
        private IWebElement? birthYearError;
        private IWebElement? statueAgreed;
        private IWebElement? statueAgreedError;
        private IWebElement? advertisementAgreed;
        private IWebElement? advertisementAgreedError;
        private IWebElement? alertMessage;
        private IWebElement? dalejButton;

        // Constructor to initialize the web elements manually

        // Check if the advertisement agreed checkbox is selected
        public void CheckAdvertisementAgreed()
        {
            advertisementAgreed = Drive.GetDriver().FindElement(By.Id("advertisementAgreed"));
            ((IJavaScriptExecutor)Drive.GetDriver()).ExecuteScript("arguments[0].click();", advertisementAgreed);
        }

        // Check if the statue agreed checkbox is selected
        public void CheckStatueAgreedCheckbox()
        {
            statueAgreed = Drive.GetDriver().FindElement(By.Id("statuteAgreed"));
            ((IJavaScriptExecutor)Drive.GetDriver()).ExecuteScript("arguments[0].click();", statueAgreed);
        }

        // Input the birth year
        public void InputBirthYear(string year)
        {
            birthYear = Drive.GetDriver().FindElement(By.Name("birthYear"));
            birthYear.SendKeys(year);
        }

        // Input the parent name
        public void InputParentName(string name)
        {
            parentName = Drive.GetDriver().FindElement(By.Name("parentName"));
            parentName.SendKeys(name);
        }

        // Check if the phone format error appears
        public bool IsErrorPhoneFormatAppears()
        {
            phoneNumberError = Drive.GetDriver().FindElement(By.XPath("//input[@name='phoneNumber']/ancestor::div[@class='formControls']//span[@class='formValidation']"));
            string expectedText = "Niepoprawny numer telefonu. Numer powinien zawierać 9 cyfr, z opcjonalnym kierunkowym +48 lub +380 na początku.";
            return phoneNumberError.Displayed && phoneNumberError.Text.Equals(expectedText);
        }

        // Input the phone number
        public void InputPhoneNumber(string phone)
        {
            phoneNumber = Drive.GetDriver().FindElement(By.Name("phoneNumber"));
            phoneNumber.SendKeys(phone);
        }

        // Check if the email format error appears
        public bool IsErrorEmailFormatAppears()
        {
            emailError = Drive.GetDriver().FindElement(By.XPath("//input[@name='email']/ancestor::div[@class='formControls']//span[@class='formValidation']"));
            string expectedText = "Nieprawidłowy adres e-mail";
            return emailError.Displayed && emailError.Text.Equals(expectedText);
        }

        // Input the email
        public void InputEmail(string mail)
        {
            email = Drive.GetDriver().FindElement(By.Name("email"));
            email.SendKeys(mail);
        }

        // Check if we are still at the first registration page
        public bool IsRemainAtFirstRegistrationPage()
        {
            form = Drive.GetDriver().FindElement(By.Id("submit-payment"));
            string expectedUrl = "https://devtest.giganciprogramowania.edu.pl/zapisz-sie";
            string currentUrl = Drive.GetDriver().Url;
            return form.Displayed && currentUrl.Equals(expectedUrl);
        }

        // Check if the alert message is displayed
        public bool IsAlertMessageAppears()
        {
            alertMessage = Drive.GetDriver().FindElement(By.XPath("//h4[@class='alert-heading']"));
            return alertMessage.Displayed;
        }

        // Check if the form has been submitted
        public bool IsFormSubmitted()
        {
            form = Drive.GetDriver().FindElement(By.Id("submit-payment"));
            return !form.Displayed; // If form is not displayed, it means it's submitted
        }

        // Check if error messages appear under all fields
        public bool IsErrorMessageAppearsUnderAllFields()
        {
            parentNameError = Drive.GetDriver().FindElement(By.XPath("//input[@name='parentName']/ancestor::div[@class='formControls']//span[@class='formValidation']"));
            emailError = Drive.GetDriver().FindElement(By.XPath("//input[@name='email']/ancestor::div[@class='formControls']//span[@class='formValidation']"));
            phoneNumberError = Drive.GetDriver().FindElement(By.XPath("//input[@name='phoneNumber']/ancestor::div[@class='formControls']//span[@class='formValidation']"));
            birthYearError = Drive.GetDriver().FindElement(By.XPath("//input[@name='birthYear']/ancestor::div[@class='formControls']//span[@class='formValidation']"));
            statueAgreedError = Drive.GetDriver().FindElement(By.XPath("//input[@id='statuteAgreed']/parent::div//div[@class='formValidation']//span[@class='formError']"));
            advertisementAgreedError = Drive.GetDriver().FindElement(By.XPath("//input[@id='advertisementAgreed']/parent::div//div[@class='formValidation']//span[@class='formError']"));

            var errorMessages = new List<IWebElement>
            {
                parentNameError,
                emailError,
                phoneNumberError,
                birthYearError,
                statueAgreedError,
                advertisementAgreedError
            };

            foreach (var errorMessage in errorMessages)
            {
                if (!errorMessage.Displayed || 
                    !(errorMessage.Text.Equals("Pole jest wymagane") || errorMessage.Text.Equals("To pole jest wymagane")))
                {
                    return false;
                }
            }

            return true;
        }

        // Click the "Dalej" button (next)
        public void ClickDalej()
        {
            dalejButton = Drive.GetDriver().FindElement(By.Id("agreement-step-submit"));
            dalejButton.Click();
        }
    }
}
