Feature: Login
This feature proves the 'happy-path' login capability
Scenario: Login using correct credentials
Given that I am on TheInternet login page
When I login with valid credentials
Then I see the Secure Area page
