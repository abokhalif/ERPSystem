using HRSystemWEB.Helpers;
using Newtonsoft.Json;
using System.Text;

namespace HRSystemWEB.ExtensionServices
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseResult> SendRequestAsync(RequestModel requestModel)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var request = new HttpRequestMessage(requestModel.Method, requestModel.Url);

            // Attach data for POST or PUT requests
            if (requestModel.Data != null && (requestModel.Method == HttpMethod.Post || requestModel.Method == HttpMethod.Put))
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(requestModel.Data),
                    Encoding.UTF8,
                    "application/json"
                );
            }

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // For GET, deserialize the response data
                if (requestModel.Method == HttpMethod.Get)
                {

                    var data = await response.Content.ReadAsStringAsync();
                   // var data = JsonConvert.DeserializeObject<object>(responseData);  // You can replace 'object' with a specific type
                    return ResponseResult.SuccessResult(data);
                    
                }

                return ResponseResult.SuccessResult();
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            return ResponseResult.ErrorResult(errorMessage, (int)response.StatusCode);
        }
    }
}
