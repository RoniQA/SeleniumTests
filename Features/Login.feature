Feature: Login Feature
  Scenario: Invalid Login Attempt
    Given I am on the login page
    When I enter invalid credentials
    Then I should see an error message