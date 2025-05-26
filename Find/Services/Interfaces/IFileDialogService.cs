namespace Find.Services.Interfaces
{
    public interface IFileDialogService
    {
        string OpenFile(string filter, string initialDir, string title);
        string SaveFile(string defaultFileName, string filter, string title);
    }
}
