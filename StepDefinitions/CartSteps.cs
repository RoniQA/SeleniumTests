using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumTests.StepDefinitions
{
    public class CartSteps : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly CartPage _cartPage;

        public CartSteps()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);

            _loginPage = new LoginPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        public void Given_I_am_logged_in()
        {
            _loginPage.Navigate();
            _loginPage.Login("standard_user", "secret_sauce");
            Assert.True(_loginPage.IsInventoryVisible);
        }

        public void When_I_add_an_item_to_cart()
        {
            _cartPage.AddFirstItemToCart();
        }

        public void Then_The_cart_should_have_1_item()
        {
            Assert.Equal(1, _cartPage.CartBadge());
        }

        public void When_I_remove_the_item_from_cart()
        {
            _cartPage.GoToCart();
            _cartPage.RemoveFirstItem();
        }

        public void Then_The_cart_should_be_empty()
        {
            bool isCartEmpty = _cartPage.IsCartEmpty();
            Assert.True(isCartEmpty);
        }

        public void When_I_continue_shopping()
        {
            _cartPage.GoToCart();
            Assert.True(_cartPage.IsContinueShoppingButtonVisible(), "Continue Shopping button is not visible.");
            _cartPage.ContinueShopping();
        }

        public void Then_I_should_be_back_to_inventory_page()
        {
            Assert.True(_loginPage.IsInventoryVisible);
        }

        public void When_I_checkout()
        {
            _cartPage.GoToCart();
            _cartPage.Checkout();
        }

        public void Then_I_should_see_checkout_information_page()
        {
            Assert.True(_cartPage.IsOnCheckoutPage());
        }

        public void Dispose() => _driver.Quit();
    }
}