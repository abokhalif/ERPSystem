using HRSystemWEB.ExtensionServices;
using HRSystemWEB.Helpers;
using Newtonsoft.Json;
using System.Reflection;

namespace HRSystemWEB.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientService _httpClientService;

        public EmployeeService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseResult> GetAllDataAsync()
        {
            var requestModel = new RequestModel(HttpMethod.Get, "api/Employee");
            var response = await _httpClientService.SendRequestAsync(requestModel);
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;

        }
    }
}
