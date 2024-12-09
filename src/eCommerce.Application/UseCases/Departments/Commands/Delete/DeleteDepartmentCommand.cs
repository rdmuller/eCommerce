using eCommerce.Application.Common.Bases;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Commands.Delete;
public class DeleteDepartmentCommand : IRequest<BaseResponse<string>>
{
    public long id { get; set; }
}
