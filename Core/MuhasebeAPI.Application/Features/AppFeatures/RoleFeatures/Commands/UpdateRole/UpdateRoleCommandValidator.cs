using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommandRequest>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().NotNull().WithMessage("Id bilgisi boş olamaz!");

        RuleFor(p => p.Code)
            .NotEmpty().NotNull().WithMessage("Role kodu boş olamaz!");

        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Role adı boş olamaz!");
    }
}
