namespace HRSystemWEB.Helpers
{
    public class RequestModel
    {
        public HttpMethod Method { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }

        public RequestModel(HttpMethod method, string url, object data = null)
        {
            Method = method;
            Url = url;
            Data = data;
        }
    }

}
