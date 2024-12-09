using AutoMapper;
using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Domain.Repositories.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Queries.GetList;
public class GetListDepartmentHandler : IRequestHandler<GetListDepartmentQuery, BaseResponse<IEnumerable<DepartmentSimpleQueryDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadOnlyRepository _departmentRepository;

    public GetListDepartmentHandler(IMapper mapper, IDepartmentReadOnlyRepository departmentRepository)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _departmentRepository = departmentRepository ?? throw new ArgumentException(nameof(departmentRepository));
    }

    public async Task<BaseResponse<IEnumerable<DepartmentSimpleQueryDTO>>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<DepartmentSimpleQueryDTO>>();
        var departments = await _departmentRepository.GetAllAsync(request.PageNumber, request.PageSize);

        if (departments.Count > 0)
        {
            response.Data = _mapper.Map<IEnumerable<DepartmentSimpleQueryDTO>>(departments);
        } 

        return response;
    }
}
