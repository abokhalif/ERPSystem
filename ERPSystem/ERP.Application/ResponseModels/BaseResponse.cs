namespace ERP.API.ResponseModels
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public List<string> Errors { get; set; } = new();
    }
}
