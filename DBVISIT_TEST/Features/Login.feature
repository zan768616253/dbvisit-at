Feature: Login

Check login

@Login
Scenario Outline: 1.Login with available username and passwords
	Given I am on Dbvisit web
	When I input right <username> and <passwords>
	Then I can login successfully
Examples:
	| username | passwords |
	| admin    | admin    |



@Login
Scenario Outline: 2.Login with unavailable username and  passwords
	Given I am on Dbvisit web
	When I input unavailable <username> and <passwords>
	Then I can not login and see a fail message
Examples:
	| username | passwords |
	| admin    | 123456    |