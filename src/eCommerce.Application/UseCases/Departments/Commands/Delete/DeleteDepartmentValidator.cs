using FluentValidation;

namespace eCommerce.Application.UseCases.Departments.Commands.Delete;
public class DeleteDepartmentValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentValidator()
    {
        RuleFor(x => x.id).NotNull().NotEqual(0).WithMessage("Department id is required");
    }
}
