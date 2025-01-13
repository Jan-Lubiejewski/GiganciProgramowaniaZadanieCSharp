Feature: Registration Form

 # Red alert at last <AND> block sometimes appears and sometimes it doesn't, explicit wait doesn't work here
 Scenario: Verify required fields
  Given I am on the first step of the Registration Form
  Then I submit the form by clicking 'Dalej' button once.
  Then Validation message 'Pole jest wymagane' displays under each required field
  Then Form has not been submitted
  Then Customer remains at first step of registration form
  # Then Red colored alert appears with following text 'Prosimy uzupełnić wszystkie wymagane pola.'

  Scenario: Verify e-mail format
   Given I am on the first step of the Registration Form
   Then I fill email input with 'user#example.com'
   Then I submit the form by clicking 'Dalej' button once.
   Then Validation message 'Nieprawidłowy adres e-mail' displays under 'Adres e-mail' input.
   And Form has not been submitted
   And Customer remains at first step of registration form
   # And Red colored alert appears with following text 'Prosimy uzupełnić wszystkie wymagane pola.'

  Scenario: Verify phone format
   Given I am on the first step of the Registration Form
   Then I fill phone number input with '12345665'
   Then I submit the form by clicking 'Dalej' button once.
   Then Validation message 'Niepoprawny numer telefonu.' displays under 'Numer kontaktowy' input.
   And Form has not been submitted
   And Customer remains at first step of registration form
   #And Red colored alert appears with following text 'Prosimy uzupełnić wszystkie wymagane pola.'

  Scenario: Verify correct first step from submission with correct data
   Given I am on the first step of the Registration Form
   Then I fill imie opiekuna input with 'Artur'
   Then I fill email input with 'karolgiganci+fakedata80696@gmail.com'
   Then I fill phone number input with '123456651'
   Then I fill year of birth input with '2005'
   Then I click Statute Agreement checkbox
   Then I click Advertisement Agreement checkbox
   Then I submit the form by clicking 'Dalej' button once.
   And Customer moves to second step of registration form
   And In the navigation first step gets completed and its icon turns into tick icon
   And In the navigiation second step is displayed as active

Scenario: Verify registration flow for online annual courses
  Given I am on the first step of the Registration Form
  Then I fill imie opiekuna input with 'Artur'
  Then I fill email input with 'karolgiganci+fakedata80696@gmail.com'
  Then I fill phone number input with '123456651'
  Then I fill year of birth input with '2005'
  Then I click Statute Agreement checkbox
  Then I click Advertisement Agreement checkbox
  Then I submit the form by clicking 'Dalej' button once.
  And Customer moves to second step of registration form
  Then I click on tile with the name of 'PROGRAMOWANIE'
  And I click on tile called 'Online'
  And I select button with the name of 'Roczne kursy z programowania'
  Then I find course 'Pierwsze kroki w programowaniu(kurs z elementami AI) ONLINE' and click on Wybierz
  And From the list of dates I select any that does not contain text 'Zapisy na listę rezerwową'.
  Then I fill imie ucznia input with 'Maciej'
  Then I fill nazwisko ucznia input with 'Testowy'
  Then I fill nazwisko opiekuna input with 'Testowy'
  Then I fill kod pocztowy input with '26-900'
  And I click Zapisz Dziecko button to submit the form
  Then I am at Sign Agreement step
  And In the navigation all steps up to agreement are completed