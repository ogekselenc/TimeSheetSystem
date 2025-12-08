using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSheetSystem.Api.Requests.Employees;
using TimeSheetSystem.Domain.Employees.CreateEmployee;
using TimeSheetSystem.Domain.Employees.GetEmployeeById;
using TimeSheetSystem.Domain.Employees.GetEmployees;
using TimeSheetSystem.Domain.Employees.EditEmployee;
using TimeSheetSystem.Domain.Common.Exceptions;

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

        
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        //return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(employee);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _mediator.Send(new GetEmployeesQuery());
        return Ok(employees);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] EmployeeEditRequest request)
    {
        try
        {
            var command = new EmployeeEditCommand(
                id,
                request.FirstName,
                request.LastName,
                request.Email,
                request.IsActive);

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("already taken"))
        {
            return Conflict(new { error = ex.Message });
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Cannot edit a deleted employee"))
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

