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
    public interface IRegistryEditorApplication {
        IList<IRegistryRecord> PendingRegistryRecordsChanges { get; }
        string PathToFile { get; set; }
        IRegistryEditor RegistryEditor { get; }
        ISerializer Serializer { get; set; }
        IFileReader FileReader { get; set; }
        bool RegistryRecordExists(IRegistryRecord registryRecord);
        IDictionary<IRegistryRecord, bool> RegistryRecordsExist(IEnumerable<IRegistryRecord> registryRecords);
        string ReadFromFile();
        string ReadFromFile(string pathToFile);
        IRegistryRecord CreateRegistryRecordObj(string root, string key, string valueName, string value, RegistryValueKind kind);
        IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(string textToParse);
        IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(string[] testToParse);
        bool SetRegistryValue(IRegistryRecord registryRecord);
        IEnumerable<bool> SetRegistryValues(IEnumerable<IRegistryRecord> registryRecords);
    }
}
