using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace WindowsOptimizer.Core.Data.Tests {
	[TestClass()]
	public class RegistryRecordTests {
		[TestMethod()]
		public void ConvertStringToRegistryKey_NotSupportedRegistryRoot_ExpectArgumentException() {
			string root = "HKEY_iMaGiNeD_rOoT_tYpE";
			RegistryKey registryKey = null;

			bool exceptionWasTrown = false;

			try {
				registryKey = RegistryRecord.ConvertStringToRegistryKey(root);
			} catch (ArgumentException) {
				exceptionWasTrown = true;
			}

			Assert.IsTrue(exceptionWasTrown);
			Assert.IsNull(registryKey);
		}

		[TestMethod()]
		public void ConvertStringToRegistryKey_LocalMachineRootStringLowerCase_ExpectLocalMachineRootObj() {
			string root = "hkey_local_machine";
			RegistryKey expectedRegistryKey = Registry.LocalMachine;

			RegistryKey actualRegistryKey = RegistryRecord.ConvertStringToRegistryKey(root);

			Assert.AreEqual(expectedRegistryKey, actualRegistryKey);
		}

		[TestMethod()]
		public void ConvertStringToRegistryKey_LocalMachineRootStringUpperCase_ExpectLocalMachineRootObj() {
			string root = "HKEY_LOCAL_MACHINE";
			RegistryKey expectedRegistryKey = Registry.LocalMachine;

			RegistryKey actualRegistryKey = RegistryRecord.ConvertStringToRegistryKey(root);

			Assert.AreEqual(expectedRegistryKey, actualRegistryKey);
		}

		[TestMethod()]
		public void ConvertStringToRegistryKey_CurrentUserRootString_ExpectCurrentUserRootObj() {
			string root = "HKEY_CURRENT_USER";
			RegistryKey expectedRegistryKey = Registry.CurrentUser;

			RegistryKey actualRegistryKey = RegistryRecord.ConvertStringToRegistryKey(root);

			Assert.AreEqual(expectedRegistryKey, actualRegistryKey);
		}

		[TestMethod()]
		public void ConvertStringToRegistryKey_ClassesRootString_ExpectClassesRootObj() {
			string root = "hkey_CLASSES_root";
			RegistryKey expectedRegistryKey = Registry.ClassesRoot;

			RegistryKey actualRegistryKey = RegistryRecord.ConvertStringToRegistryKey(root);

			Assert.AreEqual(expectedRegistryKey, actualRegistryKey);
		}
	}
}