using Find.Services.Interfaces;
using System.Windows;
using Find.Services.enums;

namespace Find.Services
{
    public class DialogService: IDialogService
    {
        public UnsavedChangesResult AskSaveConfirmation()
        {
            var result = MessageBox.Show("You have unsaved changes. Save it before exiting?", "Exit",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            return result switch
            {
                MessageBoxResult.OK => UnsavedChangesResult.Save,
                MessageBoxResult.No => UnsavedChangesResult.DontSave,
                _ => UnsavedChangesResult.Cancel,
            };
        }
    }
}
