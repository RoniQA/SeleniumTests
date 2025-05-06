using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Opcional: roda sem abrir o navegador
            options.AddArgument("--disable-gpu");
            return new ChromeDriver(options);
        }
    }
}
