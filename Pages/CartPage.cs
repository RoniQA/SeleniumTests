using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace SeleniumTests.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void AddFirstItemToCart()
        {
            var button = _wait.Until(d => d.FindElement(By.CssSelector(".inventory_item button")));
            button.Click();
        }

        public int CartBadge()
        {
            var badge = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_badge")));
            return int.TryParse(badge.Text, out var count) ? count : 0;
        }

        public void GoToCart()
        {
            var cart = _wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("shopping_cart_link")));
            cart.Click();
        }

        public void RemoveFirstItem()
        {
            var removeButton = _wait.Until(driver => driver.FindElement(By.CssSelector(".cart_item button")));
            removeButton.Click();
        }

        public bool IsCartEmpty() =>
            !_driver.FindElements(By.ClassName("cart_item")).Any();

        public void ContinueShopping()
        {
            var continueButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("continue-shopping")));
            continueButton.Click();
        }

        public bool IsContinueShoppingButtonVisible()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("continue-shopping"))).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void Checkout()
        {
            var checkoutButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout")));
            checkoutButton.Click();
        }

        public bool IsOnCheckoutPage()
        {
            return _wait.Until(d => d.Url.Contains("checkout-step-one"));
        }
    }
}