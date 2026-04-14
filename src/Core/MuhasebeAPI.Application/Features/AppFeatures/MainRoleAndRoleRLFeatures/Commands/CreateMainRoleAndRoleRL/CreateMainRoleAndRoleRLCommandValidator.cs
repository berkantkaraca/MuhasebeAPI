using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;

public sealed class CreateMainRoleAndRoleRLCommandValidator : AbstractValidator<CreateMainRoleAndRoleRLCommandRequest>
{
    public CreateMainRoleAndRoleRLCommandValidator()
    {
        RuleFor(p => p.RoleId)
            .NotEmpty()
            .NotNull().WithMessage("Rol seçilmelidir!");

        RuleFor(p => p.MainRoleId)
            .NotNull()
            .NotEmpty().WithMessage("Ana Rol seçilmelidir!");
    }
}
