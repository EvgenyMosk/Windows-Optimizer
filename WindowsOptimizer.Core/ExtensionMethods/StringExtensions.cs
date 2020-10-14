using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsOptimizer.Core.ExtensionMethods {
    public static class StringExtensions {
        public static bool IsNullOrEmptyWhitespace_Ext(this string str) {
            return string.IsNullOrEmpty(str.Trim());
        }
    }
}
