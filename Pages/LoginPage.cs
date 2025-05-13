using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace SeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Login(string username, string password)
        {
            var usernameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
            usernameField.Clear();
            usernameField.SendKeys(username);

            var passwordField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            passwordField.Clear();
            passwordField.SendKeys(password);

            var loginButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));
            loginButton.Click();
        }

        public bool IsInventoryVisible =>
            _wait.Until(driver => driver.FindElements(By.Id("inventory_container")).Any());

        public bool IsErrorMessageVisible =>
            _wait.Until(driver => driver.FindElements(By.CssSelector("[data-test='error']")).Any());

        public string ErrorMessageText
        {
            get
            {
                try
                {
                    var errorElement = _wait.Until(driver =>
                        driver.FindElements(By.CssSelector("[data-test='error']")).FirstOrDefault(e => e.Displayed));
                    return errorElement?.Text ?? string.Empty;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public void OpenMenu()
        {
            var menuButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("react-burger-menu-btn")));
            menuButton.Click();
        }

        public void ClickLogout()
        {
            try
            {
                var logoutButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout_sidebar_link")));
                logoutButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("O botão de logout não estava disponível dentro do tempo especificado.");
            }
        }

        public bool WaitForLoginButtonVisible(int timeoutInSeconds = 10)
        {
            try
            {
                var customWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return customWait.Until(driver =>
                {
                    var element = driver.FindElements(By.Id("login-button")).FirstOrDefault();
                    return element != null && element.Displayed;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsOnLoginPage()
        {
            try
            {
                return _driver.FindElement(By.Id("login-button")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsLoginPageVisible()
        {
            return _wait.Until(driver =>
            {
                var loginButton = driver.FindElements(By.Id("login-button")).FirstOrDefault();
                return loginButton != null && loginButton.Displayed;
            });
        }
    }
}