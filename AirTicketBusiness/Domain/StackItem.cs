using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicketBusiness.Domain
{
    public class StackItem : IStackItem
    {
        private string _fullFileName;
        private string _fileContent;

        public string FullFileName { get => _fullFileName; set => _fullFileName = value; }

        public string FileContent { get => _fileContent; set => _fileContent = value; }

        public string FileName
        {
            get { return System.IO.Path.GetFileName(_fullFileName); }
        }

        public string FileNameNoExtension
        {
            get { return System.IO.Path.GetFileNameWithoutExtension(_fullFileName); }
        }

        public StackItem(string fullFileName, string fileContent)
        {
            _fullFileName = fullFileName;
            _fileContent = fileContent;
        }
    }
}
