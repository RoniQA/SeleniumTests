using OpenQA.Selenium;

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

        public IWebElement InventoryList => _driver.FindElement(By.Id("inventory_container"));

        public IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));
    }
}