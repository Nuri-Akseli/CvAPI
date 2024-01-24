using CvAPI.Application.Features.Queries.User.GetAllUser;
using CvAPI.Application.Features.Queries.User.GetUserById;
using CvAPI.Application.Repositories.UserRepositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CvAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly IMediator _mediator;
        public UserController(IUserReadRepository userReadRepository, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllUserQueryRequest getAllUserQueryRequest)
        {
            GetAllUserQueryResponse getAllUserQueryResponse= await _mediator.Send(getAllUserQueryRequest);
            return Ok(getAllUserQueryResponse);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserByIdRequest getUserByIdRequest) {
            GetUserByIdResponse response = await _mediator.Send(getUserByIdRequest);
            return Ok(response);
        }
    }
}
