using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Security;
using eCommerce.Application.DTOs.Users;
using MediatR;

namespace eCommerce.Application.UseCases.Users.Register;
public class RegisterUserCommand : IRequest<TokenDTO>
{
    public RegisterUserCommandDTO? Data { get; set; }
}
