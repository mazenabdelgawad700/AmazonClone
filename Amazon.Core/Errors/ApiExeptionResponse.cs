namespace Amazon.Core.Errors
{
    public class ApiExeptionResponse : Exception
    {
        public int StatusCode { get; }

        public ApiExeptionResponse(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
