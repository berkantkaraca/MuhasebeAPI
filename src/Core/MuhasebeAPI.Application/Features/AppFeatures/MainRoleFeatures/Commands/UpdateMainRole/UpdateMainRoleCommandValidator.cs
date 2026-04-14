using FluentValidation;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed class UpdateMainRoleCommandValidator : AbstractValidator<UpdateMainRoleCommandRequest>
{
    public UpdateMainRoleCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id alanı boş olamaz!");

        RuleFor(p => p.Title)
            .NotEmpty()
            .NotNull().WithMessage("Başlık alanı boş olamaz!");
    }
}
