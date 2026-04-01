using HRSystemWEB.Areas.Auth.Models;
using HRSystemWEB.Helpers;

namespace HRSystemWEB.Services.Employee
{
    public interface IEmployeeService
    {
        Task<ResponseResult> GetAllDataAsync();
    }
}
