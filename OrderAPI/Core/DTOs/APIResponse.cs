using System.Net;

namespace OrderAPI.Core.DTOs
{
    public class APIResponse<T>
    {
        public T? Data {  get; set; } 
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int StatusCode { get; set; }

        public static APIResponse<T> Fail(string errorMessage, int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            return new APIResponse<T> { Status = false, Message = errorMessage, StatusCode = statusCode };
        }

        public static APIResponse<T> Success(string successMessage, T? data, int statusCode = (int)HttpStatusCode.OK)
        {
            return new APIResponse<T> { Status = true, Message = successMessage, Data = data, StatusCode = statusCode };
        }

    }
}
