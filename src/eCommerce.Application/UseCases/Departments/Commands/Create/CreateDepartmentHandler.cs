using AutoMapper;
using eCommerce.Application.Common.Bases;
using eCommerce.Domain.Entites;
using eCommerce.Domain.Repositories;
using eCommerce.Domain.Repositories.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Commands.Create;
public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, BaseResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentWriteOnlyRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDepartmentHandler(IDepartmentWriteOnlyRepository departmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public async Task<BaseResponse<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = new Department(0, request.Data!.Name);
        await _departmentRepository.AddAsync(department);

        await _unitOfWork.CommitAsync();

        var response = new BaseResponse<string>();
        response.ObjectId = department.Id.ToString();

        return response;
    }
}
