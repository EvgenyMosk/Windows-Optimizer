using System;
using System.IO;

using WindowsOptimizer.Core.ExtensionMethods;

namespace WindowsOptimizer.Core.File_Readers {
	public class FileReader : IFileReader {
		public string ReadFromFile(string pathToFile) {
			if (StringExtensions.IsNullOrEmptyWhitespace_Ext(pathToFile)) {
				throw new ArgumentNullException(nameof(pathToFile));
			}

			if (!File.Exists(pathToFile)) {
				throw new FileNotFoundException("The file cannot be found!", pathToFile);
			}

			string fileContent = File.ReadAllText(pathToFile);
			return fileContent;
		}
	}
}