using CvAPI.Application.Features.Commands.GeneralArticle.Create;
using CvAPI.Application.Features.Commands.GeneralArticle.Delete;
using CvAPI.Application.Features.Commands.GeneralArticle.Update;
using CvAPI.Application.Features.Commands.GeneralArticle.UpdateActivity;
using CvAPI.Application.Features.Queries.GeneralArticle.GetAll;
using CvAPI.Application.Features.Queries.GeneralArticle.GetSingle;
using CvAPI.Application.Features.Queries.GeneralArticle.GetSingleByLanguageCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneralArticleCreateCommandRequest generalArticleCreateCommandRequest)
        {
            GeneralArticleCreateCommandResponse response = await _mediator.Send(generalArticleCreateCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Update(GeneralArticleUpdateCommandRequest  generalArticleUpdateCommandRequest)
        {
            GeneralArticleUpdateCommandResponse response = await _mediator.Send(generalArticleUpdateCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GeneralArticleDeleteCommandRequest generalArticleDeleteCommandRequest)
        {
            GeneralArticleDeleteCommandResponse response = await _mediator.Send(generalArticleDeleteCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActivity(GeneralArticleUpdateActivityCommandRequest generalArticleUpdateActivityCommandRequest)
        {
            GeneralArticleUpdateActivityCommandResponse response = await _mediator.Send(generalArticleUpdateActivityCommandRequest);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GeneralArticleGetAllQueryRequest generalArticleGetAllQueryRequest)
        {
            GeneralArticleGetAllQueryResponse response = await _mediator.Send(generalArticleGetAllQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingle([FromQuery]GeneralArticleGetSingleQueryRequest generalArticleGetSingleQueryRequest)
        {
            GeneralArticleGetSingleQueryResponse response = await _mediator.Send(generalArticleGetSingleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetByLanguageCode(GeneralArticleGetSingleByLanguageCodeQueryRequest articleGetSingleByLanguageCodeQueryRequest)
        {
            GeneralArticleGetSingleByLanguageCodeQueryResponse response = await _mediator.Send(articleGetSingleByLanguageCodeQueryRequest);
            return Ok(response);
        }
    }
}
