namespace BugTracking.Api.Common.Exceptions
{
    public class BadRequestException : BaseExceptionHandler
    {
        public BadRequestException(string message) : base(message, StatusCodes.Status400BadRequest)
        {
        }
    }
}
