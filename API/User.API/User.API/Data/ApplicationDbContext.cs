using Microsoft.EntityFrameworkCore;
using User.API.Models.Domain;
//using User.API.Models.Domain.User;

namespace User.API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Userr> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
