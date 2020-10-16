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
    //Refactor to RegistryTweakClass
    public interface IRegistryEditorApplication {
        IList<IRegistryRecord> PendingRegistryRecordsChanges { get; }
        string PathToFile { get; set; } // Is it really need as setter here?
        // Consider ITweak interface => then Pending RegRecords should be like TweakList, of smth
        //Tweak: init     ITweak: applied-not, apply
        IRegistryEditor RegistryEditor { get; }
        ISerializer Serializer { get; set; } // Hide Serializer
        IFileReader FileReader { get; set; } // Hide FileReader
        bool RegistryRecordExists(IRegistryRecord registryRecord);
        IDictionary<IRegistryRecord, bool> RegistryRecordsExist(IEnumerable<IRegistryRecord> registryRecords);
        string ReadFromFile();
        string ReadFromFile(string pathToFile);
        IRegistryRecord CreateRegistryRecordObj(string root, string key, string valueName, string value, RegistryValueKind kind);
        // Use IEnumerable<string> instead of 2 diff methods
        IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(string textToParse);
        IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(string[] testToParse);
        // Same as above
        bool SetRegistryValue(IRegistryRecord registryRecord);
        IEnumerable<bool> SetRegistryValues(IEnumerable<IRegistryRecord> registryRecords);
    }
}
