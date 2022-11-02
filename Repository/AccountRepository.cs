using Library_Management_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Library_Management_Project.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<CustomizeUser> _userManager;
        private readonly SignInManager<CustomizeUser> _signInManager;

        public AccountRepository(UserManager<CustomizeUser> _userManager, SignInManager<CustomizeUser> _signInManager)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserRegistration obj)
        {
            var user = new CustomizeUser()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                UserName = obj.Email

            };
            var data = await _userManager.CreateAsync(user, obj.Password);
            return data;
        }
        public async Task<SignInResult> LoginUser(SignInUser obj)
        {
            var data = await _signInManager.PasswordSignInAsync(obj.Email, obj.Password, obj.RememberMe, false);
            return data;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
