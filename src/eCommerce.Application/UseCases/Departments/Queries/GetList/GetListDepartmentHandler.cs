using AutoMapper;
using eCommerce.Application.Commen.Bases;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Domain.Repositories.Users;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Queries.GetList;
public class GetListDepartmentHandler : IRequestHandler<GetListDepartmentQuery, BaseResponse<IEnumerable<DepartmentQueryDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadOnlyRepository _departmentRepository;

    public GetListDepartmentHandler(IMapper mapper, IDepartmentReadOnlyRepository departmentRepository)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _departmentRepository = departmentRepository ?? throw new ArgumentException(nameof(departmentRepository));
    }

    public async Task<BaseResponse<IEnumerable<DepartmentQueryDTO>>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<DepartmentQueryDTO>>();
        var departments = await _departmentRepository.GetAllAsync();

        if (departments.Count > 0)
        {
            response.Data = _mapper.Map<IEnumerable<DepartmentQueryDTO>>(departments);
            response.Message = "Success";
        } 
        else
            response.Message = "Not found";

        return response;
    }
}
