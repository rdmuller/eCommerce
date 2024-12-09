using AutoMapper;
using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Domain.Repositories.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Queries.GetById;
public sealed class GetByIdDepartmentHandler : IRequestHandler<GetByIdDepartmentQuery, BaseResponse<DepartmentFullQueryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadOnlyRepository _departmentRepository;

    public GetByIdDepartmentHandler(IMapper mapper, IDepartmentReadOnlyRepository departmentRepository)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _departmentRepository = departmentRepository ?? throw new ArgumentException(nameof(departmentRepository));
    }

    public async Task<BaseResponse<DepartmentFullQueryDTO>> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DepartmentFullQueryDTO>();
        var department = await _departmentRepository.GetByIdAsync((long)request.DepartmentId!);

        if (department is not null)
            response.Data = _mapper.Map<DepartmentFullQueryDTO>(department);
        
        return response;
    }
}
