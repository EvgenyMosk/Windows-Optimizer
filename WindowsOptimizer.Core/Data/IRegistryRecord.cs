using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace WindowsOptimizer.Core.Data {
    public interface IRegistryRecord : IEquatable<IRegistryRecord> {
        RegistryKey Root { get; }
        string Key { get; }
        string ValueName { get; }
        object Value { get; }
        RegistryValueKind ValueKind { get; }
    }
}