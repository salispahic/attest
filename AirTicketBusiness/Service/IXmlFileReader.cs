using System.IO;
using AirTicketBusiness.Domain;

namespace AirTicketBusiness.Service
{
    public interface IXmlFileReader
    {
        DirectoryInfo XmlDirectory { get; set; }
        DirectoryInfo XmlDirectoryProcessedInfo { get; set; }

        IStackItem GetNextStackItem();
    }
}