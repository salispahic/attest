using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace AirTicketBusiness.Service
{
    public class ConfigurationReader : IConfigurationReader
    {
        private const string _xmlPathKey = "directory.xml.path";
        private const string _xmlProcessedPathKey = "directory.xml.processed.path";
        private const string _htmlPathKey = "directory.html.path";
        private const string _resourcesPathKey = "directory.resources.path";
        private string GetValue(string key)
        {
            string retVal = ConfigurationManager.AppSettings[key];
            return retVal;
        }
        private DirectoryInfo GetDirectoryInfo(string key)
        {
            string path = GetValue(key);
            DirectoryInfo retVal = new DirectoryInfo(path);
            return retVal;
        }
        public DirectoryInfo GetXmlFilesDirectory()
        {
            return GetDirectoryInfo(_xmlPathKey);

        }
        public DirectoryInfo GetHtmlFilesDirectory()
        {
            return GetDirectoryInfo(_htmlPathKey);

        }
        public DirectoryInfo GetXmlFilesProcessedDirectory()
        {
            return GetDirectoryInfo(_xmlProcessedPathKey);

        }

        public DirectoryInfo GetResourcesDirectory()
        {
            return GetDirectoryInfo(_resourcesPathKey);

        }
    }
}
