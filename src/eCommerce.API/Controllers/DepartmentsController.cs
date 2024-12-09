using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Application.UseCases.Departments.Commands.Create;
using eCommerce.Application.UseCases.Departments.Commands.Delete;
using eCommerce.Application.UseCases.Departments.Commands.Update;
using eCommerce.Application.UseCases.Departments.Queries.GetById;
using eCommerce.Application.UseCases.Departments.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
    }

    [HttpGet("{departmentId}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long departmentId)
    {
        var response = await _mediator.Send(new GetByIdDepartmentQuery() { DepartmentId = departmentId });
        if (response.Data is null)
            return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<IEnumerable<DepartmentSimpleQueryDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAsync([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    {
        var response = await _mediator.Send(new GetListDepartmentQuery() { PageNumber = pageNumber, PageSize = pageSize });
        if (response.Data is null)
            return NoContent();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] BaseRequest<DepartmentCommandDTO> request)
    {
        var response = await _mediator.Send(new CreateDepartmentCommand() { Data = request.Data });

        return Created(String.Empty, response);
    }

    [HttpPut("{departmentId}")]
    [ProducesResponseType(typeof(BaseResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody]BaseRequest<DepartmentCommandDTO> request, [FromRoute]long departmentId)
    {
        request.Data!.Id = departmentId;

        var response = await _mediator.Send(new UpdateDepartmentCommand() { Data = request.Data });

        return NoContent();
    }

    [HttpDelete("{departmentId}")]
    public async Task<IActionResult> Delete([FromRoute]long departmentId)
    {
        var response = await _mediator.Send(new DeleteDepartmentCommand() { id = departmentId });

        return NoContent();
    }
}
