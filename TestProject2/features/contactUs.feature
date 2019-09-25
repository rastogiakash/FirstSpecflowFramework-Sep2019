Feature: Test the contactUs functionality

@mytag
Scenario: Test the contactUs functionality
	Given I launch a Browser
	And Navigate to the URL
	When I populate every field in this form with an acceptable value
	And Click on the Send button
	Then The result should be confirmation message