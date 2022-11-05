using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Library_Management_Project.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;
        public UserService(IHttpContextAccessor _context)
        {
            this._context = _context;
        }
        public string GetUserId()
        {
            return _context.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            
        }
        public bool LoggedIn() 
        {
            return _context.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
