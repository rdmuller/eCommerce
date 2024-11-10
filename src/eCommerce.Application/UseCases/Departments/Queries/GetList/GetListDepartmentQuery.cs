using eCommerce.Application.Commen.Bases;
using eCommerce.Application.DTOs.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Queries.GetList;
public class GetListDepartmentQuery : IRequest<BaseResponse<IEnumerable<DepartmentQueryDTO>>>
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}
