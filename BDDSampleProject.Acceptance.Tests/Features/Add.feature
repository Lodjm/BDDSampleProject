@AddOperation
Feature: Add

This feature to have the sum of two natural integer

Scenario: Add two integers and retrieve the sum
	Given The first number is 1
	And The second number is 2
	When I make the Add Operation
	Then The result should be 3

Scenario Outline: Add Multiple two integers and retrieve the sum
	Given The first number is <first>
	And The second number is <second>
	When I make the Add Operation
	Then The result should be <result>

	Examples: 
	| first | second | result |
	| 1     | 2      | 3      |
	| 2     | 4      | 6      |
	| 3     | 8      | 11      |

Scenario: Add two integers and retrieve the sum with description
	Given The first number is 1
	And The second number is 2
	When I make the Add Operation
	Then The descriptive result shoud be 
	| Left Member | Right Member | Operation | Result |
	| 1           | 2            | Add       | 3      |