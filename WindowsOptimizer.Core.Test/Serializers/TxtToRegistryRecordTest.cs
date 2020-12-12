using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

using WindowsOptimizer.Core.Data;
using WindowsOptimizer.Core.Exceptions;
using WindowsOptimizer.Core.Serializers;

namespace WindowsOptimizer.Core.Serializers.Test {
    // Consider transitioning to an object-test model (virtual methods)
    [TestClass()]
    public class TxtToRegistryRecordTest {
        #region StringToRegistryRecord tests
        [TestMethod()]
        public void StringToRegistryRecordTest_EmptyString_ExpectArgumentNullException() {
            string textToConvertFrom = string.Empty;
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                Data.IRegistryRecord tmp = txtToRegistryRecordSerialize.StringToRegistryRecord(textToConvertFrom);
            } catch (ArgumentNullException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToRegistryRecordTest_WhitespaceString_ExpectArgumentNullException() {
            string textToConvertFrom = @" ";
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                Data.IRegistryRecord tmp = txtToRegistryRecordSerialize.StringToRegistryRecord(textToConvertFrom);
            } catch (ArgumentNullException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToRegistryRecordTest_StringWithInvalidRegistryPath_InvalidRegistryPathException() {
            string textToConvertFrom = "Some strange text for test. Another Sentence";
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                Data.IRegistryRecord tmp = txtToRegistryRecordSerialize.StringToRegistryRecord(textToConvertFrom);
            } catch (ArgumentException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToRegistryRecordTest_StringWithExistingRegistryPath_NewRegistryPathObject() {
            string textToConvertFrom = @"HKEY_CURRENT_USER\Control Panel\Desktop,MenuShowDelay,1";
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            RegistryKey root = Registry.CurrentUser;
            string key = @"Control Panel\Desktop";
            string valueName = "MenuShowDelay";
            string value = "1";
            RegistryValueKind valueKind = RegistryValueKind.DWord;

            RegistryRecord expectedRegistryRecord = new RegistryRecord(root, key, valueName, value, valueKind);

            RegistryRecord actualRecord = (RegistryRecord)txtToRegistryRecordSerialize.StringToRegistryRecord(textToConvertFrom);

            Assert.AreEqual(expectedRegistryRecord, actualRecord);
        }

        [TestMethod()]
        public void StringToRegistryRecordTest_StringWithExistingRegistryPathWithRegKind_NewRegistryPathObject() {
            string textToConvertFrom = @"HKEY_CURRENT_USER\Control Panel\Desktop,MenuShowDelay,1,QWord";
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            RegistryKey root = Registry.CurrentUser;
            string key = @"Control Panel\Desktop";
            string valueName = "MenuShowDelay";
            string value = "1";
            RegistryValueKind valueKind = RegistryValueKind.QWord;

            RegistryRecord expectedRegistryRecord = new RegistryRecord(root, key, valueName, value, valueKind);

            RegistryRecord actualRecord = (RegistryRecord)txtToRegistryRecordSerialize.StringToRegistryRecord(textToConvertFrom);

            Assert.AreEqual(expectedRegistryRecord, actualRecord);
        }
        #endregion
        #region StringToMultipleRegistryRecords
        [TestMethod()]
        public void StringToMultipleRegistryRecords_NullArgument_ExpectArgumentNullException() {
            List<string> textToConvertFrom = new List<string> {
                null
            };
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                IEnumerable<IRegistryRecord> tmp = txtToRegistryRecordSerialize.StringToMultipleRegistryRecords(textToConvertFrom);
            } catch (NullReferenceException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToMultipleRegistryRecords_EmptyString_ExpectArgumentNullException() {
            List<string> textToConvertFrom = new List<string> {
                string.Empty
            };
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                IEnumerable<IRegistryRecord> tmp = txtToRegistryRecordSerialize.StringToMultipleRegistryRecords(textToConvertFrom);
            } catch (ArgumentNullException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToMultipleRegistryRecords_TwoEmptyStrings_ExpectArgumentNullException() {
            List<string> textToConvertFrom = new List<string> {
                "",
                ""
            };
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                IEnumerable<IRegistryRecord> tmp = txtToRegistryRecordSerialize.StringToMultipleRegistryRecords(textToConvertFrom);
            } catch (ArgumentNullException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToMultipleRegistryRecords_WhitespaceString_ExpectArgumentNullException() {
            List<string> textToConvertFrom = new List<string> {
                " "
            };
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                IEnumerable<IRegistryRecord> tmp = txtToRegistryRecordSerialize.StringToMultipleRegistryRecords(textToConvertFrom);
            } catch (ArgumentNullException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToMultipleRegistryRecords_TwoWhitespaceStrings_ExpectArgumentNullException() {
            List<string> textToConvertFrom = new List<string> {
                " ",
                " "
            };
            TxtToRegistryRecordSerializer txtToRegistryRecordSerialize = new TxtToRegistryRecordSerializer();

            bool exceptionWasThrown = false;

            try {
                IEnumerable<IRegistryRecord> tmp = txtToRegistryRecordSerialize.StringToMultipleRegistryRecords(textToConvertFrom);
            } catch (ArgumentNullException) {
                exceptionWasThrown = true;
            }

            Assert.IsTrue(exceptionWasThrown);
        }

        [TestMethod()]
        public void StringToMultipleRegistryRecords_TwoStringsBothFilledCorrectly_ExpectTwoRegistryRecords() {
            List<string> textToConvertFrom = new List<string> {
                "HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer,NoDriveTypeAutoRun,111",
                "HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer,NoDriveTypeAutoRun,112"
            };
            List<IRegistryRecord> expectedRegistryRecords = new List<IRegistryRecord> {
                new RegistryRecord("HKEY_LOCAL_MACHINE", @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer","NoDriveTypeAutoRun", "111"),
                new RegistryRecord("HKEY_LOCAL_MACHINE", @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer","NoDriveTypeAutoRun", "112")
            };

            TxtToRegistryRecordSerializer txtToRegistryRecordSerializer = new TxtToRegistryRecordSerializer();

            IEnumerable<IRegistryRecord> actualRegistryRecords = txtToRegistryRecordSerializer.StringToMultipleRegistryRecords(textToConvertFrom);

            int i = 0;
            foreach (IRegistryRecord actualRecord in actualRegistryRecords) {
                Assert.AreEqual(expectedRegistryRecords[i], actualRecord);
                i++;
            }
        }
        //[TestMethod()]
        public void StringToMultipleRegistryRecords_ThreeStringsSecondIsEmpty_ExpectArgumentNullException() {
            Assert.Fail();
        }
        //[TestMethod()]
        public void StringToMultipleRegistryRecords_ThreeStringsSecondIsNull_ExpectArgumentNullException() {
            Assert.Fail();
        }
        #endregion
    }
}