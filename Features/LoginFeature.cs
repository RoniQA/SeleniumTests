using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using SeleniumTests.Steps;

namespace SeleniumTests.Features
{
    public class LoginFeature : FeatureFixture
    {
        [Scenario]
        public void Successful_login()
        {
            using var steps = new LoginSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_on_login_page(),
                _ => steps.When_I_login_with_valid_credentials(),
                _ => steps.Then_I_should_see_the_inventory_page()
            );
        }
        [Scenario]
        public void Login_with_invalid_password()
        {
            using var steps = new LoginSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_on_login_page(),
                _ => steps.When_I_login_with_invalid_password(),
                _ => steps.Then_I_should_see_an_error_message()
            );
        }
        [Scenario]
        public void Login_with_invalid_username()
        {
            using var steps = new LoginSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_on_login_page(),
                _ => steps.When_I_login_with_invalid_username(),
                _ => steps.Then_I_should_see_a_login_error()
            );
        }
        [Scenario]
        public void Login_with_empty_fields()
        {
            using var steps = new LoginSteps();

            Runner.RunScenario(
                _ => steps.Given_I_am_on_login_page(),
                _ => steps.When_I_attempt_to_login_with_empty_fields(),
                _ => steps.Then_I_should_see_required_field_error()
            );
        }
    }
}