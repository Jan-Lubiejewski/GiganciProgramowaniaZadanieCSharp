# Giganci Programowania Zadanie Rekrutacyjne

 E2E Automation Tests for the registration form written using:
- **Selenium v. "4.27.0"**
- **C# .net v. "9.0"**
- **NUnit v. "4.2.2"**
- **SpecFlow v. "3.9.74"**

## Overiew
The tests are based on the provided by Giganci Programowania test cases from Google Sheets. The registration form is the topic of testing. There are in total 5 test cases that test whether the form is working correctly.

## Dependencies and Setup
To run the tests you have to have lates .NET 9.0 installed on your machine. You will also need Google Chrome browser:
- [.NET 9.0 installation](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Google Chrome installation](https://www.google.com/chrome/)

The rest of the dependencies gets aquired via NuGet.
## Running Tests

After clonning the reposistory you may need to run:
```bash
  dotnet restore
```
This command will find the used NuGet packages and download them.

To run tests, run the following commands from the root directory:

```bash
  dotnet build
  dotnet test
```

## Test Report
To generate test report run
```bash
  dotnet test --logger "trx;LogFileName=test-results.trx"
```
It will generate the test report file in root directory called "test-results.trx". It's viewable for example in Visual Studio.

## Project structure
I have based my project on Page Object Model, where each next step in registration form is resembled by seperate Page class in directory:
```bash
 > pages
 ```
 which makes it easy to maintain and expand the Page class.
 The test cases steps are written in SpecFlow in feature file:
 ```bash
 > Features/register.feature
 ```
 They are written in plain English which makes it easier for non-technical person to follow on what's happening in the test. I have also chosen this framework in favour of BDD (Behaviour Driven Development). It's also possible to edit some of the values provided in test case by changing the value in quotes ''. It may be especially useful for last test case as the provided test date may result in failed test, if used too many times. Changing e-mail alone should help.
 
The step definition appear in file:
 
 ```bash
 > Tests
 >> Steps
 >>> Registration/RegistrationSteps.cs
 ```
 It's where the underlying C-Sharp code gets executed.
 
 I based my project on C# as it's listed under job requirement and because I had some previous experience with it. As for Selenium I used it because I'm familar with it and from what I gathered during the interview it's also in use in your company.
 
 
 
 