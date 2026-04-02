namespace ERP.API.ResponseModels
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
