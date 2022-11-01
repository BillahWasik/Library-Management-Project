using Library_Management_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Library_Management_Project.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<CustomizeUser> _userManager;

        public AccountRepository(UserManager<CustomizeUser> _userManager)
        {
            this._userManager = _userManager;
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
                     var data =  await  _userManager.CreateAsync(user , obj.Password);
            return data;
        }
    }
}
