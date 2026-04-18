using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;

public sealed class RemoveByIdMainRoleAndUserRLCommandValidator: AbstractValidator<RemoveByIdMainRoleAndUserRLCommandRequest>
{
    public RemoveByIdMainRoleAndUserRLCommandValidator()
    {
        RuleFor(p=> p.Id)
            .NotEmpty()
            .NotNull().WithMessage("Id alanı boş olamaz!");
    }
}
