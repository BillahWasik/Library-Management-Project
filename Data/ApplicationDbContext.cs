using Microsoft.EntityFrameworkCore;

namespace Library_Management_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> TblBooks { get; set; }
        public DbSet<Language> TblLanguages { get; set; }
    }
}
