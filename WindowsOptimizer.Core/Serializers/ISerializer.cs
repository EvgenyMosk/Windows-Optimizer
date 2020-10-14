using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WindowsOptimizer.Core.Data;

namespace WindowsOptimizer.Core.Serializers {
    public interface ISerializer {
        IRegistryRecord StringToRegistryRecord(string textToConvertFrom);
        IEnumerable<IRegistryRecord> StringToMultipleRegistryRecords(string textToConvertFrom);
        IEnumerable<IRegistryRecord> StringToMultipleRegistryRecords(string[] textToConvertFrom);
    }
}