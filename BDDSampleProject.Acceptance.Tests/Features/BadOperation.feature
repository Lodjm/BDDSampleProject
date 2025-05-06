Feature: BadOperation

The calculator throw an exception if operation type is not found
@BadCalculator
Scenario: Add two integers and retrieve the sum
	Given The first number is 1
	And The second number is 2
	When I make the Operation "Add"
	Then The exception should be "Operation : Add not found"

@BadCalculator
Scenario: Substract one integer to another one
#Substract is strange but cool
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Substract"
	Then The exception should be "Operation : Substract not found"

@BadCalculator	
Scenario: Multiply one integer to another one
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Multiply"
	Then The exception should be "Operation : Multiply not found"

@BadCalculator
Scenario: Divide one integer to another one
	Given The first number is 6
	And The second number is 3
	When I make the Operation "Divide"
	Then The exception should be "Operation : Divide not found"