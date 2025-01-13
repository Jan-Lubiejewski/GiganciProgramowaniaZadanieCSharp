using TechTalk.SpecFlow;
using GiganciProgramowaniaTest.Pages;

namespace GiganciProgramowaniaTest.Steps.Registration
{
    [Binding]
    public class RegistrationSteps
    {
        private RegistrationFirstPage registrationFirstPage;
        private RegistrationSecondPage registrationSecondPage;
        private RegistrationThirdPage registrationThirdPage;
        private RegistrationFourthPage registrationFourthPage;
        private RegistrationFifthPage registrationFifthPage;

        [Given("I am on the first step of the Registration Form")]
        public void GivenIAmOnTheFirstStepOfTheRegistrationForm()
        {
            registrationFirstPage = new RegistrationFirstPage();
        }

        [Then("I submit the form by clicking 'Dalej' button once.")]
        public void ThenISubmitTheFormByClickingDalejButtonOnce()
        {
            registrationFirstPage.ClickDalej();
            registrationSecondPage = new RegistrationSecondPage();
        }

        [Then("Validation message 'Pole jest wymagane' displays under each required field")]
        public void ThenValidationMessagePoleJestWymaganeDisplaysUnderEachRequiredField()
        {
            bool isErrorMessageAppears = registrationFirstPage.IsErrorMessageAppearsUnderAllFields();
            Assert.That(isErrorMessageAppears);
        }

        [Then("Form has not been submitted")]
        public void AndFormHasNotBeenSubmitted()
        {
            bool isFormSubmitted = !registrationFirstPage.IsFormSubmitted();
            Assert.That(isFormSubmitted);
        }

        [Then("Red colored alert appears with following text 'Prosimy uzupełnić wszystkie wymagane pola.'")]
        public void AndRedColoredAlertAppearsWithFollowingTextProsimyUzupelnicWszystkieWymaganePola()
        {
            bool isAlertAppears = registrationFirstPage.IsAlertMessageAppears();
            Assert.That(isAlertAppears);
        }

        [Then("Customer remains at first step of registration form")]
        public void AndCustomerRemainsAtFirstStepOfRegistrationForm()
        {
            bool isRemainAtFirstRegistrationPage = registrationFirstPage.IsRemainAtFirstRegistrationPage();
            Assert.That(isRemainAtFirstRegistrationPage);
        }

        [Then("I fill email input with '(.*)'")]
        public void ThenIFillEmailInputWith(string email)
        {
            registrationFirstPage.InputEmail(email);
        }

        [Then("Validation message 'Nieprawidłowy adres e-mail' displays under 'Adres e-mail' input.")]
        public void ThenValidationMessageNieprawidlowyAdresEmailDisplaysUnderAdresEmailInput()
        {
            bool isEmailWrongFormatErrorAppears = registrationFirstPage.IsErrorEmailFormatAppears();
            Assert.That(isEmailWrongFormatErrorAppears);
        }

        [Then("I fill phone number input with '(.*)'")]
        public void ThenIFillPhoneNumberInputWith(string phoneNumber)
        {
            registrationFirstPage.InputPhoneNumber(phoneNumber);
        }

        [Then("Validation message 'Niepoprawny numer telefonu.' displays under 'Numer kontaktowy' input.")]
        public void ThenValidationMessageNiepoprawnyNumerTelefonuDisplaysUnderNumerKontaktowyInput()
        {
            bool isPhoneWrongFormatErrorAppears = registrationFirstPage.IsErrorPhoneFormatAppears();
            Assert.That(isPhoneWrongFormatErrorAppears);
        }

        [Then("I fill imie opiekuna input with '(.*)'")]
        public void ThenIFillImieOpiekunaInputWith(string parentName)
        {
            registrationFirstPage.InputParentName(parentName);
        }

        [Then("I fill year of birth input with '(.*)'")]
        public void ThenIFillYearOfBirthInputWith(string year)
        {
            registrationFirstPage.InputBirthYear(year);
        }

        [Then("I click Statute Agreement checkbox")]
        public void ThenIClickStatuteAgreementCheckbox()
        {
            registrationFirstPage.CheckStatueAgreedCheckbox();
        }

        [Then("I click Advertisement Agreement checkbox")]
        public void ThenIClickAdvertisementAgreementCheckbox()
        {
            registrationFirstPage.CheckAdvertisementAgreed();
        }

        [Then("Customer moves to second step of registration form")]
        public void AndCustomerMovesToSecondStepOfRegistrationForm()
        {
            bool isMovesToSecondRegistrationPage = registrationSecondPage.IsMoveToSecondRegistrationPage();
            Assert.That(isMovesToSecondRegistrationPage);
        }

        [Then("In the navigation first step gets completed and its icon turns into tick icon")]
        public void AndInTheNavigationFirstStepGetsCompletedAndItsIconTurnsIntoTickIcon()
        {
            bool isFirstStepTicked = registrationSecondPage.IsFirstStepTicked();
            Assert.That(isFirstStepTicked);
        }

        [Then("In the navigation second step is displayed as active")]
        public void AndInTheNavigationSecondStepIsDisplayedAsActive()
        {
            bool isSecondStepActive = registrationSecondPage.IsSecondStepActive();
            Assert.That(isSecondStepActive);
        }

        [Then("I click on tile with the name of 'PROGRAMOWANIE'")]
        public void ThenIClickOnTileWithTheNameOfProgramowanie()
        {
            registrationSecondPage.ClickProgramowanie();
        }

        [Then("I click on tile called 'Online'")]
        public void AndIClickOnTileCalledOnline()
        {
            registrationSecondPage.ClickOnline();
        }

        [Then("I select button with the name of 'Roczne kursy z programowania'")]
        public void AndISelectButtonWithTheNameOfRoczneKursyZProgramowania()
        {
            registrationSecondPage.ClickRoczneKursyZProgramowania();
            registrationThirdPage = new RegistrationThirdPage();
        }

        [Then("I find course '(.*)' and click on Wybierz")]
        public void ThenIFindCourseAndClickOnWybierz(string courseName)
        {
            registrationThirdPage.ClickOnWybierzPierwszeKrokiWProgramowaniu();
            registrationFourthPage = new RegistrationFourthPage();
        }

        [Then("From the list of dates I select any that does not contain text 'Zapisy na listę rezerwową'.")]
        public void AndFromTheListOfDatesISelectAnyThatDoesNotContainTextZapisyNaListeRezerwowa()
        {
            registrationFourthPage.SelectCourseDateNotInStandbyList();
        }

        [Then("I fill imie ucznia input with '(.*)'")]
        public void ThenIFillImieUczniaInputWith(string name)
        {
            registrationFourthPage.InputStudentFirstName(name);
        }

        [Then("I fill nazwisko ucznia input with '(.*)'")]
        public void ThenIFillNazwiskoUczniaInputWith(string name)
        {
            registrationFourthPage.InputStudentLastName(name);
        }

        [Then("I fill nazwisko opiekuna input with '(.*)'")]
        public void ThenIFillNazwiskoOpiekunaInputWith(string name)
        {
            registrationFourthPage.InputParentLastName(name);
        }

        [Then("I fill kod pocztowy input with '(.*)'")]
        public void ThenIFillKodPocztowyInputWith(string code)
        {
            registrationFourthPage.InputZipCode(code);
        }

        [Then("I click Zapisz Dziecko button to submit the form")]
        public void AndIClickZapiszDzieckoSubmitButton()
        {
            registrationFourthPage.ClickSubmitButton();
            registrationFifthPage = new RegistrationFifthPage();
        }

        [Then("I am at Sign Agreement step")]
        public void ThenIAmAtSignAgreementStep()
        {
            bool isMoveToFifthRegistrationPage = registrationFifthPage.IsMoveToFifthRegistrationPage();
            Assert.That(isMoveToFifthRegistrationPage);
        }

        [Then("In the navigation all steps up to agreement are completed")]
        public void AndInTheNavigationAllStepsUpToAgreementAreCompleted()
        {
            bool isStepsUpToFifthCompleted = registrationFifthPage.IsStepsUpToFifthCompleted();
            Assert.That(isStepsUpToFifthCompleted);

        }
    }
}
