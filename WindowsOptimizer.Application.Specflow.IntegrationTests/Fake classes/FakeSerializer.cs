using System.Collections.Generic;

using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.Serializers;

namespace WindowsOptimizer.Application.Specflow.IntegrationTests.Fake_classes {
	internal class FakeSerializer : ISerializer {
		public IEnumerable<IRegistryRecord> StringToMultipleRegistryRecords(IEnumerable<string> textToConvertFrom) {
			throw new System.NotImplementedException();
		}

		public IRegistryRecord StringToRegistryRecord(string textToConvertFrom) {
			throw new System.NotImplementedException();
		}
	}
}
