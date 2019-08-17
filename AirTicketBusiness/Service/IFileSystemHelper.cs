namespace AirTicketBusiness.Service
{
    public interface IFileSystemHelper
    {
        void CreateDirectory(string path);
        void MoveFile(string pathOrigin, string pathDestination);
        void WriteToFile(string fileName, string content);

        string ReadTextFile(string path);

        string[] DirectoryGetFiles(string path);
    }
}