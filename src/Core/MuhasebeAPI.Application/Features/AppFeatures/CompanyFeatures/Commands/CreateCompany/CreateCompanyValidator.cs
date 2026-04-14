using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyValidator : AbstractValidator<CreateCompanyCommandRequest>
{
    public CreateCompanyValidator()
    {
        RuleFor(p => p.DatabaseName)
            .NotEmpty().NotNull().WithMessage("Database bilgisi yazılmalıdır!");

        RuleFor(p => p.ServerName)
            .NotEmpty().NotNull().WithMessage("Server bilgisi yazılmalıdır!");

        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Şirket adı yazılmalıdır!");
    }
}
