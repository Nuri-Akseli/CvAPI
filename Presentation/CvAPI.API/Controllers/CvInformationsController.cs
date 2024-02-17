using CvAPI.Application.Features.Commands.CvInformation.Create;
using CvAPI.Application.Features.Commands.CvInformation.Delete;
using CvAPI.Application.Features.Commands.CvInformation.Update;
using CvAPI.Application.Features.Commands.CvInformation.UpdateActivity;
using CvAPI.Application.Features.Queries.CvInformation.GetAll;
using CvAPI.Application.Features.Queries.CvInformation.GetSingle;
using CvAPI.Application.Features.Queries.CvInformation.GetSingleByLanguageCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CvInformationsController : ControllerBase
    {
        readonly IMediator _mediator;
        public CvInformationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CvInformationCreateCommandRequest cvInformationCreateCommandRequest)
        {
            CvInformationCreateCommandResponse response = await _mediator.Send(cvInformationCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CvInformationUpdateCommandRequest cvInformationUpdateCommandRequest)
        {
            CvInformationUpdateCommandResponse response = await _mediator.Send(cvInformationUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(CvInformationUpdateActivityCommandRequest cvInformationUpdateActivityCommandRequest)
        {
            CvInformationUpdateActivityCommandResponse response = await _mediator.Send(cvInformationUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CvInformationDeleteCommandRequest cvInformationDeleteCommandRequest)
        {
            CvInformationDeleteCommandResponse response = await _mediator.Send(cvInformationDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]CvInformationGetAllQueryRequest cvInformationGetAllQueryRequest)
        {
            CvInformationGetAllQueryResponse response = await _mediator.Send(cvInformationGetAllQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery]CvInformationGetSingleQueryRequest cvInformationGetSingleQueryRequest)
        {
            CvInformationGetSingleQueryResponse response = await _mediator.Send(cvInformationGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetByLanguageCode(CvInformationGetSingleByLanguageCodeQueryRequest cvInformationGetSingleByLanguageCodeQueryRequest)
        {
            CvInformationGetSingleByLanguageCodeQueryResponse response = await _mediator.Send(cvInformationGetSingleByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
