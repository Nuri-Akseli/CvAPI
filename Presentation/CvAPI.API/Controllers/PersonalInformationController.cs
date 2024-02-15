using CvAPI.Application.Features.Commands.PersonalInformation.Create;
using CvAPI.Application.Features.Commands.PersonalInformation.Delete;
using CvAPI.Application.Features.Commands.PersonalInformation.Update;
using CvAPI.Application.Features.Commands.PersonalInformation.UpdateActivity;
using CvAPI.Application.Features.Queries.PersonalInformation.GetAll;
using CvAPI.Application.Features.Queries.PersonalInformation.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonalInformationController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonalInformationCreateCommandRequest personalInformationCreateCommandRequest)
        {
            PersonalInformationCreateCommandResponse response = await _mediator.Send(personalInformationCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonalInformationUpdateCommandRequest personalInformationUpdateCommandRequest)
        {
            PersonalInformationUpdateCommandResponse response = await _mediator.Send(personalInformationUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActivity(PersonalInformationUpdateActivityCommandRequest personalInformationUpdateActivityCommandRequest)
        {
            PersonalInformationUpdateActivityCommandResponse response = await _mediator.Send(personalInformationUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PersonalInformationDeleteCommandRequest personalInformationDeleteCommandRequest)
        {
            PersonalInformationDeleteCommandResponse response = await _mediator.Send(personalInformationDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PersonalInformationGetAllQueryRequest personalInformationGetAllQueryRequest)
        {
            PersonalInformationGetAllQueryResponse response = await _mediator.Send(personalInformationGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] PersonalInformationGetSingleQueryRequest personalInformationGetSingleQueryRequest)
        {
            PersonalInformationGetSingleQueryResponse response = await _mediator.Send(personalInformationGetSingleQueryRequest);
            return Ok(response);
        }
    }
}
