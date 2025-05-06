Feature: Calculator

The calculator can call every operation

Rule: Standard Calculator

Scenario: Add two integers and retrieve the sum
	Given The first number is 1
	And The second number is 2
	When I make the Operation "Add"
	Then The result should be 3

	
Scenario: Substract one integer to another one
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Substract"
	Then The result should be 1

	
Scenario: Multiply one integer to another one
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Multiply"
	Then The result should be 6

	
Scenario: Divide one integer to another one
	Given The first number is 6
	And The second number is 3
	When I make the Operation "Divide"
	Then The result should be 2

@CalculatorBackground
Rule: Inversed Calculator
Background: 
	Given A DivideOperation with Type "Multiply"
	And A MultiplyOperation with Type "Divide"
	And A AddOperation with Type "Substract"
	And A SubstractOperation with Type "Add"
	And A Calculator with operations defined

Scenario: Add two integers and retrieve the result of a substract
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Add"
	Then The result should be 1
	
Scenario: Substract two integers and retrieve the result of an addition
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Substract"
	Then The result should be 5
	
Scenario: Multiply one integer to another one and retrieve the result of an Divide
	Given The first number is 6
	And The second number is 2
	When I make the Operation "Multiply"
	Then The result should be 3
	
Scenario: Divide one integer to another one and retrieve the result of an Multiply
	Given The first number is 3
	And The second number is 2
	When I make the Operation "Divide"
	Then The result should be 6


