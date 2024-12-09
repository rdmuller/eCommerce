using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Commands.Update;
public class UpdateDepartmentCommand : IRequest<BaseResponse<string>>
{
    public DepartmentCommandDTO? Data { get; set; }
}
