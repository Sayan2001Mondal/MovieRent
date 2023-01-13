using MovieRent.Web.Infrastructure;
using MovieRent.Web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieRent.Web.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(string Email, string Password);
        Task<ServiceResponse<int>> Register(User user, string Password);
    }
}
