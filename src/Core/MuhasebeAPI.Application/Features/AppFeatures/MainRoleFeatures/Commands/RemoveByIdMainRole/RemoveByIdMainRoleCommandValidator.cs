
using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveByIdMainRole;

public sealed class RemoveByIdMainRoleCommandValidator : AbstractValidator<RemoveByIdMainRoleCommandRequest>
{
    public RemoveByIdMainRoleCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull().WithMessage("Id alanı boş olamaz!");
    }
}
