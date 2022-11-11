Feature: GameStartScenario

Description: This scenario is used to start the game. It is not intended to be used in the editor.

Scenario: Start the game
	Given I am on the homepage
	And I fill in "p1" with "Player1"
	And I fill in "p2" with "Player2"
	And I click on "submitPlayers"
	Then I should be on the game page	
