Feature: MyAccount
	In order to use all functionallities
	As a user
	I want to be able to manage my account

@mytag
Scenario: User can log in
	Given user opens sign in page
	And enters correct credentials
	When user submits the login form
	Then user will be logged in


Scenario: User can open my wishlist page
	Given user opens sign in page
	And enters correct credentials
	Given user submits the login form
	When user opens my wishlist
	Then user can add new wishlist

	Scenario: User can create an acount
	Given user opens sign in page
	And initiates a flow for creating an acount
	And user enters all required personal details
	When submits the sign up form
	Then user will be logged in
	And user's full name is displayed

	

