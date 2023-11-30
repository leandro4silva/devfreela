using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var project = _projectService.GetById(id);
                return Ok(project);
            }
            catch (Exception error)
            {
                if (error is ResourceNotFound)
                {
                    return NotFound(new { message = "Resource not found." });
                }
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _projectService.Delete(id);

                return NoContent();
            }
            catch (Exception error)
            {
                if (error is ResourceNotFound)
                {
                    return NotFound(new { message = "Resource not found." });
                }
                return StatusCode(500);
            }
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateCommentInputModel inputModel)
        {
            try
            {
                _projectService.CreateComment(inputModel);

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public IActionResult Post(CreateProjectInputModel inputModel)
        {
            try
            {
                if (inputModel.Title.Length > 50)
                {
                    return BadRequest();
                }

                var id = _projectService.Create(inputModel);

                return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel inputModel)
        {
            try
            {
                if (inputModel.Description.Length > 200)
                {
                    return BadRequest();
                }

                _projectService.Update(inputModel);

                return NoContent();
            }
            catch (Exception error)
            {
                if (error is ResourceNotFound)
                {
                    return NotFound(new { message = "Resource not found." });
                }
                return StatusCode(500);
            }
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            try
            {
                _projectService.Start(id);

                return NoContent();
            }
            catch (Exception error)
            {
                if (error is ResourceNotFound)
                {
                    return NotFound(new { message = "Resource not found." });
                }

                return StatusCode(500);
            }
        }


        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            try
            {
                _projectService.Finish(id);

                return NoContent();
            }
            catch (Exception error)
            {
                if (error is ResourceNotFound)
                {
                    return NotFound(new { message = "Resource not found." });
                }

                return StatusCode(500);
            }
        }
    }
}