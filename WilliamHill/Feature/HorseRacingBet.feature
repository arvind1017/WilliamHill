Feature: placing all the horse bet features

Scenario: placing a horse bet with out user authentication
	Given I open william hill website with out login credentials
	And I navigate to horse betting page
	When I choose the next available race 
	And I choose to place the bet on a user
	And I place a stake of '10.5' $ bet
	Then The confirmbet button should be enabled
