using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

using WindowsOptimizer.Core.Data;

namespace WindowsOptimizer.Core.RegistryEditors {
    public interface IRegistryEditor {
        bool SetRegistryValue(IRegistryRecord registryRecord);
        bool SetRegistryValue(string keyName, string valueName, object valueToSet, RegistryValueKind valueKind);
        bool RegistryRecordExists(IRegistryRecord registryRecord);
        bool RegistryRecordExists(string keyName, string valueName);
    }
}