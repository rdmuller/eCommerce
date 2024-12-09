using FluentValidation;

namespace eCommerce.Application.UseCases.Departments.Commands.Create;
public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentValidator()
    {
        RuleFor(x => x.Data).NotNull().WithMessage("Dados não informados");

        When(x => x.Data != null, () =>
        {
            RuleFor(x => x.Data!.Name).NotEmpty().WithMessage("Nome Não informado");

            RuleFor(x => x.Data!.Name).MinimumLength(2)
                .When(x => !string.IsNullOrWhiteSpace(x.Data!.Name))
                .WithMessage("Nome deve possuir no mínimo 2 caracteres");
        });
    }
}
