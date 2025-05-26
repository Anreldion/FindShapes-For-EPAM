using Microsoft.Win32;
using System;
using Find.Services.Interfaces;

namespace Find.Services
{
    public class FileDialogService : IFileDialogService
    {
        public string OpenFile(string filter, string initialDir, string title)
        {
            var dialog = new OpenFileDialog
            {
                Filter = filter,
                InitialDirectory = initialDir,
                Title = title
            };

            return dialog.ShowDialog() == false ? null : dialog.FileName;
        }

        public string SaveFile(string defaultFileName, string filter, string title)
        {
            var dialog = new SaveFileDialog
            {
                FileName = defaultFileName,
                OverwritePrompt = true,
                Filter = filter,
                Title = title
            };

            return dialog.ShowDialog() == false ? null : dialog.FileName;
        }
    }
}
