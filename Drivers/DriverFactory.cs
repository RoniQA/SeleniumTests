using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // remove se quiser ver o navegador abrindo
            return new ChromeDriver(options);
        }
    }
}