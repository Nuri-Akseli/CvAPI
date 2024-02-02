using CvAPI.Application.Features.Commands.CvPart.Create;
using CvAPI.Application.Features.Commands.CvPart.Delete;
using CvAPI.Application.Features.Commands.CvPart.Update;
using CvAPI.Application.Features.Commands.CvPart.UpdateActivity;
using CvAPI.Application.Features.Queries.CvPart.GetAll;
using CvAPI.Application.Features.Queries.CvPart.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CvPartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CvPartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CvPartCreateCommandRequest cvPartCreateCommandRequest)
        {
            CvPartCreateCommandResponse response= await _mediator.Send(cvPartCreateCommandRequest);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CvPartUpdateCommandRequest cvPartUpdateCommandRequest)
        {
            CvPartUpdateCommandResponse response = await _mediator.Send(cvPartUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CvPartDeleteCommandRequest cvPartDeleteCommandRequest)
        {
            CvPartDeleteCommandResponse response = await _mediator.Send(cvPartDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(CvPartUpdateActivityCommandRequest cvPartUpdateActivityCommandRequest)
        {
            CvPartUpdateActivityCommandResponse response =await _mediator.Send(cvPartUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]CvPartGetAllQueryRequest cvPartGetAllQueryRequest)
        {
            CvPartGetAllQueryResponse response = await _mediator.Send(cvPartGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery]CvPartGetSingleQueryRequest cvPartGetSingle)
        {
            CvPartGetSingleQueryResponse response = await _mediator.Send(cvPartGetSingle);
            return Ok(response);
        }
    }
}
