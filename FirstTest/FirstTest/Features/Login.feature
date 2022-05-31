Feature: searching stakeholders

Background: 
Given I am loged in with credentials
	| email                     | password                                     |
	| AUTOMATION.PP@AMDARIS.COM | 10704-observe-MODERN-products-STRAIGHT-69112 |
@positive
Scenario: Search for a project stakeholder
	
	And i enter Projects page
	And i click on Stakeholders Tab
	When I search steakholder's name
	Then the stakeholder appears on the screen

@positive
Scenario: Editing retrospective note

	And I'm in Collaboration tab
	And i click edit button
	And i change  sprint rating
	And i change  status
	When i press Save button
	Then the changes are saved

@positive
Scenario: Checking error message when creating a retrospective note

	And I'm in Collaboration tab
	And I click Add Retrospective
	Given I don't introduce any symbols
	Then i get the error message

@negative
Scenario: Check if Save button enables when not changing the retrospective name

	And I'm in Collaboration tab
	And i click edit button
	And i change the retrospective name in the same one
	Then the save button should not activate



@positive
Scenario: CRUD a note

	And I'm in Collaboration tab
	And I click on notes tab
	And I click add note
	And I save the note
	Then i delete the note

@positive
Scenario: CRUD retrospective
	

	And I'm in Collaboration tab
	And I click Add Retrospective
	And I add a retrospective note
	Then i delete the retrospective note

@postitive
Scenario: CRUD stakeholder
	

	
	And i enter Projects page
	And i click on Stakeholders Tab
	And I add stakeholder
	Then I detele the stakeholder

@positive
Scenario: CRUD Objectives
	
	And i enter Projects page
	And I'm in Objectives tab
	And I add an objective
	Then I delete the objective

@positive
Scenario: CRUD Risks

	And i enter Projects page
	And i enter Risk tab
	And i add a risk
	Then i delete the risk