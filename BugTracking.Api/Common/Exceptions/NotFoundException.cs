namespace BugTracking.Api.Common.Exceptions
{
    public class NotFoundException : BaseExceptionHandler
    {
        public NotFoundException(string message) : base(message, StatusCodes.Status404NotFound)
        {
        }
    }
}
