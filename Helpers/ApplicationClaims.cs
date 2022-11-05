using Library_Management_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library_Management_Project.Helpers
{
    public class ApplicationClaims : UserClaimsPrincipalFactory<CustomizeUser , IdentityRole>
    {
        public ApplicationClaims(UserManager<CustomizeUser> userManager, RoleManager<IdentityRole> roleManager , IOptions<IdentityOptions>  options) : base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(CustomizeUser user)
        {
             var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("LastName", user.LastName ?? ""));

            return identity;
        }
    }
}
