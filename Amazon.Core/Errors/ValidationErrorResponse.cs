namespace Amazon.core.Errors
{
    public class ApiValidationResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ApiValidationResponse(IEnumerable<string> errors) : base(400)
        {
            Errors = errors;
        }
    }
}
