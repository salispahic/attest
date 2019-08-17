using System;
using System.Collections.Generic;
using AirTicketBusiness.Domain;
using AirTicketBusiness.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class HtmlFileWriterTest
    {
        ConfigurationReader _reader;
        XmlFileReader _xfr;
        HtmlFileWriter _hfw;


        public HtmlFileWriterTest()
        {
            _reader = new ConfigurationReader();
            IFileSystemHelper fsh =  (IFileSystemHelper)(new Mock<FileSystemHelper>().Object);
            _xfr = new XmlFileReader(_reader.GetXmlFilesDirectory(), _reader.GetXmlFilesProcessedDirectory(), fsh);
            _hfw = new HtmlFileWriter(_reader.GetHtmlFilesDirectory(), _reader.GetResourcesDirectory(), fsh);

        }
        [Ignore("Part of full slice runner, not unit")]
        [TestMethod]
        public void TestFileWriter()
        {
            IStackItem itm = _xfr.GetNextStackItem();
            _hfw.WriteHtmlFile(itm);
        }
    }
}
