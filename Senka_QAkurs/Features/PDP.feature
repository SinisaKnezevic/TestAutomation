Feature: PDP
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@PDP @Test
Scenario: User can add product tocart
	Given user open dresses section
	And opens first product from the list
	Given increases quantity to 2
	When user clicks on add to cart button
	And proceed to checkout
	Then product is added to the cart
