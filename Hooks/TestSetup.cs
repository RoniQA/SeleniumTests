using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace SeleniumTests.Hooks
{
    [SetUpFixture]
    public class TestSetup
    {
        public static ExtentReports Extent;
        private static ExtentHtmlReporter HtmlReporter;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Directory.CreateDirectory("TestResults");

            HtmlReporter = new ExtentHtmlReporter("TestResults/ExtentReport.html");
            HtmlReporter.Config.DocumentTitle = "Relatório de Testes - Selenium";
            HtmlReporter.Config.ReportName = "Resultados de Execução";
            HtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            Extent = new ExtentReports();
            Extent.AttachReporter(HtmlReporter);
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Extent.Flush();
        }
    }
}