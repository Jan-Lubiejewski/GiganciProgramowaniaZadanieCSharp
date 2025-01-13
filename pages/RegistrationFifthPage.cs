using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace GiganciProgramowaniaTest.Pages
{
    public class RegistrationFifthPage
    {

        public bool IsStepsUpToFifthCompleted()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the steps are available
                IList<IWebElement> steps = wait.Until(d =>
                {
                    var elements = d.FindElements(By.ClassName("feature_registration-menu__item-icon")).ToList();
                    if (elements != null && elements.Count > 2) // Ensure enough steps are present
                    {
                        return elements;
                    }
                    throw new NoSuchElementException("No steps found or not enough steps present.");
                });

                bool isDisplayed = true;

                // Iterates through the steps list except for the last two
                for (int i = 0; i < steps.Count - 2; i++)
                {
                    IWebElement firstStep = steps[i];

                    // Retrieves the parent element that contains information about whether the step is completed
                    IWebElement parentElement = firstStep.FindElement(By.XPath(".."));
                    // Retrieves the child element (SVG icon)
                    IWebElement childElement = firstStep.FindElement(By.TagName("svg"));

                    if (parentElement == null || childElement == null)
                    {
                        throw new NoSuchElementException("Parent or child element is missing.");
                    }

                    string parentClass = parentElement.GetDomAttribute("class");
                    string childClass = childElement.GetDomAttribute("class");

                    // Checks if the classes of the given element contain "Completed" and "Icon-Tick"
                    if (parentClass.Contains("feature_registration-menu__item--completed") &&
                        childClass.Contains("icon-tick"))
                    {
                        continue; // Step is completed, move to the next one
                    }
                    else
                    {
                        isDisplayed = false;
                        break; // Exit the loop as soon as a step is not completed
                    }
                }

                return isDisplayed;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for the steps: {e.Message}");
                return false;
            }
        }


        // If customer has moved to fifth Page, the agreementHeading should be visible
        public bool IsMoveToFifthRegistrationPage()
        {
            IWebDriver driver = Drive.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the agreement heading is available
                IWebElement agreementHeading = wait.Until(d =>
                {
                    var element = d.FindElement(By.XPath("//div[@class='registration-form-agreement-content-thanks mb-24']/span"));
                    if (element != null && element.Displayed)
                    {
                        return element;
                    }
                    throw new NoSuchElementException("No agreement heading found.");
                });

                // Check if the heading is displayed
                return agreementHeading.Displayed;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"Timeout waiting for the agreement heading: {e.Message}");
                return false;
            }
        }

    }
}
