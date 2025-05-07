using System;
using LightBDD.XUnit2;
using LightBDD.Framework.Scenarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace SeleniumTests.StepDefinitions
{
    public partial class LoginSteps : FeatureFixture, IDisposable
    {
        private IWebDriver _driver;

        public LoginSteps()
        {
            _driver = new ChromeDriver();
        }

        [Scenario]
        public void UserLogsInSuccessfully()
        {
            Runner.RunScenario(
                given => GivenIAmOnTheLoginPage(),
                when => WhenIEnterValidCredentials(),
                then => ThenIShouldBeLoggedIn()
            );
        }

        // Given step
        private void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(1000); // Aguarda a página carregar
        }

        // When step
        private void WhenIEnterValidCredentials()
        {
            var usernameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.Id("login-button"));

            usernameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Thread.Sleep(2000); // Aguarda o login
        }

        // Then step
        private void ThenIShouldBeLoggedIn()
        {
            var inventoryPage = _driver.FindElement(By.ClassName("inventory_list"));
            Assert.True(inventoryPage.Displayed, "Login não foi bem-sucedido, a página de inventário não foi exibida.");
        }

        // Cleanup
        public void Dispose()  // Tornando o Dispose público
        {
            _driver.Quit();
        }
    }
}
