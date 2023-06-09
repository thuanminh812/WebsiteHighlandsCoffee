using HighlandsCoffee.DtoModels;
using Microsoft.AspNetCore.Identity;

namespace HighlandsCoffee.IResponsitories
{
    public interface IUserRes
    {
        Task<(int,string)> RegisterAsync(Register model,string role);
        Task<(int, string)> RegisterUserAsync(Register model, string role);
        Task<(int,string)> LoginAsync(Login model);
    }
}
