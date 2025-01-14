using BookKaroAPI.Response.Common;

namespace BookKaroAPI.Response
{
    public class SuccessAPIResponse<T> : ApiResponse
    {
        public T Data { get; set; } = default(T);

        public SuccessAPIResponse(T data, bool isSuccess, string message, int statusCode)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
