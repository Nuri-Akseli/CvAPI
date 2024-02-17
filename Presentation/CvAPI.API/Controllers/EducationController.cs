using CvAPI.Application.Features.Commands.Education.Create;
using CvAPI.Application.Features.Commands.Education.Delete;
using CvAPI.Application.Features.Commands.Education.Update;
using CvAPI.Application.Features.Commands.Education.UpdateActivity;
using CvAPI.Application.Features.Queries.Education.GetAll;
using CvAPI.Application.Features.Queries.Education.GetListByLanguageCode;
using CvAPI.Application.Features.Queries.Education.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EducationController(IMediator mediator)
        {
            _mediator= mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(EducationCreateCommandRequest educationCreateCommandRequest)
        {
            EducationCreateCommandResponse response=await _mediator.Send(educationCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EducationDeleteCommandRequest educationDeleteCommandRequest)
        {
            EducationDeleteCommandResponse response = await _mediator.Send(educationDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EducationUpdateCommandRequest educationUpdateCommandRequest)
        {
            EducationUpdateCommandResponse response = await _mediator.Send(educationUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(EducationUpdateActivityCommandRequest educationUpdateActivityCommandRequest)
        {
            EducationUpdateActivityCommandResponse response = await _mediator.Send(educationUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]EducationGetAllQueryRequest educationGetAllQueryRequest)
        {
            EducationGetAllQueryResponse response = await _mediator.Send(educationGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] EducationGetSingleQueryRequest educationGetSingleQueryRequest)
        {
            EducationGetSingleQueryResponse response = await _mediator.Send(educationGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetListByLanguageCode(EducationGetListByLanguageCodeQueryRequest educationGetListByLanguageCodeQueryRequest)
        {
            EducationGetListByLanguageCodeQueryResponse response = await _mediator.Send(educationGetListByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
