using Find.Services.enums;

namespace Find.Services.Interfaces
{
    public interface IDialogService
    {
        UnsavedChangesResult AskSaveConfirmation();
    }
}
