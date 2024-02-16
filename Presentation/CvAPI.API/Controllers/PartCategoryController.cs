using CvAPI.Application.Features.Queries.PartCategory.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PartCategoryController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PartCategoryGetAllQueryRequest partCategoryGetAllQueryRequest)
        {
            PartCategoryGetAllQueryResponse response = await _mediator.Send(partCategoryGetAllQueryRequest);
            return Ok(response);
        }
    }
}
