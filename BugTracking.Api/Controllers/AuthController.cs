using BugTracking.Api.Segretation.Queries.Auth;
using BugTracking.Api.Segretation.Queries.Users;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        [HttpGet("login")]
        public async Task<IActionResult> ValidateUser([FromQuery] ValidateUserQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }
    }
}
