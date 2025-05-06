using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Pages;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Tests
{
    public class LoginTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // remove se quiser ver o navegador
            options.AddArgument("--disable-gpu");
            _driver = new ChromeDriver(options);
        }

        [Test]
        public void Login_WithInvalidCredentials_ShouldDisplayErrorMessage()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.GoTo();
            loginPage.Login("invalid_user", "invalid_pass");

            Assert.IsTrue(loginPage.GetErrorMessage().Contains("Username and password do not match"), "Erro de login não exibido corretamente.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}