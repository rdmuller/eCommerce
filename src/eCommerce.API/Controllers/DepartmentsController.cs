using eCommerce.Application.DTOs.Departments;
using eCommerce.Application.UseCases.Departments.Commands.Create;
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
    public async Task<IActionResult> GetAllAsync([FromQuery]int? pageNumber, [FromQuery]int? pageSize)
    {
        var response = await _mediator.Send(new GetListDepartmentQuery() { PageNumber = pageNumber, PageSize = pageSize });
        if (response.Data is null)
            return NoContent();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]DepartmentCommandDTO request)
    {
        var response = await _mediator.Send(new CreateDepartmentCommand() { Data = request });

        return Ok(response);
    }
}
