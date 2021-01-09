using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsOptimizer.Core.ExtensionMethods.Tests {
	[TestClass()]
	public class StringExtensionsTests {
		[TestMethod()]
		public void IsNullOrEmptyWhitespace_Ext_NullString_ExpectTrue() {
			string text = null;

			bool result = StringExtensions.IsNullOrEmptyWhitespace_Ext(text);

			Assert.IsTrue(result);
		}

		[TestMethod()]
		public void IsNullOrEmptyWhitespace_Ext_EmptyString_ExpectTrue() {
			string text = string.Empty;

			bool result = StringExtensions.IsNullOrEmptyWhitespace_Ext(text);

			Assert.IsTrue(result);
		}

		[TestMethod()]
		public void IsNullOrEmptyWhitespace_Ext_Whitespace_ExpectTrue() {
			string text = @" ";

			bool result = StringExtensions.IsNullOrEmptyWhitespace_Ext(text);

			Assert.IsTrue(result);
		}

		[TestMethod()]
		public void IsNullOrEmptyWhitespace_Ext_TextStr_ExpectFalse() {
			string text = "Some test text";

			bool result = StringExtensions.IsNullOrEmptyWhitespace_Ext(text);

			Assert.IsFalse(result);
		}
	}
}