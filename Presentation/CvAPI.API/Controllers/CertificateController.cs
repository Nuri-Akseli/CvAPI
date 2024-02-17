using CvAPI.Application.Features.Commands.Certificate.Create;
using CvAPI.Application.Features.Commands.Certificate.Delete;
using CvAPI.Application.Features.Commands.Certificate.Update;
using CvAPI.Application.Features.Commands.Certificate.UpdateActivity;
using CvAPI.Application.Features.Queries.Certificate.GetAll;
using CvAPI.Application.Features.Queries.Certificate.GetListByLanguageCode;
using CvAPI.Application.Features.Queries.Certificate.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CertificateController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<IActionResult> Create(CertificateCreateCommandRequest certificateCreateCommandRequest)
        {
            CertificateCreateCommandResponse response=await _mediator.Send(certificateCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CertificateUpdateCommandRequest certificateUpdateCommandRequest)
        {
            CertificateUpdateCommandResponse response = await _mediator.Send(certificateUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(CertificateUpdateActivityCommandRequest certificateUpdateActivityCommandRequest)
        {
            CertificateUpdateActivityCommandResponse response = await _mediator.Send(certificateUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CertificateDeleteCommandRequest certificateDeleteCommandRequest)
        {
            CertificateDeleteCommandResponse response = await _mediator.Send(certificateDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]CertificateGetAllQueryRequest certificateGetAllQueryRequest)
        {
            CertificateGetAllQueryResponse response = await _mediator.Send(certificateGetAllQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery] CertificateGetSingleQueryRequest certificateGetSingleQueryRequest)
        {
            CertificateGetSingleQueryResponse response = await _mediator.Send(certificateGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetListByLanguageCode(CertificateGetListByLanguageCodeQueryRequest certificateGetListByLanguageCodeQueryRequest)
        {
            CertificateGetListByLanguageCodeQueryResponse response = await _mediator.Send(certificateGetListByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
