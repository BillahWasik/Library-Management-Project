using Library_Management_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Library_Management_Project.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(UserRegistration obj);
        Task<SignInResult> LoginUser(SignInUser obj);
        Task LogOut();
        Task<IdentityResult> ChangePassword(ChangePasswordModel obj);
    }
}