using HRSystemWEB.Helpers;

namespace HRSystemWEB.ExtensionServices
{
    public interface IHttpClientService
    {
        Task<ResponseResult> SendRequestAsync(RequestModel requestModel);
    }
}
