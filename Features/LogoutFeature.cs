using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using SeleniumTests.Steps;

namespace SeleniumTests.Features
{
    public class LogoutFeature : FeatureFixture
    {
        [Scenario(Skip = "Ignorado temporariamente até ajuste do LogoutSteps")]
        public void Successful_logout()
        {
            using var loginSteps = new LoginSteps();
            using var logoutSteps = new LogoutSteps();

            Runner.RunScenario(
                _ => loginSteps.Given_I_am_on_login_page(),
                _ => loginSteps.When_I_login_with_valid_credentials(),
                _ => logoutSteps.When_I_open_the_side_menu(),
                _ => logoutSteps.When_I_click_the_logout_button(),
                _ => logoutSteps.Then_I_should_be_redirected_to_the_login_page()
            );
        }
    }
}