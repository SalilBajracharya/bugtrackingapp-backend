using BugTracking.Api.Segretation.Commands.Bugs;
using BugTracking.Api.Segretation.Queries.Bugs;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController : BaseApiController
    {
        [Authorize(Roles = "User")]
        [Consumes("multipart/form-data")]
        [HttpPost("create-bugreport")]
        public async Task<IActionResult> CreateBug([FromForm] CreateBugReportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.ToActionResult();
        }

        [Authorize(Roles = "User")]
        [HttpPost("delete-bugreport")]
        public async Task<IActionResult> DeleteBug([FromForm] DeleteBugReportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpPost("get-by-userid")]
        public async Task<IActionResult> GetBugByUser([FromQuery] GetBugByUserQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(GetAllBugQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }
    }
}
