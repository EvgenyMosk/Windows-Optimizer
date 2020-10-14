using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.ExtensionMethods;

namespace WindowsOptimizer.Core.Serializers {
    public class TxtToRegistryRecordSerializer : ISerializer {
        public IRegistryRecord StringToRegistryRecord(string textToConvertFrom) {
            if (StringExtensions.IsNullOrEmptyWhitespace_Ext(textToConvertFrom)) {
                throw new ArgumentNullException(nameof(textToConvertFrom));
            }

            string[] text = textToConvertFrom.Split(new char[] { ',' });

            ValidateInputData(text);

            string tmpRoot = GetRootFromRegistryPath(text[0]);
            string registryPath = GetRegistryPathFromString(text[0], tmpRoot);

            RegistryKey root = RegistryRecord.ConvertStringToRegistryKey(tmpRoot);
            string key = registryPath;
            string valueName = text[1];
            string value = text[2];
            RegistryValueKind valueKind = RegistryValueKind.DWord; // Default value

            if (text.Length == 4) {
                valueKind = (RegistryValueKind)Enum.Parse(typeof(RegistryValueKind), text[3], true);
            }

            return new RegistryRecord(root, registryPath, valueName, value, valueKind);
        }

        private void ValidateInputData(string[] text) {
            if (text.Length > 5 || text.Length < 2) {
                throw new ArgumentException("Given string contains not valid data!\nNo valid registry path was given!", nameof(text));
            }
        }

        private string GetRootFromRegistryPath(string registryPath) {
            if (StringExtensions.IsNullOrEmptyWhitespace_Ext(registryPath)) {
                throw new ArgumentNullException(nameof(registryPath));
            }

            string[] tmp = registryPath.Split(new char[] { '\\' });

            return tmp[0];
        }

        private string GetRegistryPathFromString(string registryPath, string root) {
            if (StringExtensions.IsNullOrEmptyWhitespace_Ext(registryPath)) {
                throw new ArgumentNullException(nameof(registryPath));
            }
            if (string.IsNullOrEmpty(root.Trim())) {
                throw new ArgumentNullException(nameof(root));
            }
            if (!registryPath.Contains(root)) {
                throw new ArgumentException("Given RegistryPath does not contain the given Root!");
            }

            root = root + "\\";

            registryPath = registryPath.Remove(0, root.Length);

            return registryPath;
        }

        public IEnumerable<IRegistryRecord> StringToMultipleRegistryRecords(string textToConvertFrom) {
            if (StringExtensions.IsNullOrEmptyWhitespace_Ext(textToConvertFrom)) {
                throw new ArgumentNullException(nameof(textToConvertFrom));
            }

            string[] textToConvertFromSplitted = textToConvertFrom.Split(new char[] { '\n' });

            return StringToMultipleRegistryRecords(textToConvertFromSplitted);
        }

        public IEnumerable<IRegistryRecord> StringToMultipleRegistryRecords(string[] textToConvertFrom) {
            if (textToConvertFrom == null || textToConvertFrom.Length == 0) {
                throw new ArgumentNullException(nameof(textToConvertFrom));
            }

            IList<IRegistryRecord> result = new List<IRegistryRecord>();

            foreach (string row in textToConvertFrom) {
                if (!StringExtensions.IsNullOrEmptyWhitespace_Ext(row)) {
                    IRegistryRecord tmp = StringToRegistryRecord(row);
                    result.Add(tmp);
                }
            }

            return result;
        }
    }
}
