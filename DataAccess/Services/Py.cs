using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class Py:IPy
    {
        private readonly HttpClient _httpClient;

        public Py(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GenerateResponseAsync(string query)
        {
            var requestBody = new { query };
            var response = await _httpClient.PostAsJsonAsync("http://localhost:44309/generate_response_API", requestBody);

            response.EnsureSuccessStatusCode(); // Throw if HTTP error
            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
