using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommandRequest>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Code)
            .NotEmpty().NotNull().WithMessage("Role kodu boş olamaz!");

        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Role adı boş olamaz!");
    }
}
