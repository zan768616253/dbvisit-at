Feature: New Configuration-Postgres Database

A short summary of the feature

@ConfigHost
Scenario Outline: 1.Config Host
	Given I login Dbvisit system and go in New Configuration menu
	When I select primary host 
	When I select manual input port
	When I input database <username> and <passwords> and click connect button
	Then I can config primary host
	When I select standby host
	And I type <configuration_name> and <license_key>
	And I click create button
	Then I can see the database
Examples: 
| username | passwords | configuration_name | license_key                               |
| postgres | pg        | 00                 | 4jo6z-8aaai-u09b6-ijrr7-732l0-0m00u-o26sw |


