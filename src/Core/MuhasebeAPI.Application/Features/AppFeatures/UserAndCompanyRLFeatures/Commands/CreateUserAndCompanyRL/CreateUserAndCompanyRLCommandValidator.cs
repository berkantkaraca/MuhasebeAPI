using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;

public sealed class CreateUserAndCompanyRLCommandValidator : AbstractValidator<CreateUserAndCompanyRLCommandRequest>
{
    public CreateUserAndCompanyRLCommandValidator()
    {
        RuleFor(p => p.AppUserId)
            .NotEmpty()
            .NotNull().WithMessage("Kullanıcı seçilmelidir!");

        RuleFor(p => p.CompanyId)
            .NotNull()
            .NotEmpty().WithMessage("Şirket seçilmelidir!");
    }
}
