using System;

using WindowsOptimizer.Core.File_Readers;

namespace WindowsOptimizer.Application.Specflow.IntegrationTests.Fake_classes {
	internal class FakeFileReader : IFileReader {
		public string ReadFromFile(string pathToFile) {
			throw new NotImplementedException();
		}
	}
}
