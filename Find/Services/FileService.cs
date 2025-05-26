using System.IO;
using Find.Services.Interfaces;

namespace Find.Services
{
    public class FileService : IFileService
    {
        public string ReadFile(string path)
        {
            using var sr = new StreamReader(path);
            var content = sr.ReadToEnd();
            return content;
        }

        public void WriteFile(string path, string content)
        {
            using var sw = new StreamWriter(path);
            sw.Write(content);
            sw.Close();
        }
    }
}
