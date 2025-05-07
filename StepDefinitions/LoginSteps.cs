using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SeleniumTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _loginPage.Navigate();
        }

        [When(@"I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            _loginPage.Login("invalid_user", "invalid_password");
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            string errorMessage = _loginPage.GetErrorMessage();
            Assert.IsTrue(errorMessage.Contains("Username and password do not match")
                          || errorMessage.Contains("do not match any user"),
                          $"Mensagem de erro inesperada: {errorMessage}");
            _driver.Quit();
        }
    }
}