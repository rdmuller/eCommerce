using eCommerce.Application.Common.Security;
using FluentValidation;

namespace eCommerce.Application.UseCases.Users.Register;
public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Data).NotNull().WithMessage("Dados não informados");

        When(x => x.Data != null, () =>
        {
            //RuleFor(x => x.Data!.UserName)
            //    .NotEmpty().WithMessage("Nome Não informado");

            //RuleFor(x => x.Data!.UserName).MinimumLength(3)
            //    .When(x => !string.IsNullOrWhiteSpace(x.Data!.UserName))
            //    .WithMessage("Nome deve conter no mínimo 3 caracteres");

            RuleFor(x => x.Data!.Email)
                .NotEmpty().WithMessage("E-mail deve ser informado")
                .EmailAddress().WithMessage("Informe um e-mail válido");

            RuleFor(x => x.Data!.Password).SetValidator(new PasswordValidator<RegisterUserCommand>());
        });
    }
}
