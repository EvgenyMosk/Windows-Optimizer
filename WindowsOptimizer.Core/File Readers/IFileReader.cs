using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsOptimizer.Core.File_Readers {
    public interface IFileReader {
        string ReadFromFile(string pathToFile);
    }
}
