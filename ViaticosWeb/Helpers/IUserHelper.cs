using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Viaticos.Common.Enums;
using Viaticos.Web.Data.Entities;
using Viaticos.Web.Models;
using ViaticosWeb.Models;

namespace ViaticosWeb.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<UserEntity> AddUserAsync(AddUserViewModel model, UserType userType);
    }
}
