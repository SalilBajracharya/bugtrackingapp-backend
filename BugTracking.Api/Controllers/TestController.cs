using BugTracking.Api.Segretation.Commands.Bugs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BugTracking.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class TestController : BaseApiController
    {
        [Authorize]
        [HttpPost("test-endpoint")]
        public async Task<IActionResult> CreateBug()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(new { UserId = userId });
        }
    }
}
