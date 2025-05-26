using System;
using System.IO;
using Find.Services.Interfaces;

namespace Find.Services
{
    internal class FolderService : IFolderService
    {
        public DirectoryInfo CreateFolder(string path)
        {
            try
            {
                return Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsExist(string path)
        {
            return Directory.Exists(path);
        }

        public string CreateFolderInBaseDirectory(string name)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = System.IO.Path.Combine(basePath, "Shapes");
            if (string.IsNullOrEmpty(path) || IsExist(path))
            {
                CreateFolder(path);
            }

            return path;
        }
    }
}
