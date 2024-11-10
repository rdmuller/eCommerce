using AutoMapper;
using eCommerce.Application.Commen.Bases;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Domain.Repositories.Users;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Queries.GetById;
public sealed class GetByIdDepartmentHandler : IRequestHandler<GetByIdDepartmentQuery, BaseResponse<DepartmentQueryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentReadOnlyRepository _departmentRepository;

    public GetByIdDepartmentHandler(IMapper mapper, IDepartmentReadOnlyRepository departmentRepository)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _departmentRepository = departmentRepository ?? throw new ArgumentException(nameof(departmentRepository));
    }

    public async Task<BaseResponse<DepartmentQueryDTO>> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DepartmentQueryDTO>();
        var department = await _departmentRepository.GetByIdAsync((long)request.DepartmentId!);

        if (department is not null)
        {
            response.Data = _mapper.Map<DepartmentQueryDTO>(department);
            response.Message = "Success";
        }
        else
            response.Message = "Not found";
        
        return response;
    }
}
