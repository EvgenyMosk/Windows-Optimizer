using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace WindowsOptimizer.Core.Data.Tests {
	[TestClass()]
	public class RegistryRecordTests {
		private RegistryRecord registryRecord_testSubject;

		[TestInitialize()]
		public void TestInit() {
			InitRegistryRecordTestSubject();
		}
		private void InitRegistryRecordTestSubject() {
			registryRecord_testSubject = new RegistryRecord(Registry.CurrentUser,
											"MyKey/SomePath",
											"TestValueName",
											"11",
											RegistryValueKind.DWord);
		}
		#region ConvertStringToRegistryKey tests
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
		#endregion
		#region Equals(object arg)
		[TestMethod()]
		public void EqualsObjArg_OtherTypeNullObj_ExpectFalse() {
			object otherObj = null;

			bool comparisonResult = registryRecord_testSubject.Equals(otherObj);

			Assert.IsFalse(comparisonResult);
		}

		[TestMethod()]
		public void EqualsObjArg_ThisTypeNullObj_ExpectFalse() {
			RegistryRecord otherObj = null;

			bool comparisonResult = registryRecord_testSubject.Equals((object)otherObj);

			Assert.IsFalse(comparisonResult);
		}

		[TestMethod()]
		public void EqualsObjArg_SameObj_ExpectTrue() {
			bool comparisonResult = registryRecord_testSubject.Equals((object)registryRecord_testSubject);

			Assert.IsTrue(comparisonResult);
		}

		[TestMethod()]
		public void EqualsObjArg_SameObjWithOtherPointerName_ExpectTrue() {
			RegistryRecord anotherPtr = registryRecord_testSubject;

			bool comparisonResult = registryRecord_testSubject.Equals((object)anotherPtr);

			Assert.IsTrue(comparisonResult);
		}

		[TestMethod()]
		public void EqualsObjArg_ThisTypeObjWithDifferentValues_ExpectFalse() {
			RegistryRecord registryRecordOther = new RegistryRecord(Registry.ClassesRoot,
												"Key",
												"ValueName",
												"",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject.Equals((object)registryRecordOther);

			Assert.IsFalse(comparisonResult);
		}

		[TestMethod()]
		public void EqualsObjArg_ThisTypeObjWithTheSameValues_ExpectTrue() {
			RegistryRecord registryRecordOther = new RegistryRecord(Registry.CurrentUser,
												"MyKey/SomePath",
												"TestValueName",
												"11",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject.Equals((object)registryRecordOther);

			Assert.IsTrue(comparisonResult);
		}
		#endregion
		#region Equals(RegistryRecord arg)
		[TestMethod()]
		public void EqualsIRegRecArg_NullObj_ExpectFalse() {
			RegistryRecord registryRecordOther = null;

			bool comparisonResult = registryRecord_testSubject.Equals(registryRecordOther);

			Assert.IsFalse(comparisonResult);
		}

		[TestMethod()]
		public void EqualsIRegRecArg_SameObj_ExpectTrue() {
			bool comparisonResult = registryRecord_testSubject.Equals(registryRecord_testSubject);

			Assert.IsTrue(comparisonResult);
		}

		[TestMethod()]
		public void EqualsIRegRecArg_SameObjOtherPtr_ExpectTrue() {
			IRegistryRecord registryRecordOther = registryRecord_testSubject;

			bool comparisonResult = registryRecord_testSubject.Equals(registryRecordOther);

			Assert.IsTrue(comparisonResult);
		}

		[TestMethod()]
		public void EqualsIRegRecArg_ThisTypeObjWithDifferentValues_ExpectFalse() {
			IRegistryRecord registryRecordOther = new RegistryRecord(Registry.ClassesRoot,
												"Key",
												"ValueName",
												"",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject.Equals(registryRecordOther);

			Assert.IsFalse(comparisonResult);
		}

		[TestMethod()]
		public void EqualsIRegRecArg_ThisTypeObjWithTheSameValues_ExpectTrue() {
			IRegistryRecord registryRecordOther = new RegistryRecord(Registry.CurrentUser,
												"MyKey/SomePath",
												"TestValueName",
												"11",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject.Equals(registryRecordOther);

			Assert.IsTrue(comparisonResult);
		}
		#endregion
		#region Operator == tests
		[TestMethod()]
		public void OperatorEqual_SameObjOtherPtr_ExpectTrue() {
			RegistryRecord registryRecordOther = registryRecord_testSubject;

			bool comparisonResult = registryRecord_testSubject == registryRecordOther;

			Assert.IsTrue(comparisonResult);
		}

		[TestMethod()]
		public void OperatorEqual_OtherObjWithDifferentValues_ExpectFalse() {
			RegistryRecord registryRecordOther = new RegistryRecord(Registry.ClassesRoot,
												"Key",
												"ValueName",
												"",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject == registryRecordOther;

			Assert.IsFalse(comparisonResult);
		}

		// The comparison in RegistryRecord.operator== is done via simply checking the Reference
		[TestMethod()]
		public void OperatorEqual_OtherObjWithTheSameValues_ExpectFalse() {
			RegistryRecord registryRecordOther = new RegistryRecord(Registry.CurrentUser,
												"MyKey/SomePath",
												"TestValueName",
												"11",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject == registryRecordOther;

			Assert.IsFalse(comparisonResult);
		}
		#endregion
		#region Operator != test
		[TestMethod()]
		public void OperatorNotEqual_SameObjOtherPtr_ExpectFalse() {
			RegistryRecord registryRecordOther = registryRecord_testSubject;

			bool comparisonResult = registryRecord_testSubject != registryRecordOther;

			Assert.IsFalse(comparisonResult);
		}

		[TestMethod()]
		public void OperatorNotEqual_OtherObjWithDifferentValues_ExpectTrue() {
			RegistryRecord registryRecordOther = new RegistryRecord(Registry.ClassesRoot,
												"Key",
												"ValueName",
												"",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject != registryRecordOther;

			Assert.IsTrue(comparisonResult);
		}

		// The comparison in RegistryRecord.operator!= is done via simply checking the Reference
		[TestMethod()]
		public void OperatorNotEqual_OtherObjWithTheSameValues_ExpectTrue() {
			RegistryRecord registryRecordOther = new RegistryRecord(Registry.CurrentUser,
												"MyKey/SomePath",
												"TestValueName",
												"11",
												RegistryValueKind.DWord);

			bool comparisonResult = registryRecord_testSubject != registryRecordOther;

			Assert.IsTrue(comparisonResult);
		}
		#endregion
	}
}