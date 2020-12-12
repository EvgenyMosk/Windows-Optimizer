using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.File_Readers;
using WindowsOptimizer.Core.RegistryEditors;
using WindowsOptimizer.Core.Serializers;

namespace WindowsOptimizer.Application {
    public class RegistryEditorApplication : IRegistryEditorApplication {
        public IList<IRegistryRecord> PendingRegistryRecordsChanges { get; }
        public ISerializer Serializer { get; }
        public IRegistryEditor RegistryEditor { get; }
        public IFileReader FileReader { get; }

        public RegistryEditorApplication(ISerializer serializer, IRegistryEditor registryEditor, IFileReader fileReader) {
            Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            RegistryEditor = registryEditor ?? throw new ArgumentNullException(nameof(registryEditor));
            FileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        }

        public IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(IEnumerable<string> textToParse) {
            return Serializer.StringToMultipleRegistryRecords(textToParse);
        }

        public string ReadFromFile(string pathToFile) {
            return FileReader.ReadFromFile(pathToFile);
        }

        public bool RegistryRecordExists(IRegistryRecord registryRecord) {
            return RegistryEditor.RegistryRecordExists(registryRecord);
        }

        public IDictionary<IRegistryRecord, bool> RegistryRecordsExist(IEnumerable<IRegistryRecord> registryRecords) {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> SetRegistryValues(IEnumerable<IRegistryRecord> registryRecords) {
            IList<bool> registryChangesResult = new List<bool>();

            foreach (IRegistryRecord regRecord in registryRecords) {
                bool res = RegistryEditor.SetRegistryValue(regRecord);
                registryChangesResult.Add(res);
            }

            return registryChangesResult;
        }
    }
}
