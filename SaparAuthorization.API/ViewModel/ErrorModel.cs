namespace SaparAuthorization.Api.ViewModel
{
    public class ErrorModel<T>
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public T ErrorData { get; set; }
    }
}
