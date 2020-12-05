﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using WindowsOptimizer.Application;
using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.File_Readers;
using WindowsOptimizer.Core.RegistryEditors;
using WindowsOptimizer.Core.Serializers;

namespace WindowsOptimizer.GUI.CLI {
	internal class Program {
		private static RegistryEditorApplication _registryEditorApplication;
		private const string _abortprogstr = "Aborting program execution...";
		private static void Main(string[] args) {
			_registryEditorApplication = new RegistryEditorApplication(new TxtToRegistryRecordSerializer(), new RegistryEditor(), new FileReader());

			PrintTextLine("Enter the path to the file with the Registry Values:");
			PrintText("Path to file: ");
			string pathToFile = GetUserInput();

			string[] text = null;

			try {
				text = _registryEditorApplication.ReadFromFile(pathToFile).Split(new char[] { '\n' });
			} catch (FileNotFoundException) {
				PrintTextLine("The specified file was not found!");
				PrintTextLine(_abortprogstr);
				Console.ReadKey();
				return;
			}

			List<string> fileContent = new List<string>(text);

			if(fileContent==null || fileContent.Count == 0) {
				PrintTextLine("No content was extracted from a given file!");
				PrintTextLine(_abortprogstr);
				Console.ReadKey();
				return;
			}

			IEnumerable<IRegistryRecord> registryRecords = _registryEditorApplication.CreateRegistryRecordsObjs(fileContent);

			if (registryRecords == null || registryRecords.Count()==0) {
				PrintTextLine("No registry paths were extracted from a given file!\n" +
					"Check the file content for errors.");
				PrintTextLine(_abortprogstr);
				Console.ReadKey();
				return;
			}

			foreach (IRegistryRecord regRecord in registryRecords) {
				string recordExistsTxt = "";

				if (_registryEditorApplication.RegistryRecordExists(regRecord)) {
					recordExistsTxt = "[+]";
				} else {
					recordExistsTxt = "[X]";
				}
				
				PrintTextLine(recordExistsTxt + " " + regRecord.ToString());
			}

			_registryEditorApplication.SetRegistryValues(registryRecords);

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
