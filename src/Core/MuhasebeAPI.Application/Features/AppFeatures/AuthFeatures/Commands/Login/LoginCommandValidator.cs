using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.AuthFeatures.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.EmailOrUserName)
            .NotNull()
            .NotEmpty().WithMessage("Mail ya da kullanıcı adı yazmalısınız!");

        RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty().WithMessage("Şifre boş olamaz");

        RuleFor(p => p.Password)
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır")
            .Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir")
            .Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir")
            .Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir")
            .Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
    }
}
