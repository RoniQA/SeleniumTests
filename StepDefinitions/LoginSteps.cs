using System;
using LightBDD.XUnit2;
using LightBDD.Framework.Scenarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using SeleniumTests.Pages;

namespace SeleniumTests.Steps
{
    public class LoginSteps : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public LoginSteps()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _loginPage = new LoginPage(_driver);
        }

        public void Given_I_am_on_login_page() => _loginPage.Navigate();

        public void When_I_login_with_valid_credentials() =>
            _loginPage.Login("standard_user", "secret_sauce");

        public void Then_I_should_see_the_inventory_page() =>
            Assert.True(_loginPage.InventoryList.Displayed);

        public void When_I_login_with_invalid_username() =>
            _loginPage.Login("invalid_user", "secret_sauce");

        public void When_I_login_with_invalid_password() =>
            _loginPage.Login("standard_user", "wrong_password");

        public void When_I_attempt_to_login_with_empty_fields() =>
            _loginPage.Login("", "");

        public void Then_I_should_see_a_login_error()
        {
            var errorMessage = _loginPage.ErrorMessage;
            Assert.True(errorMessage.Displayed);
            Assert.Contains("Epic sadface", errorMessage.Text);
        }

        public void Then_I_should_see_required_field_error()
        {
            var errorMessage = _loginPage.ErrorMessage;
            Assert.True(errorMessage.Displayed);
            Assert.Contains("Epic sadface", errorMessage.Text);
        }

        public void Then_I_should_see_an_error_message()
        {
            var errorMessage = _loginPage.ErrorMessage;
            Assert.True(errorMessage.Displayed);
            Assert.Contains("Epic sadface", errorMessage.Text);
        }

        public void Dispose() => _driver.Quit();
    }
}