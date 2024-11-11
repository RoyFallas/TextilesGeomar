namespace TextilesGeomar.Common.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public BaseResponse(T data, string message, int statusCode = 200)
        {
            Success = statusCode >= 200 && statusCode < 300;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        // Static factory methods for success and failure responses
        public static BaseResponse<T> SuccessResponse(T data, string message = "Request was successful.")
        {
            return new BaseResponse<T>(data, message, 200);
        }

        public static BaseResponse<T> ErrorResponse(string message, int statusCode = 500)
        {
            return new BaseResponse<T>(default(T), message, statusCode);
        }
    }
}
