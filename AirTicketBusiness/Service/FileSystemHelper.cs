using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicketBusiness.Service
{
    public class FileSystemHelper : IFileSystemHelper
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public string[] DirectoryGetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        public void MoveFile(string pathOrigin, string pathDestination)
        {
            File.Move(pathOrigin, pathDestination);
        }

        public string ReadTextFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteToFile(string fileName, string content)
        {
            File.AppendAllText(fileName, content);
        }
    }
}
