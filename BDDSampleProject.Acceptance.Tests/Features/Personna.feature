Feature: Personna

Using a Personna to have a context


Scenario: User without rights couln't use our ComplexCalculator
	Given "NoOne" load the calculator
	And The first number is 1
	And The second number is 2
	When I make the Operation "Add"
	Then The exception should be "Calculator is not available"

Scenario: User without operations couln't use our ComplexCalculator
	Given "Bob" load the calculator
	And The first number is 1
	And The second number is 2
	When I make the Operation "Add"
	Then The exception should be "Operation : Add not found"