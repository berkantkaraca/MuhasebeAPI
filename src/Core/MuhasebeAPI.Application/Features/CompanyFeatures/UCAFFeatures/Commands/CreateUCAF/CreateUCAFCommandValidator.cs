using FluentValidation;

namespace MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public class CreateUCAFCommandValidator : AbstractValidator<CreateUCAFCommandRequest>
{
    public CreateUCAFCommandValidator()
    {
        RuleFor(p => p.Code)
            .NotEmpty().NotNull().WithMessage("Hesap planı kodu boş olamaz!");

        //RuleFor(p => p.Code).MinimumLength(4).WithMessage("Hesap planı kodu en az 4 karakter olmalıdır!");
        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Hesap planı adı boş olamaz!");

        RuleFor(p => p.CompanyId)
            .NotEmpty().NotNull().WithMessage("Şirket bilgisi adı boş olamaz!");

        RuleFor(p => p.Type)
            .NotNull().NotEmpty().WithMessage("Hesap planı tipi boş olamaz!")
            .MaximumLength(1).WithMessage("Hesap planı tipi 1 karakter olmalıdır!");
    }
}
