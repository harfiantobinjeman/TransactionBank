namespace JenisTransactionServices.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public Response()
        {
            StatusCode = 0;
            IsSuccess = false;
        }
    }
}
