using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;

public sealed class RemoveByIdUserAndCompanyRLCommandValidator: AbstractValidator<RemoveByIdUserAndCompanyRLCommandRequest>
{
    public RemoveByIdUserAndCompanyRLCommandValidator()
    {
        RuleFor(p=> p.Id)
            .NotEmpty()
            .NotNull().WithMessage("Id alanı boş olamaz!");
    }
}
