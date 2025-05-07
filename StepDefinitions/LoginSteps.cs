using System;
using LightBDD.XUnit2;
using LightBDD.Framework.Scenarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using AventStack.ExtentReports;
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

            // Cria uma inst�ncia do teste no relat�rio
            _test = TestSetup.Extent.CreateTest("Login com sucesso");
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
            Runner.RunScenario(
                given => GivenIAmOnTheLoginPage(),
                when => WhenIEnterValidCredentials(),
                then => ThenIShouldBeLoggedIn()
            );
        }

        private void GivenIAmOnTheLoginPage()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                System.Threading.Thread.Sleep(1000);
                _test.Log(Status.Pass, "Navegou para a p�gina de login.");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Erro ao acessar a p�gina de login: {ex.Message}");
                throw;
            }
        }

        private void WhenIEnterValidCredentials()
        {
            try
            {
                var usernameField = _driver.FindElement(By.Id("user-name"));
                var passwordField = _driver.FindElement(By.Id("password"));
                var loginButton = _driver.FindElement(By.Id("login-button"));

                usernameField.SendKeys("standard_user");
                passwordField.SendKeys("secret_sauce");
                loginButton.Click();

                System.Threading.Thread.Sleep(2000);
                _test.Log(Status.Pass, "Credenciais v�lidas inseridas e bot�o de login clicado.");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Erro ao realizar o login: {ex.Message}");
                throw;
            }
        }

        private void ThenIShouldBeLoggedIn()
        {
            try
            {
                var inventoryPage = _driver.FindElement(By.ClassName("inventory_list"));
                Assert.True(inventoryPage.Displayed, "P�gina de invent�rio n�o exibida.");
                _test.Log(Status.Pass, "Login realizado com sucesso. P�gina de invent�rio vis�vel.");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Erro na verifica��o do login: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}