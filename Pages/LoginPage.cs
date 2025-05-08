using OpenQA.Selenium;
using System.Linq;

namespace SeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(By.Id("user-name")).Clear();
            _driver.FindElement(By.Id("user-name")).SendKeys(username);

            _driver.FindElement(By.Id("password")).Clear();
            _driver.FindElement(By.Id("password")).SendKeys(password);

            _driver.FindElement(By.Id("login-button")).Click();
        }

        public bool IsInventoryVisible =>
            _driver.FindElements(By.Id("inventory_container")).Count > 0;

        public bool IsErrorMessageVisible =>
            _driver.FindElements(By.CssSelector("[data-test='error']")).Count > 0;

        public string ErrorMessageText =>
            _driver.FindElements(By.CssSelector("[data-test='error']"))
                   .FirstOrDefault()?.Text ?? "";
    }
}