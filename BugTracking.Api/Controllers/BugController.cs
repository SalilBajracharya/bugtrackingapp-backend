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
        [Authorize]
        [Consumes("multipart/form-data")]
        [HttpPost("create-bugreport")]
        public async Task<IActionResult> CreateBug([FromForm] CreateBugReportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpDelete("delete-bugreport")]
        public async Task<IActionResult> DeleteBug([FromQuery] DeleteBugReportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.ToActionResult();
        }

        [Authorize]
        [Consumes("multipart/form-data")]
        [HttpPost("update-bugreport")]
        public async Task<IActionResult> UpdateBug([FromForm] UpdateBugReportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpGet("get-by-userid")]
        public async Task<IActionResult> GetBugByUser([FromQuery] GetBugByUserQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }

        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBugQuery query)
        {
            var result = await Mediator.Send(query);
            return result.ToActionResult();
        }
    }
}
