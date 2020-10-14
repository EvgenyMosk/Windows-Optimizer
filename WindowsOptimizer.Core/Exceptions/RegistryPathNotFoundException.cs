using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsOptimizer.Core.Exceptions {
    public class RegistryPathNotFoundException : Exception {
        public RegistryPathNotFoundException() {
        }

        public RegistryPathNotFoundException(string message) : base(message) {
        }

        public RegistryPathNotFoundException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
