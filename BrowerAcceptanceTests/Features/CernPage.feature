Feature: CernPageFeature

Load and Search

@Browser
Scenario: Get Home page of Cern FR
	When I load the page of "https://www.home.cern/fr"
	Then The page title is "Home | CERN"

	
@Browser
Scenario: Get Top Ribbon
	Given I load the page of "https://www.home.cern/fr"
	When I retrieve the top ribbon
	Then The the text of the first link is "CERN Accélérateur de science"