namespace Ecom.Apl.Helper
{
    public class ResponseApi
    {
        // Constructor
        public ResponseApi(int statusCode, string? message = null)
        {
            // Assign the status code to the property
            StatusCode = statusCode;

            // If the message is null, use the default message based on the status code
            Message = message ?? GetMessageStatusCode(statusCode);
        }

        // Private method to generate status message based on status code
        private string GetMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "OK",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status"
            };
        }

        // Properties
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }

}
