namespace SaparAuthorization.Api.ViewModel
{
    public class ApiResponseModel<T> 
    {
        public bool Success { get; set; } = true;
        public T ResponseData { get; set; }
        public ErrorModel<T> ErrorData { get; set; }

        public ApiResponseModel()
        {
        }
        public ApiResponseModel (bool success, T responseData, ErrorModel<T> errorModel)
        {
            this.Success = success;
            this.ResponseData = responseData;
            this.ErrorData = errorModel;
        }

        public static ApiResponseModel<T> Successfull(T responseData)
        {
            return new ApiResponseModel<T>(true, responseData, null);
        }

        public static ApiResponseModel<T> Failed(ErrorModel<T> ErrorData)
        {
            return new ApiResponseModel<T>(true, default, ErrorData);
        }

    }
}
