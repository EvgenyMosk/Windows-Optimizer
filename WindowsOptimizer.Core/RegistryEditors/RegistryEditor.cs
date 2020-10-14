using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

using WindowsOptimizer.Core.Data;

namespace WindowsOptimizer.Core.RegistryEditors {
    public class RegistryEditor : IRegistryEditor {
        public bool SetRegistryValue(IRegistryRecord registryRecord) {
            if (registryRecord == null) {
                throw new ArgumentNullException(nameof(registryRecord));
            }

            string keyName = GetKeyName(registryRecord);
            string valueName = GetValueName(registryRecord);

            Registry.SetValue(keyName, valueName, registryRecord.Value, registryRecord.ValueKind);

            return true;
        }

        public bool SetRegistryValue(string keyName, string valueName, object valueToSet, RegistryValueKind valueKind) {
            if (ExtensionMethods.StringExtensions.IsNullOrEmptyWhitespace_Ext(keyName)) {
                throw new ArgumentNullException(nameof(keyName));
            }
            if (ExtensionMethods.StringExtensions.IsNullOrEmptyWhitespace_Ext(valueName)) {
                throw new ArgumentNullException(nameof(valueName));
            }
            if (valueToSet == null) {
                throw new ArgumentNullException(nameof(valueToSet));
            }

            Registry.SetValue(keyName, valueName, valueToSet, valueKind);

            return true;
        }

        public bool RegistryRecordExists(IRegistryRecord registryRecord) {
            if (registryRecord == null) {
                throw new ArgumentNullException(nameof(registryRecord));
            }

            string keyName = GetKeyName(registryRecord);
            string valueName = GetValueName(registryRecord);

            return RegistryRecordExists(keyName, valueName);
        }

        public bool RegistryRecordExists(string keyName, string valueName) {
            if (Registry.GetValue(keyName, valueName, null) == null) {
                return false;
            }
            return true;
        }

        private string GetKeyName(IRegistryRecord registryRecord) {
            string keyName = registryRecord.Root + "\\" + registryRecord.Key;
            return keyName;
        }

        private string GetValueName(IRegistryRecord registryRecord) {
            string valueName = registryRecord.ValueName;
            return valueName;
        }
    }
}
