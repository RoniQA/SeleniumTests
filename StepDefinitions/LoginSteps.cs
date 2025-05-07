using System;
using LightBDD.XUnit2;
using LightBDD.Framework.Scenarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumTests.StepDefinitions
{
    public partial class LoginSteps : FeatureFixture, IDisposable
    {
        private IWebDriver _driver;

        public LoginSteps()
        {
            // Configurando o WebDriverManager para garantir que o ChromeDriver esteja sempre atualizado
            new DriverManager().SetUpDriver(new ChromeConfig());

            // Instanciando o ChromeDriver após a configuração do WebDriverManager
            _driver = new ChromeDriver(ConfigureChromeOptions());
        }

        private ChromeOptions ConfigureChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");  // Rodar sem interface gráfica
            options.AddArgument("--no-sandbox");  // Permite rodar no ambiente CI
            options.AddArgument("--disable-dev-shm-usage");  // Desativa o uso de memória compartilhada
            options.AddArgument("--remote-debugging-port=9222");  // Habilita a depuração remota
            options.AddArgument("--disable-gpu");  // Desativa o uso de GPU (necessário no Linux)
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

        // Given step
        private void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            System.Threading.Thread.Sleep(1000); // Aguarda a página carregar
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

            System.Threading.Thread.Sleep(2000); // Aguarda o login
        }

        // Then step
        private void ThenIShouldBeLoggedIn()
        {
            var inventoryPage = _driver.FindElement(By.ClassName("inventory_list"));
            Assert.True(inventoryPage.Displayed, "Login não foi bem-sucedido, a página de inventário não foi exibida.");
        }

        // Cleanup
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}