using Find.Services.enums;

namespace Find.Services.Interfaces
{
    public interface IDialogService
    {
        UnsavedChangesResult AskSaveConfirmation();
        void ShowError(string message, string title);
    }
}
