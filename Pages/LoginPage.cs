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

        public void Navigate() => _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        public void Login(string username, string password)
        {
            _driver.FindElement(By.Id("user-name")).SendKeys(username);
            _driver.FindElement(By.Id("password")).SendKeys(password);
            _driver.FindElement(By.Id("login-button")).Click();
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(By.CssSelector("[data-test='error']")).Text;
        }
    }
}