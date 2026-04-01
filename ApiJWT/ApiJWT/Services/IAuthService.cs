using ApiJWT.Model;

namespace ApiJWT.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
       // Task<AuthModel> LoginAsync(LoginModel model);
        Task<List<string>> GetRolesAsync(string email);


    }
}
