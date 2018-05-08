Feature: Login
This feature proves the 'happy-path' login capability
Scenario: Login using correct credentials
Given that I am on TheInternet login page
When I login with valid credentials
Then I see the Secure Area page

Scenario: Login using incorrect credentials
This feature proves the 'error-path' when logging in
Given that I am on TheInternet login page
When I login with invalid credentials
Then I should see an invalid username message

