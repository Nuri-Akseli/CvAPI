using CvAPI.Application.Features.Commands.SocialMedia.Create;
using CvAPI.Application.Features.Commands.SocialMedia.Delete;
using CvAPI.Application.Features.Commands.SocialMedia.Update;
using CvAPI.Application.Features.Commands.SocialMedia.UpdateActivity;
using CvAPI.Application.Features.Queries.SocialMedia.GetAll;
using CvAPI.Application.Features.Queries.SocialMedia.GetListByLanguageCode;
using CvAPI.Application.Features.Queries.SocialMedia.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        readonly IMediator _mediator;
        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocialMediaCreateCommandRequest socialMediaCreateCommandRequest)
        {
            SocialMediaCreateCommandResponse response = await _mediator.Send(socialMediaCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SocialMediaDeleteCommandRequest socialMediaDeleteCommandRequest)
        {
            SocialMediaDeleteCommandResponse response = await _mediator.Send(socialMediaDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SocialMediaUpdateCommandRequest socialMediaUpdateCommandRequest)
        {
            SocialMediaUpdateCommandResponse response = await _mediator.Send(socialMediaUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(SocialMediaUpdateActivityCommandRequest socialMediaUpdateActivityCommandRequest)
        {
            SocialMediaUpdateActivityCommandResponse response = await _mediator.Send(socialMediaUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SocialMediaGetAllQueryRequest socialMediaGetAllQueryRequest)
        {
            SocialMediaGetAllQueryResponse response = await _mediator.Send(socialMediaGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] SocialMediaGetSingleQueryRequest socialMediaGetSingleQueryRequest)
        {
            SocialMediaGetSingleQueryResponse response = await _mediator.Send(socialMediaGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetListByLanguageCode(SocialMediaGetListByLanguageCodeQueryRequest socialMediaGetListByLanguageCodeQueryRequest)
        {
            SocialMediaGetListByLanguageCodeQueryResponse response = await _mediator.Send(socialMediaGetListByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
