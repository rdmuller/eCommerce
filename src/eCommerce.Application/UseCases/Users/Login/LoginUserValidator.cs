using FluentValidation;

namespace eCommerce.Application.UseCases.Users.Login;
public class LoginUserValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().NotEmpty().WithMessage("E-mail não informado");

        When(x => !string.IsNullOrWhiteSpace(x.Email), 
            () => RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail com formato inválido"));

        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Senha não informada");
    }
}
