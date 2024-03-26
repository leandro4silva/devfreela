using DevFreela.Application.Commands.Project.Finish;
using DevFreela.Application.Commands.Project.Update;
using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Application.Commands.Projects.Delete;
using DevFreela.Application.Queries.Project.GetAll;
using DevFreela.Application.Queries.Project.GetById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMediator _mediator;

    public ProjectsController(IProjectService projectService, IMediator mediator)
    {
        _projectService = projectService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllQuery query)
    {
        var projects = await _mediator.Send(query);
        return Ok(projects);
    }

    // api/projects/2
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(GetByIdQuery query)
    {
        var project = await _mediator.Send(query);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCommand command)
    {
        if (command.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCommand command)
    {
        if (command.Description.Length > 200)
        {
            return BadRequest();
        }

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeleteCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public async Task<IActionResult> Finish(FinishCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(FinishCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
