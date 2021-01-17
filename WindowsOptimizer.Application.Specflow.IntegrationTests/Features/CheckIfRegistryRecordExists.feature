Feature: CheckIfRegistryRecordExists

Check if a Given Registry Record (Registry Entry) exists

Background: 
 Given User have a Registry Editor App

@Registry,@RegistryRecord,@UsingResourcesWeHaveNoControlOver
Scenario: Check that Registry record Created by Microsoft by default exists
	Given A Registry record "HKEY_CURRENT_USER\Control Panel\Desktop,MenuShowDelay"
	  And User wants to check if this record exist in Windows Registry 
	 Then The verification result equals to "true"

@Registry,@RegistryRecord,@UsingResourcesWeHaveNoControlOver
Scenario: Check that a given Registry record NOT exists
	Given A Registry record "HKEY_CURRENT_USER\Some Imagined Path\Test,SomeValueNameThatShouldNotExist"
	  And User wants to check if this record exist in Windows Registry
	 Then The verification result equals to "false"