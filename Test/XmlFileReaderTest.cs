using System;
using System.Collections.Generic;
using AirTicketBusiness.Domain;
using AirTicketBusiness.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class XmlFileReaderTest
    {
        ConfigurationReader _reader;
        XmlFileReader _xfr;
        int _numberOfFiles;
        IList<IStackItem> _stackItems;

        public XmlFileReaderTest()
        {
            _reader = new ConfigurationReader();
            IFileSystemHelper fsh = (IFileSystemHelper)(new Mock<FileSystemHelper>().Object);
            _xfr = new XmlFileReader(_reader.GetXmlFilesDirectory(), _reader.GetXmlFilesProcessedDirectory(), fsh);
            _numberOfFiles = _reader.GetXmlFilesDirectory().GetFiles().Length;
            _stackItems = new List<IStackItem>();
            while (_xfr.GetNextStackItem() != null)
            {
                IStackItem si = _xfr.GetNextStackItem();
                _stackItems.Add(si);
            }
        }
       
        [Ignore("Part of full slice runner, not unit")]
        [TestMethod]
        public void Number_of_stack_items_is_correct()
        {
            Assert.AreEqual(_numberOfFiles, _stackItems.Count);
        }

        [Ignore("Part of runner fulll slice not unit")]
        [TestMethod]
        public void All_files_copied_to_processed()
        {
            Assert.AreEqual(_numberOfFiles, _reader.GetXmlFilesProcessedDirectory().GetFiles().Length);
        }
    }
}
