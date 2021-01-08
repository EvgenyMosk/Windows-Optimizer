using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsOptimizer.Core.File_Readers.Tests {
	[TestClass()]
	public class FileReaderTests {
		private FileReader fileReader_testSubject;

		[TestInitialize()]
		public void TestInit() {
			fileReader_testSubject = new FileReader();
		}

		#region ReadFromFile tests
		[TestMethod()]
		public void ReadFromFile_NullString_ExpectFalse() {
			string pathToFile = null;
			bool exceptionWasThrown = false;

			try {
				fileReader_testSubject.ReadFromFile(pathToFile);
			} catch (ArgumentNullException) {
				exceptionWasThrown = true;
			}

			Assert.IsTrue(exceptionWasThrown);
		}

		[TestMethod()]
		public void ReadFromFile_EmptyString_ExpectFalse() {
			string pathToFile = string.Empty;
			bool exceptionWasThrown = false;

			try {
				fileReader_testSubject.ReadFromFile(pathToFile);
			} catch (ArgumentNullException) {
				exceptionWasThrown = true;
			}

			Assert.IsTrue(exceptionWasThrown);
		}

		[TestMethod()]
		public void ReadFromFile_Whitespace_ExpectFalse() {
			string pathToFile = @" ";
			bool exceptionWasThrown = false;

			try {
				fileReader_testSubject.ReadFromFile(pathToFile);
			} catch (ArgumentNullException) {
				exceptionWasThrown = true;
			}

			Assert.IsTrue(exceptionWasThrown);
		}
		#endregion
	}
}