using eCommerce.Application.Common.Bases;
using eCommerce.Application.Common.Exceptions;
using eCommerce.Domain.Repositories;
using eCommerce.Domain.Repositories.Departments;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Commands.Delete;
public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, BaseResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentWriteOnlyRepository _repository;

    public DeleteDepartmentHandler(IUnitOfWork unitOfWork, IDepartmentWriteOnlyRepository repository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _repository.GetByIdAsync(request.id);

        if (department is null)
            throw new ErrorNotFoundException("Department not found");

        _repository.Delete(department);

        await _unitOfWork.CommitAsync();

        return new BaseResponse<string>() { ObjectId = request.id.ToString() };
    }
}
