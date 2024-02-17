using CvAPI.Application.Features.Commands.Hobby.Create;
using CvAPI.Application.Features.Commands.Hobby.Delete;
using CvAPI.Application.Features.Commands.Hobby.Update;
using CvAPI.Application.Features.Commands.Hobby.UpdateActivity;
using CvAPI.Application.Features.Queries.Hobby.GetAll;
using CvAPI.Application.Features.Queries.Hobby.GetListByLanguageCode;
using CvAPI.Application.Features.Queries.Hobby.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HobbyController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(HobbyCreateCommandRequest hobbyCreateCommandRequest)
        {
            HobbyCreateCommandResponse response = await _mediator.Send(hobbyCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(HobbyDeleteCommandRequest hobbyDeleteCommandRequest)
        {
            HobbyDeleteCommandResponse response = await _mediator.Send(hobbyDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HobbyUpdateCommandRequest hobbyUpdateCommandRequest)
        {
            HobbyUpdateCommandResponse response = await _mediator.Send(hobbyUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActivity(HobbyUpdateActivityCommandRequest hobbyUpdateActivityCommandRequest)
        {
            HobbyUpdateActivityCommandResponse response = await _mediator.Send(hobbyUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]HobbyGetAllQueryRequest hobbyGetAllQueryRequest)
        {
            HobbyGetAllQueryResponse response = await _mediator.Send(hobbyGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] HobbyGetSingleQueryRequest hobbyGetSingleQueryRequest)
        {
            HobbyGetSingleQueryResponse response = await _mediator.Send(hobbyGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetListByLanguageCode(HobbyGetListByLanguageCodeQueryRequest hobbyGetListByLanguageCodeQueryRequest)
        {
            HobbyGetListByLanguageCodeQueryResponse response = await _mediator.Send(hobbyGetListByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
