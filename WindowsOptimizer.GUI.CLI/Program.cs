using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

using WindowsOptimizer.Application;
using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.File_Readers;
using WindowsOptimizer.Core.RegistryEditors;
using WindowsOptimizer.Core.Serializers;

namespace WindowsOptimizer.GUI.CLI {
    internal class Program {
        private static RegistryEditorApplication _registryEditorApplication;
        private static void Main(string[] args) {
            _registryEditorApplication = new RegistryEditorApplication(new TxtToRegistryRecordSerializer(), new RegistryEditor(), new FileReader());

            PrintTextLine("Enter the path to the file with the Registry Values:\n");
            //string pathToFile = GetUserInput();
            string pathToFile = @"D:\test.txt";

            _registryEditorApplication.PathToFile = pathToFile;

            //string keyName = "HKEY_CURRENT_USER\\Control Panel\\Desktop";
            //string valueName = "MenuShowDelay";

            string[] text = _registryEditorApplication.ReadFromFile().Split(new char[] { '\n' });

            List<string> fileContent = new List<string>(text);

            IEnumerable<IRegistryRecord> registryRecords = _registryEditorApplication.CreateRegistryRecordsObjs(fileContent);

            foreach (IRegistryRecord regRecord in registryRecords) {
                string recordExistsTxt = "";

                if (_registryEditorApplication.RegistryRecordExists(regRecord)) {
                    recordExistsTxt = "[+]";
                } else {
                    recordExistsTxt = "[X]";
                }

                PrintTextLine(recordExistsTxt + " " + regRecord.ToString());
            }

            //_registryEditorApplication.SetRegistryValue(registryRecords.Where(x => x.ValueName == "MenuShowDelay").FirstOrDefault());

            Console.ReadLine();
        }
        #region Basic console IO methods
        private static string GetUserInput() {
            string userInput;

            userInput = Console.ReadLine();
            userInput = userInput.Trim();

            return userInput;
        }

        private static void PrintText(string text) {
            Console.Write(text);
        }

        private static void PrintTextLine(string text) {
            Console.WriteLine(text);
        }
        #endregion
        #region Structured console output methods
        private static void PrintGreeting() {

        }

        private static void PrintMenu() {

        }

        private static void PrintRegistryRecord() {

        }
        #endregion
    }
}
