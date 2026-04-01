using HRSystemWEB.Areas.Auth.Models;
using HRSystemWEB.Helpers;

namespace HRSystemWEB.Services.Auth
{
    public interface IUserService
    {
        Task<ResponseResult> LoginAsync(LoginUserDto model);
    }
}
