using eCommerce.Application.DTOs.Security;
using eCommerce.Application.UseCases.Users.Login;
using eCommerce.Domain.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var response = await _mediator.Send(new LoginUserCommand() { Email = loginDTO.Email, Password = loginDTO.Password });

        return Ok(response);
    }
}
