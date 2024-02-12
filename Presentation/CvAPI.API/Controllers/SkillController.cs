using CvAPI.Application.Features.Commands.Skill.Create;
using CvAPI.Application.Features.Commands.Skill.Delete;
using CvAPI.Application.Features.Commands.Skill.Update;
using CvAPI.Application.Features.Commands.Skill.UpdateActivity;
using CvAPI.Application.Features.Queries.Skill.GetAll;
using CvAPI.Application.Features.Queries.Skill.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillCreateCommandRequest skillCreateCommandRequest)
        {
            SkillCreateCommandResponse response = await _mediator.Send(skillCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SkillDeleteCommandRequest skillDeleteCommandRequest)
        {
            SkillDeleteCommandResponse response = await _mediator.Send(skillDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SkillUpdateCommandRequest skillUpdateCommandRequest)
        {
            SkillUpdateCommandResponse response = await _mediator.Send(skillUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(SkillUpdateActivityCommandRequest skillUpdateActivityCommandRequest)
        {
            SkillUpdateActivityCommandResponse response = await _mediator.Send(skillUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SkillGetAllQueryRequest skillGetAllQueryRequest)
        {
            SkillGetAllQueryResponse response = await _mediator.Send(skillGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] SkillGetSingleQueryRequest skillGetSingleQueryRequest)
        {
            SkillGetSingleQueryResponse response = await _mediator.Send(skillGetSingleQueryRequest);
            return Ok(response);
        }
    }
}
