using BugTracking.Api.Services.BugService;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BugTracking.Api.Segretation.Commands.Bugs
{
    public record DeleteBugReportCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteBugReportCommandHandler : IRequestHandler<DeleteBugReportCommand, Result>
    {
        private readonly IBugService _bugService;
        public DeleteBugReportCommandHandler(IBugService bugService)
        {
            _bugService = bugService;
        }
        public Task<Result> Handle(DeleteBugReportCommand request, CancellationToken cancellationToken)
        {
            return _bugService.Delete(request.Id);
        }
    }
}
