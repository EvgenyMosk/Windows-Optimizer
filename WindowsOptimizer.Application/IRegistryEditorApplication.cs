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
        // Consider ITweak interface => then Pending RegRecords should be like TweakList, of smth
        //Tweak: init     ITweak: applied-not, apply
        IRegistryEditor RegistryEditor { get; }
        bool RegistryRecordExists(IRegistryRecord registryRecord);
        IDictionary<IRegistryRecord, bool> RegistryRecordsExist(IEnumerable<IRegistryRecord> registryRecords);
        string ReadFromFile(string pathToFile);
        IEnumerable<IRegistryRecord> CreateRegistryRecordsObjs(IEnumerable<string> textToParse);
        IEnumerable<bool> SetRegistryValues(IEnumerable<IRegistryRecord> registryRecords);
    }
}
