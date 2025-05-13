using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using SeleniumTests.StepDefinitions;

namespace SeleniumTests.Features
{
    public class CartFeature : FeatureFixture
    {
        [Scenario]
        public void Add_item_to_cart()
        {
            using var steps = new CartSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_logged_in(),
                _ => steps.When_I_add_an_item_to_cart(),
                _ => steps.Then_The_cart_should_have_1_item()
            );
        }

        [Scenario]
        public void Remove_item_from_cart()
        {
            using var steps = new CartSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_logged_in(),
                _ => steps.When_I_add_an_item_to_cart(),
                _ => steps.When_I_remove_the_item_from_cart(),
                _ => steps.Then_The_cart_should_be_empty()
            );
        }

        [Scenario]
        public void Continue_shopping_from_cart()
        {
            using var steps = new CartSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_logged_in(),
                _ => steps.When_I_add_an_item_to_cart(),
                _ => steps.When_I_continue_shopping(),
                _ => steps.Then_I_should_be_back_to_inventory_page()
            );
        }

        [Scenario]
        public void Checkout_after_adding_item()
        {
            using var steps = new CartSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_logged_in(),
                _ => steps.When_I_add_an_item_to_cart(),
                _ => steps.When_I_checkout(),
                _ => steps.Then_I_should_see_checkout_information_page()
            );
        }
    }
}