using BugTracking.Api.Segretation.Commands.Users;
using BugTracking.Api.Segretation.Queries.Users;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetUsers([FromQuery] GetAllUserQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }
    }
}
