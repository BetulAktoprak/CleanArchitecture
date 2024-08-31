using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.userNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı veya mail adresi boş olamaz");
        RuleFor(p => p.userNameOrEmail).NotNull().WithMessage("Kullanıcı adı veya mail adresi boş olamaz");
        RuleFor(p => p.userNameOrEmail).MinimumLength(2).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz")
            .NotNull().WithMessage("Şifre boş olamaz")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalı.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$")
            .WithMessage("Şifre en az bir küçük harf, bir büyük harf, bir rakam ve bir özel karakter içermelidir.");
    }
}
