using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library_Management_Project.Models;

namespace Library_Management_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomizeUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> TblBooks { get; set; }
        public DbSet<Language> TblLanguages { get; set; }
        public DbSet<Library_Management_Project.Models.UserRegistration> UserRegistration { get; set; }
    }
}
