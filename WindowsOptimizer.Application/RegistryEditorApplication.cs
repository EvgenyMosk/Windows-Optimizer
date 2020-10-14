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
        public string PathToFile { get; set; }
        public ISerializer Serializer { get; set; }
        public IRegistryEditor RegistryEditor { get; set; }
        public IFileReader FileReader { get; set; }

        public RegistryEditorApplication(ISerializer serializer, IRegistryEditor registryEditor, IFileReader fileReader) {
            Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            RegistryEditor = registryEditor ?? throw new ArgumentNullException(nameof(registryEditor));
            FileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        }

        public IRegistryRecord CreateRegistryRecordObj(string root, string key, string valueName, string value, RegistryValueKind kind) {
            RegistryRecord registryRecord = new RegistryRecord(root, key, valueName, value, kind);
            return registryRecord;
        }

        public IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(string textToParse) {
            return Serializer.StringToMultipleRegistryRecords(textToParse);
        }

        public IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(string[] textToParse) {
            return Serializer.StringToMultipleRegistryRecords(textToParse);
        }

        public string ReadFromFile() {
            return ReadFromFile(PathToFile);
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

        public bool SetRegistryValue(IRegistryRecord registryRecord) {
            return RegistryEditor.SetRegistryValue(registryRecord);
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
