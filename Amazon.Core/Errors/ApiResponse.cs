
namespace Amazon.core.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? ApplyMessageByStatusCode(statusCode);
        }

        private string? ApplyMessageByStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request - Your request could not be processed.",
                401 => "Unauthorized - Access is denied due to invalid credentials.",
                404 => "Not Found - The requested resource could not be found.",
                500 => "Internal Server Error - An unexpected error occurred.",
                _ => "An unexpected error has occurred."
            };
        }
    }
}
