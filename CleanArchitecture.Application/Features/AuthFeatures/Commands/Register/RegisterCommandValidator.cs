using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş olamaz");
        RuleFor(p => p.Email).NotNull().WithMessage("Mail adresi boş olamaz");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bi mail adresi giriniz");

        RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p => p.UserName).MinimumLength(2).WithMessage("Kullanıcı adı en az 2 karakter olmalıdır");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz")
            .NotNull().WithMessage("Şifre boş olamaz")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalı.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$")
            .WithMessage("Şifre en az bir küçük harf, bir büyük harf, bir rakam ve bir özel karakter içermelidir.");

    }
}
