using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleCommandValidator : AbstractValidator<CreateMainRoleCommandRequest>
{
    public CreateMainRoleCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .NotNull().WithMessage("Role başlığı boş olmamaz!");
    }
}