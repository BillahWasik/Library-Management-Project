using Library_Management_Project.Models;
using Library_Management_Project.Service;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Library_Management_Project.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<CustomizeUser> _userManager;
        private readonly SignInManager<CustomizeUser> _signInManager;
        private readonly IUserService _service;

        public AccountRepository(UserManager<CustomizeUser> _userManager, SignInManager<CustomizeUser> _signInManager,IUserService _service)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this._service = _service;
            
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

        public async Task<IdentityResult> ChangePassword(ChangePasswordModel obj) 
        {
            var UserId = _service.GetUserId();
            var user =  await _userManager.FindByIdAsync(UserId);
           return await _userManager.ChangePasswordAsync(user ,obj.CurrentPassword,obj.NewPassword);
        }
        public async Task LoggedIn(UserRegistration obj)
        {
            var User = new CustomizeUser()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                UserName = obj.Email
            };
            await _signInManager.SignInAsync(User, false);
        }
    }
}
