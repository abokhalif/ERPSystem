using HRSystemWEB.Areas.Auth.Models;
using HRSystemWEB.ExtensionServices;
using HRSystemWEB.Helpers;
using Newtonsoft.Json;

namespace HRSystemWEB.Services.Auth
{
    public class UserService:IUserService
    {
        private readonly IHttpClientService _httpClientService;

        public UserService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseResult> LoginAsync(LoginUserDto model)
        {
            var requestModel = new RequestModel(HttpMethod.Post, "api/Authentication/Login", model);
            return await _httpClientService.SendRequestAsync(requestModel);
        }

    }
}
