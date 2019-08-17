namespace AirTicketBusiness.Domain
{
    public interface IStackItem
    {
        string FileContent { get; set; }
        string FullFileName { get; set; }

        string FileName { get; }

        string FileNameNoExtension { get; }
    }
}