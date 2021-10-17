using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

using TechTalk.SpecFlow;

using WindowsOptimizer.Application.Specflow.IntegrationTests.Fake_classes;
using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.RegistryEditors;

namespace WindowsOptimizer.Application.Specflow.IntegrationTests.Steps {
	[Binding]
	public sealed class CheckIfRegistryRecordExistsStepDefinition {
		private readonly ScenarioContext _scenarioContext;
		private RegistryEditorApplication _registryEditorApplication;
		private RegistryRecord _registryRecord;
		private bool _recordExists;

		public CheckIfRegistryRecordExistsStepDefinition(ScenarioContext scenarioContext) {
			_scenarioContext = scenarioContext;
		}

		[Given(@"User has a Registry Editor App")]
		public void GivenUserHaveRegistryEditorApp() {
			_registryEditorApplication = new RegistryEditorApplication(
												new FakeSerializer(),
												new RegistryEditor(), // Need a real RegistryEditor for test
												new FakeFileReader());
		}

		[Given(@"A Registry record ""(.*)""")]
		public void GivenARegistryRecord(string regRecord) {
			string[] regRecordSplit = regRecord.Split(new char[] { ',' });

			if (regRecordSplit.Length < 2 || regRecordSplit.Length > 4) {
				throw new ArgumentException("RegistryRecord should consist of at least 3 fields:\n" +
					" Root, Key, Value Name (Root and Key should be combined into 1).\n" + // e.g. "HKEY_CURRENT_USER\Key\Further_path"
					"Optional Parameters:\n" +
					"Value and Value Type.",
					nameof(regRecord));
			}

			string root = regRecordSplit[0].Split(new char[] { '\\' })[0];
			string key = regRecordSplit[0].Replace(root + "\\", "");
			string valueName = regRecordSplit[1];

			// Set defaults
			string value = "";
			RegistryValueKind valueKind = RegistryValueKind.DWord;

			// If "optional" parameters given - set them for RegistryRecord
			if (regRecordSplit.Length >= 3) {
				value = regRecordSplit[2];
			}
			if (regRecordSplit.Length == 4) {
				valueKind = (RegistryValueKind)Enum.Parse(typeof(RegistryValueKind), regRecordSplit[3], true);
			}

			_registryRecord = new RegistryRecord(root, key, valueName, value, valueKind);
		}

		[Given(@"User wants to check if this record exist in Windows Registry")]
		public void GivenUserWantsToCheckIfThisRecordExistInWindowsRegistry() {
			_recordExists = _registryEditorApplication.RegistryRecordExists(_registryRecord);
		}

		[Then(@"The verification result equals to ""(.*)""")]
		public void ThenUserSeeTheVerificationThatTheRecordExistsItTMatter(string expectedResult) {
			Assert.AreEqual(_recordExists, bool.Parse(expectedResult));
		}
	}
}
