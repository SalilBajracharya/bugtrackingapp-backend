using BugTracking.Api.DTOs.User;
using BugTracking.Api.Segretation.Commands;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<Result> CreateUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
