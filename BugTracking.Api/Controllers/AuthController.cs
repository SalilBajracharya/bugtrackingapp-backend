using BugTracking.Api.Segretation.Queries.Auth;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        [HttpPost("login")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUserQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }
    }
}
