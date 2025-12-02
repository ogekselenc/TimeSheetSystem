using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSheetSystem.Api.Requests.Employees;
using TimeSheetSystem.Domain.Employees.CreateEmployee;

namespace TimeSheetSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
    {
        var result = await _mediator.Send(new CreateEmployeeCommand(
            request.FirstName, request.LastName, request.Email));

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(); // TODO: implement later
    }
}
