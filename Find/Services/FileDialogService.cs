using Microsoft.Win32;
using Find.Services.Interfaces;
using Find.Services.Models;
using FluentValidation;

namespace Find.Services
{
    public class FileDialogService : IFileDialogService
    {
        private readonly IValidator<FileDialogOptions> _validator;
        public FileDialogService(IValidator<FileDialogOptions> validator)
        {
            _validator = validator;
        }

        public string OpenFileDialog(string filter, string initialDirectory, string title)
        {
            var options = new FileDialogOptions
            {
                Filter = filter,
                InitialDirectory = initialDirectory,
                Title = title
            };

            var result = _validator.Validate(options);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var dialog = new OpenFileDialog
            {
                Filter = filter,
                InitialDirectory = initialDirectory,
                Title = title
            };

            return dialog.ShowDialog() == false ? null : dialog.FileName;
        }

        public string SaveAsFileDialog(string fileName, string initialDirectory, string filter, string title)
        {
            var options = new FileDialogOptions
            {
                Filter = filter,
                InitialDirectory = initialDirectory,
                Title = title,
                FileName = fileName
            };

            var result = _validator.Validate(options);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var dialog = new SaveFileDialog
            {
                FileName = fileName,
                OverwritePrompt = true,
                Filter = filter,
                Title = title
            };

            return dialog.ShowDialog() == false ? null : dialog.FileName;
        }
    }
}
