using FluentResults;
using MediatR;

namespace BugTracking.Api.Common.Exceptions
{
    public class GenericException : BaseExceptionHandler
    {
        public List<Error> Errors { get; }
        public GenericException(string message, IEnumerable<Error> errors = null) 
                : base(message, StatusCodes.Status400BadRequest)
        {
            Errors = errors?.ToList() ?? new List<Error>();
        }
    }
}
