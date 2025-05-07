using System;
using AventStack.ExtentReports;
using LightBDD.XUnit2;
using LightBDD.Framework.Scenarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using SeleniumTests.Hooks;

namespace SeleniumTests.StepDefinitions
{
    public partial class LoginSteps : FeatureFixture, IDisposable
    {
        private IWebDriver _driver;
        private ExtentTest _test;

        public LoginSteps()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver(ConfigureChromeOptions());

            // Cria o cen�rio de teste no relat�rio
            _test = TestSetup.Extent.CreateTest("UserLogsInSuccessfully - Cen�rio de Login com sucesso");
        }

        private ChromeOptions ConfigureChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--remote-debugging-port=9222");
            options.AddArgument("--disable-gpu");
            return options;
        }

        [Scenario]
        public void UserLogsInSuccessfully()
        {
            try
            {
                Runner.RunScenario(
                    given => GivenIAmOnTheLoginPage(),
                    when => WhenIEnterValidCredentials(),
                    then => ThenIShouldBeLoggedIn()
                );
                _test.Pass("Cen�rio executado com sucesso.");
            }
            catch (Exception ex)
            {
                _test.Fail($"Erro no cen�rio: {ex.Message}");
                throw;
            }
        }

        private void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _test.Info("Naveguei at� a p�gina de login.");
            System.Threading.Thread.Sleep(1000);
        }

        private void WhenIEnterValidCredentials()
        {
            var usernameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.Id("login-button"));

            usernameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            _test.Info("Credenciais v�lidas inseridas e bot�o de login clicado.");
            System.Threading.Thread.Sleep(2000);
        }

        private void ThenIShouldBeLoggedIn()
        {
            var inventoryPage = _driver.FindElement(By.ClassName("inventory_list"));
            Assert.True(inventoryPage.Displayed, "Login n�o foi bem-sucedido.");
            _test.Pass("Login realizado com sucesso e p�gina de invent�rio exibida.");
        }

        public void Dispose()
        {
            _driver.Quit();
            _test.Info("Driver encerrado.");
        }
    }
}