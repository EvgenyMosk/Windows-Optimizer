namespace WindowsOptimizer.Core.ExtensionMethods {
	public static class StringExtensions {
		public static bool IsNullOrEmptyWhitespace_Ext(this string str) {
			if (str == null) {
				return true;
			}

			return string.IsNullOrEmpty(str.Trim());
		}
	}
}
