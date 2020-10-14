using System;
using System.IO;

namespace WindowsOptimizer.GUI.CLI {
    public class Program {
        private static void Main(string[] args) {
            System.Threading.Tasks.Task<string> text = File.ReadAllTextAsync(@"D:\test.json");
            Console.WriteLine(text.Result);
            Console.ReadLine();
        }
    }
}
