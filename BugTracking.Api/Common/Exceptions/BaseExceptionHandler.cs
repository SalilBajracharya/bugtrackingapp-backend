namespace BugTracking.Api.Common.Exceptions
{
    public abstract class BaseExceptionHandler : Exception
    {
        public int StatusCode { get; }

        protected BaseExceptionHandler(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
