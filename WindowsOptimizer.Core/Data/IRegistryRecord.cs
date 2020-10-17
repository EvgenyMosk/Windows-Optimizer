using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace WindowsOptimizer.Core.Data {
    public interface IRegistryRecord : IEquatable<IRegistryRecord> {
        RegistryKey Root { get; set; }
        string Key { get; set; }
        string ValueName { get; set; }
        object Value { get; set; }
        RegistryValueKind ValueKind { get; set; }
    }
}