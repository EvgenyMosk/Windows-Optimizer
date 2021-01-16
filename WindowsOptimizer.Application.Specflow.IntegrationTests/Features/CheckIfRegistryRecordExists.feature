Feature: CheckIfRegistryRecordExists

Check if a Given Registry Record (Registry Entry) exists

@Registry,@RegistryRecord,@UsingResourcesWeHaveNoControlOver
Scenario: Check that Registry Record Created by Microsoft exists
	Given A record "HKEY_CURRENT_USER, Control Panel\Desktop, MenuShowDelay" exist in Windows Registry 
	Then  We see the verification that the record exists (it's value doesn't matter)
