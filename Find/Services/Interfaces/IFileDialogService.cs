namespace Find.Services.Interfaces
{
    public interface IFileDialogService
    {
        string OpenFileDialog(string filter, string initialDirectory, string title);
        string SaveAsFileDialog(string fileName, string initialDirectory, string filter, string title);
    }
}
