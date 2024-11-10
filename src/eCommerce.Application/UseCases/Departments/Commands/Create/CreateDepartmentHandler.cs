using eCommerce.Application.Commen.Bases;
using MediatR;

namespace eCommerce.Application.UseCases.Departments.Commands.Create;
public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        response.Message = request.Data.Name ?? string.Empty;
        response.Data = true;
        
        return response;
    }
}
