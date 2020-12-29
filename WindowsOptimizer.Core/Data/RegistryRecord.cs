using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Win32;

namespace WindowsOptimizer.Core.Data {
	public class RegistryRecord : IRegistryRecord {
		#region Properties and Fields
		public RegistryKey Root { get; }
		public string Key { get; }
		public string ValueName { get; }
		public object Value { get; }
		public RegistryValueKind ValueKind { get; }

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

			throw new ArgumentException("This root type is currently not supported!", nameof(root));
		}

		public override string ToString() {
			return Root + "\\" + Key + ", " + ValueName + "=" + Value + " (" + ValueKind.ToString() + ")";
		}

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}

			if (ReferenceEquals(this, obj)) {
				return true;
			}

			if (GetType() != obj.GetType()) {
				return false;
			}

			return Equals(obj as RegistryRecord);
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}

		public bool Equals(IRegistryRecord other) {
			if (other == null) {
				return false;
			}

			if (ReferenceEquals(this, other)) {
				return true;
			}

			if (GetType() != other.GetType()) {
				return false;
			}

			//IList<int> comparisonResult = new List<int>();
			//IList<PropertyInfo> thisProperties = GetType().GetProperties().ToList();
			//IList<PropertyInfo> otherProperties = other.GetType().GetProperties().ToList();

			//if (thisProperties.Count != otherProperties.Count) {
			//    return false;
			//}

			IList<int> comparisonResult = new List<int> {
				string.Compare(Root.ToString(), other.Root.ToString()),
				string.Compare(Key,other.Key),
				string.Compare(ValueName,other.ValueName),
				string.Compare(Value.ToString(),other.Value.ToString()),
				string.Compare(ValueKind.ToString(),other.ValueKind.ToString())
			};

			if (comparisonResult.Sum() == 0) {
				return true;
			} else {
				return false;
			}
		}

		public static bool operator ==(RegistryRecord recordLeft, RegistryRecord recordRight) {
			return ReferenceEquals(recordLeft, recordRight);
		}

		public static bool operator !=(RegistryRecord recordLeft, RegistryRecord recordRight) {
			return ReferenceEquals(recordLeft, recordRight);
		}
	}
}
