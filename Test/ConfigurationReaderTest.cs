using System;
using System.IO;
using AirTicketBusiness.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ConfigurationReaderTest
    {
        private ConfigurationReader _reader;
        private DirectoryInfo _htmlDirInfo;
        private DirectoryInfo _xmlDirInfo;
        private DirectoryInfo _xmlProcessedDirInfo;

        public ConfigurationReaderTest()
        {
            _reader = new ConfigurationReader();
            _htmlDirInfo = _reader.GetHtmlFilesDirectory();
            _xmlDirInfo = _reader.GetXmlFilesDirectory();
            _xmlProcessedDirInfo = _reader.GetXmlFilesProcessedDirectory();
        }
        [TestMethod]
        public void Html_files_directory_info_retrieved()
        {
            string path = @"C:\Users\Owner\Desktop\Airickets-WebDeveloperTest\ProgrammerTest\Data\Output";
            Assert.AreEqual(path, _htmlDirInfo.FullName);
        }

        [TestMethod]
        public void Xml_files_directory_info_retrieved()
        {
            string path = @"C:\Users\Owner\Desktop\Airickets-WebDeveloperTest\ProgrammerTest\Data\Computers";
            Assert.AreEqual(path, _xmlDirInfo.FullName);
        }

        [TestMethod]
        public void Processed_xml_files_directory_info_retrieved()
        {
            string path = @"C:\Users\Owner\Desktop\Airickets-WebDeveloperTest\ProgrammerTest\Data\Processed";
            Assert.AreEqual(path, _xmlProcessedDirInfo.FullName);
        }
    }
}
