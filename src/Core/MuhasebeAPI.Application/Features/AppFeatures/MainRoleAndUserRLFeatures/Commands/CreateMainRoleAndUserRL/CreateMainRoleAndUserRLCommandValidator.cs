using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;

public sealed class CreateMainRoleAndUserRLCommandValidator : AbstractValidator<CreateMainRoleAndUserRLCommandRequest>
{
    public CreateMainRoleAndUserRLCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty()
            .NotNull().WithMessage("Kullanıcı seçmelisiniz!");

        RuleFor(p => p.CompanyId)
            .NotEmpty()
            .NotNull().WithMessage("Şirket seçmelisiniz!");

        RuleFor(p => p.MainRoleId)
            .NotEmpty()
            .NotNull().WithMessage("Rol seçmelisiniz!");
    }
}
