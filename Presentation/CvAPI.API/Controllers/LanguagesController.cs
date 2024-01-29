using CvAPI.Application.Features.Commands.Language.Create;
using CvAPI.Application.Features.Commands.Language.Delete;
using CvAPI.Application.Features.Commands.Language.Update;
using CvAPI.Application.Features.Commands.Language.UpdateActivity;
using CvAPI.Application.Features.Queries.Language.GetAll;
using CvAPI.Application.Features.Queries.Language.GetSingleByCode;
using CvAPI.Application.Features.Queries.Language.GetSingleById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class LanguagesController : ControllerBase
    {
        readonly IMediator _mediator;
        public LanguagesController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(LanguageCreateCommandRequest languageCreateCommandRequest)
        {
            LanguageCreateCommandResponse response= await _mediator.Send(languageCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Update(LanguageUpdateCommandRequest languageUpdateCommandRequest)
        {
            LanguageUpdateCommandResponse response = await _mediator.Send(languageUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LanguageDeleteCommandRequest languageDeleteCommandRequest)
        {
            LanguageDeleteCommandResponse response = await _mediator.Send(languageDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]LanguageGetAllQueryRequest languageGetAllQueryRequest)
        {
            LanguageGetAllQueryResponse response = await _mediator.Send(languageGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingleById([FromQuery]LanguageGetSingleByIdQueryRequest languageGetSingleByIdQueryRequest)
        {
            LanguageGetSingleByIdQueryResponse response = await _mediator.Send(languageGetSingleByIdQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingleByCode([FromQuery]LanguageGetSingleByCodeQueryRequest languageGetSingleByCodeQueryRequest)
        {
            LanguageGetSingleByCodeQueryResponse response = await _mediator.Send(languageGetSingleByCodeQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActivity(LanguageUpdateActivityCommandRequest updateActivityCommandRequest)
        {
            LanguageUpdateActivityCommandResponse response = await _mediator.Send(updateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
