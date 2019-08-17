using System.IO;

namespace AirTicketBusiness.Service
{
    public interface IConfigurationReader
    {
        DirectoryInfo GetHtmlFilesDirectory();
        DirectoryInfo GetXmlFilesDirectory();

        DirectoryInfo GetXmlFilesProcessedDirectory();

        DirectoryInfo GetResourcesDirectory();
    }
}