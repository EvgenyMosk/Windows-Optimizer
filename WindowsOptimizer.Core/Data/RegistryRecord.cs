using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace WindowsOptimizer.Core.Data {
    public class RegistryRecord : IRegistryRecord {
        //Refactor to use only getters
        #region Properties and Fields
        public RegistryKey Root { get; set; }
        public string Key { get; set; }
        public string ValueName { get; set; }
        public object Value { get; set; }
        public RegistryValueKind ValueKind { get; set; }

        #endregion
        #region Constructors
        public RegistryRecord(RegistryKey root, string key, string valueName, object value, RegistryValueKind kind = RegistryValueKind.DWord) {
            Root = root;
            Key = key;
            ValueName = valueName;
            Value = value;
            ValueKind = kind;
        }

        public RegistryRecord(string root, string key, string valueName, object value, RegistryValueKind kind = RegistryValueKind.DWord) {
            Root = ConvertStringToRegistryKey(root);
            Key = key;
            ValueName = valueName;
            Value = value;
            ValueKind = kind;
        }
        #endregion

        public static RegistryKey ConvertStringToRegistryKey(string root) {
            if (string.IsNullOrEmpty(root.Trim())) {
                throw new ArgumentNullException(nameof(root));
            }

            if (root.ToUpper() == "HKEY_LOCAL_MACHINE") {
                return Registry.LocalMachine;
            }
            if (root.ToUpper() == "HKEY_CURRENT_USER") {
                return Registry.CurrentUser;
            }
            if (root.ToUpper() == "HKEY_CLASSES_ROOT") {
                return Registry.ClassesRoot;
            }

            throw new ArgumentException("This type is currently not supported!", nameof(root));
        }

        public override string ToString() {
            return Root + "\\" + Key + ", " + ValueName + "=" + Value + " (" + ValueKind.ToString() + ")";
        }

        // Overload == and != operators
        // Use referenceEquals
        public override bool Equals(object obj) {
            return obj is RegistryRecord otherRegistryRecord
                && Root == otherRegistryRecord.Root
                && Key == otherRegistryRecord.Key
                && ValueName == otherRegistryRecord.ValueName
                && (string)Value == (string)otherRegistryRecord.Value
                && ValueKind == otherRegistryRecord.ValueKind;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        //Consider deleting this method
        public int CompareTo(IRegistryRecord other) {
            if (other == null) {
                throw new ArgumentNullException(nameof(other));
            }

            int compareToResult_Root = Root.ToString().CompareTo(other.Root.ToString());
            if (compareToResult_Root == 0) {
                int compareToResult_Key = Key.ToString().CompareTo(other.Key.ToString());
                if (compareToResult_Key == 0) {
                    int compareToResult_ValueName = ValueName.ToString().CompareTo(other.ValueName.ToString());
                    if (compareToResult_ValueName == 0) {
                        int compareToResult_Value = Value.ToString().CompareTo(other.Value.ToString());
                        if (compareToResult_Value == 0) {
                            return ValueKind.CompareTo(other.ValueKind);
                        } else {
                            return compareToResult_Value;
                        }
                    } else {
                        return compareToResult_ValueName;
                    }
                } else {
                    return compareToResult_Key;
                }
            } else {
                return compareToResult_Root;
            }
        }
    }
}
