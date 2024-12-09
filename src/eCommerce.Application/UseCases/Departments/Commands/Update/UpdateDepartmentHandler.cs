using AutoMapper;
using eCommerce.Application.Common.Bases;
using eCommerce.Application.Common.Exceptions;
using eCommerce.Domain.Repositories;
using eCommerce.Domain.Repositories.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Commands.Update;
public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, BaseResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDepartmentHandler(IMapper mapper, IDepartmentWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _repository.GetByIdAsync((long)request.Data!.Id!);

        if (department is null)
            throw new ErrorNotFoundException("Department not found");

        department.Update(name: request.Data.Name);

        _repository.Update(department);
        await _unitOfWork.CommitAsync();

        return new BaseResponse<string>() { Data = "success" };
    }
}
