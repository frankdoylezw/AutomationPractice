Feature: Dropdown
	As an Automation User
	I want to be able to select from a dropdown
	So that I can do so in future projects


Scenario: Select From Dropdown
	Given I am on the dropdown example page
	When I click on the second item in the dropdown list
	Then Option 2 should be selected

