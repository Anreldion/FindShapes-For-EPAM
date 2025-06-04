using FluentValidation;

namespace Find.Services.Models.Validators;

public class FileDialogOptionsValidator: AbstractValidator<FileDialogOptions>
{
    public FileDialogOptionsValidator()
    {
        RuleFor(x => x.Filter).NotEmpty().WithMessage("\"Filter must not be empty\"");
        RuleFor(x => x.InitialDirectory)
            .NotEmpty().WithMessage("Initial directory must be specified");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Dialog title is required");

        RuleFor(x => x.FileName)
            .NotEmpty().When(x => x.FileName != null)
            .WithMessage("Filename must not be empty");
    }
}