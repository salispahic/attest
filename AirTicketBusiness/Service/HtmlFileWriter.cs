using AirTicketBusiness.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace AirTicketBusiness.Service
{
    public class HtmlFileWriter
    {
        DirectoryInfo _htmlDirectoryInfo;
        DirectoryInfo _resourcesDirectoryInfo;
        string _xsltString = null;
        private const string _xsltFileName = "Computer.xslt";
        private const string _cssFileName = "Style.css";
        private IFileSystemHelper _fileSystemHelper;
        private string LoadXsltString()
        {
            string path = System.IO.Path.Combine(_resourcesDirectoryInfo.FullName, _xsltFileName);
            string retVal = File.ReadAllText(path);
            return retVal;
        }

        private void CopyCssToOutputDirectory()
        {
            string pathRes = Path.Combine(_resourcesDirectoryInfo.FullName, _cssFileName);
            string pathHtml = Path.Combine(_htmlDirectoryInfo.FullName, _cssFileName);
            if (File.Exists(pathHtml))
            {
                File.Delete(pathHtml);
            }
            File.Copy(pathRes, pathHtml);
        }
        public HtmlFileWriter(DirectoryInfo htmlDirectoryInfo, DirectoryInfo resourcesDirectoryInfo, IFileSystemHelper fileSystemHelper)
        {
            _fileSystemHelper = fileSystemHelper;
            _htmlDirectoryInfo = htmlDirectoryInfo;
            _resourcesDirectoryInfo = resourcesDirectoryInfo;
            if (!_htmlDirectoryInfo.Exists)
            {
                _fileSystemHelper.CreateDirectory(_htmlDirectoryInfo.FullName);
            }
            _xsltString = LoadXsltString();
            CopyCssToOutputDirectory();
        }

        public void WriteHtmlFile(IStackItem item)
        {
            //transform to html
            XslCompiledTransform transformer = new XslCompiledTransform();
            using (StringReader stringReader = new StringReader(_xsltString))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                using(XmlReader xmlReader = XmlReader.Create(stringReader, settings))
                {
                    transformer.Load(xmlReader);
                }
                settings = null;
            }

            string htmlString;
            using(StringReader stringReader = new StringReader(item.FileContent))
            {
                using(XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    using(StringWriter writer = new StringWriter())
                    {
                        transformer.Transform(xmlReader, null, writer);
                        htmlString = writer.ToString();
                    }
                }
            }

            //write to file
            string pathToHtmlFile = Path.Combine(_htmlDirectoryInfo.FullName, item.FileNameNoExtension + ".html");
            File.AppendAllText(pathToHtmlFile, htmlString);
        }
    }
}
