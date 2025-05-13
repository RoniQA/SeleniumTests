using SeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTests.Steps
{
	public class LogoutSteps : IDisposable
	{
		private readonly IWebDriver _driver;
		private readonly LoginPage _loginPage;

		public LogoutSteps()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());
			_driver = new ChromeDriver();
			_loginPage = new LoginPage(_driver);

			_loginPage.Navigate();
			_loginPage.Login("standard_user", "secret_sauce");
		}

		public void When_I_open_the_side_menu()
		{
			_loginPage.OpenMenu();
		}

		public void When_I_click_the_logout_button()
		{
			_loginPage.ClickLogout();
		}

		public void Then_I_should_be_redirected_to_the_login_page()
		{
			if (!_loginPage.IsLoginPageVisible())
				throw new Exception("User was not redirected to the login page.");
		}

		public void Dispose()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}