using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Users;
using eCommerce.Application.UseCases.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseResponseError), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] BaseRequest<RegisterUserCommandDTO> request)
    {
        var response = await _mediator.Send(new RegisterUserCommand() { Data = request.Data });

        return Created("", response);
    }
}
