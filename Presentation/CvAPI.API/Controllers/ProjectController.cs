using CvAPI.Application.Features.Commands.Project.Create;
using CvAPI.Application.Features.Commands.Project.Delete;
using CvAPI.Application.Features.Commands.Project.Update;
using CvAPI.Application.Features.Commands.Project.UpdateActivity;
using CvAPI.Application.Features.Queries.Project.GetAll;
using CvAPI.Application.Features.Queries.Project.GetListByLanguageCode;
using CvAPI.Application.Features.Queries.Project.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateCommandRequest projectCreateCommandRequest)
        {
            ProjectCreateCommandResponse response= await _mediator.Send(projectCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateCommandRequest projectUpdateCommandRequest)
        {
            ProjectUpdateCommandResponse response = await _mediator.Send(projectUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(ProjectUpdateActivityCommandRequest projectUpdateActivityCommandRequest)
        {
            ProjectUpdateActivityCommandResponse response = await _mediator.Send(projectUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectDeleteCommandRequest projectDeleteCommandRequest)
        {
            ProjectDeleteCommandResponse response = await _mediator.Send(projectDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ProjectGetAllQueryRequest projectGetAllQueryRequest)
        {
            ProjectGetAllQueryResponse response = await _mediator.Send(projectGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] ProjectGetSingleQueryRequest projectGetSingleQueryRequest)
        {
            ProjectGetSingleQueryResponse response = await _mediator.Send(projectGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetListByLanguageCode([FromQuery] ProjectGetListByLanguageCodeQueryRequest projectGetListByLanguageCodeQueryRequest)
        {
            ProjectGetListByLanguageCodeQueryResponse response = await _mediator.Send(projectGetListByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
