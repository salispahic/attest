using AirTicketBusiness.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicketBusiness.Service
{
    public class XmlFileReader : IXmlFileReader
    {
        DirectoryInfo _xmlDirectoryInfo;
        DirectoryInfo _xmlDirectoryProcessedInfo;
        public DirectoryInfo XmlDirectory { get => _xmlDirectoryInfo; set => _xmlDirectoryInfo = value; }
        public DirectoryInfo XmlDirectoryProcessedInfo { get => _xmlDirectoryProcessedInfo; set => _xmlDirectoryProcessedInfo = value; }

        private IFileSystemHelper _fileSystemHelper;
        public XmlFileReader(DirectoryInfo xmlDirectoryInfo, DirectoryInfo xmlDirectoryProcessedInfo, IFileSystemHelper fileSystemHelper)
        {
            _fileSystemHelper = fileSystemHelper;
            _xmlDirectoryInfo = xmlDirectoryInfo;
            _xmlDirectoryProcessedInfo = xmlDirectoryProcessedInfo;
            if (!_xmlDirectoryProcessedInfo.Exists)
            {
                _fileSystemHelper.CreateDirectory(_xmlDirectoryProcessedInfo.FullName);
            }
        }

        private void MoveToProcessed(string fileToMove)
        {

            string fileToMoveTo = Path.Combine(_xmlDirectoryProcessedInfo.FullName, Path.GetFileName(fileToMove));
            _fileSystemHelper.MoveFile(fileToMove, fileToMoveTo);
        }

        public IStackItem GetNextStackItem()
        {
            IStackItem retVal = null;
            //we want to process files that come in after we started the processing as well.
            //we could have used FileSystemWatcher and cueue stuff diferently, but that would have been 
            //an overkill
            string[] files = _fileSystemHelper.DirectoryGetFiles(_xmlDirectoryInfo.FullName);

            if (files.Length > 0)
            {
                retVal = new StackItem(files[0],_fileSystemHelper.ReadTextFile( files[0]));
                MoveToProcessed(files[0]);
            }

            return retVal;
        }
    }
}
