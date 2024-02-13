using CvAPI.Application.Features.Commands.WorkExperience.Create;
using CvAPI.Application.Features.Commands.WorkExperience.Delete;
using CvAPI.Application.Features.Commands.WorkExperience.Update;
using CvAPI.Application.Features.Commands.WorkExperience.UpdateActivity;
using CvAPI.Application.Features.Queries.WorkExperience.GetAll;
using CvAPI.Application.Features.Queries.WorkExperience.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WorkExperienceController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkExperienceCreateCommandRequest workExperienceCreateCommandRequest)
        {
            WorkExperienceCreateCommandResponse response = await _mediator.Send(workExperienceCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(WorkExperienceDeleteCommandRequest workExperienceDeleteCommandRequest)
        {
            WorkExperienceDeleteCommandResponse response = await _mediator.Send(workExperienceDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkExperienceUpdateCommandRequest workExperienceUpdateCommandRequest)
        {
            WorkExperienceUpdateCommandResponse response = await _mediator.Send(workExperienceUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(WorkExperienceUpdateActivityCommandRequest workExperienceUpdateActivityCommandRequest)
        {
            WorkExperienceUpdateActivityCommandResponse response = await _mediator.Send(workExperienceUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]WorkExperienceGetAllQueryRequest workExperienceGetAllQueryRequest)
        {
            WorkExperienceGetAllQueryResponse response = await _mediator.Send(workExperienceGetAllQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] WorkExperienceGetSingleQueryRequest workExperienceGetSingleQueryRequest)
        {
            WorkExperienceGetSingleQueryResponse response = await _mediator.Send(workExperienceGetSingleQueryRequest);
            return Ok(response);
        }
    }
}
