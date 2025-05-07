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
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver(ConfigureChromeOptions());
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
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
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

            System.Threading.Thread.Sleep(2000);
        }

        private void ThenIShouldBeLoggedIn()
        {
            var inventoryPage = _driver.FindElement(By.ClassName("inventory_list"));
            Assert.True(inventoryPage.Displayed, "Página de inventário não exibida.");
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}