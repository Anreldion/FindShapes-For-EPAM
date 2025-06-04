using System.IO;

namespace Find.Services.Interfaces
{
    public interface IFolderService
    {
        DirectoryInfo CreateFolder(string path);
        bool IsExist(string path);
        string CreateFolderInBaseDirectory(string name);
    }
}
