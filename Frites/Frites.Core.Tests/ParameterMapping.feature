Feature: ParameterMapping
	In order to prove that Nhibernate is working
	As this project's programmer
	I want to be save an entity and retrieve it

Scenario: Save Item
	When I save Item DRHR-159 with description ballpen
	Then I should have Item DRHR-159 with description ballpen
