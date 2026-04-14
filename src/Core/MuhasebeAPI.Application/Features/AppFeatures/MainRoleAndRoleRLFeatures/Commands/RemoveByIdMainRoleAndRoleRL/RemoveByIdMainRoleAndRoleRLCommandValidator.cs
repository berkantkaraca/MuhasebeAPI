using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;

public sealed class RemoveByIdMainRoleAndRoleRLCommandValidator : AbstractValidator<RemoveByIdMainRoleAndRoleRLCommandRequest>
{
    public RemoveByIdMainRoleAndRoleRLCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull().WithMessage("Id alanı zorunludur!");
    }
}
