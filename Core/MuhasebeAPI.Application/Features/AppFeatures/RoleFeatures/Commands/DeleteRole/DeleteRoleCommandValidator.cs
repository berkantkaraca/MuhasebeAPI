using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommandRequest>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().NotNull().WithMessage("Id bilgisi boş olamaz!!");
    }
}
