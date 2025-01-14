using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationSecondPage
    {
        // Locators
        private By formHeadingLoc = By.XPath("//span[text()='Wybierz tematykę kursu']");
        private By stepsLoc = By.ClassName("feature_registration-menu__item-icon");
        private By courseTopicLoc = By.ClassName("js-kind-group");
        private By onlineButtonLoc = By.XPath("//button[text()='Online']");
        private By courseTypeLoc = By.ClassName("sub-kind-selector--button");

        // Clicks 'Roczne kursy z Programowania' course type button
        public void ClickRoczneKursyZProgramowania()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the list of buttons is available
                IList<IWebElement> courseType = wait.Until(d =>
                {
                    var elements = d.FindElements(courseTypeLoc).ToList();
                    if (elements != null && elements.Count > 0)
                    {
                        return elements;
                    }
                    throw new NoSuchElementException("No buttons found for the courseType.");
                });

                // First button is Roczne Kursy Z Programowania
                IWebElement roczneKursyButton = courseType[0];

                // Wait until the button is visible and clickable
                wait.Until(d => roczneKursyButton.Displayed && roczneKursyButton.Enabled);

                // Click the button
                roczneKursyButton.Click();
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for 'Roczne Kursy Z Programowania' button: {e.Message}");
            }
        }

        // Clicks 'Online' button
        public void ClickOnline()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the button is visible and enabled
                IWebElement onlineButton = wait.Until(d =>
                {
                    IWebElement element = d.FindElement(onlineButtonLoc);
                    if (element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    throw new NoSuchElementException("The Online button is not in a clickable state.");
                });

                // Click the button
                onlineButton.Click();
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for the Online button: {e.Message}");
            }
        }



        public void ClickProgramowanie()
        {
            List<IWebElement> courseTopic = Drive.GetDriver().FindElements(courseTopicLoc).ToList();
            courseTopic[2].Click(); // 3rd button is Programowanie
        }

        public bool IsMoveToSecondRegistrationPage()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                // Wait until the element is available (displayed)
                wait.Until(d => d.FindElement(formHeadingLoc).Displayed);

                // Finds the element after the wait
                IWebElement formHeading = driver.FindElement(formHeadingLoc);

                return formHeading.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsFirstStepTicked()
        {
            List<IWebElement> steps = Drive.GetDriver().FindElements(stepsLoc).ToList();
            IWebElement firstStep = steps[0]; // Retrieve first step

            // Retrieve the parent element that contains the information if the step is completed
            IWebElement parentElement = firstStep.FindElement(By.XPath(".."));
            // Retrieve the child element that contains the tick svg icon
            IWebElement childElement = firstStep.FindElement(By.TagName("svg"));

            string parentClass = parentElement.GetDomAttribute("class");
            string childClass = childElement.GetDomAttribute("class");

            // Check if the classes of the given elements contain 'Completed' and 'Icon-Tick'
            return parentClass.Contains("feature_registration-menu__item--completed") && childClass.Contains("icon-tick");
        }

        public bool IsSecondStepActive()
        {
            List<IWebElement> steps = Drive.GetDriver().FindElements(stepsLoc).ToList();
            IWebElement secondStep = steps[1]; // Retrieve the second step

            // Retrieve parent element that contains class info if the class is active
            IWebElement parentElement = secondStep.FindElement(By.XPath(".."));

            string parentClass = parentElement.GetDomAttribute("class");

            // Check if the class of the element contains 'Active'
            return parentClass.Contains("feature_registration-menu__item--active");
        }
    }
}
