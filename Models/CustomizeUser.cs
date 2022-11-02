using Microsoft.AspNetCore.Identity;

namespace Library_Management_Project.Models
{
    public class CustomizeUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
