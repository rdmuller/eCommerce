using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Queries.GetById;
public class GetByIdDepartmentQuery : IRequest<BaseResponse<DepartmentFullQueryDTO>>
{
    public long? DepartmentId { get; set; }
}
