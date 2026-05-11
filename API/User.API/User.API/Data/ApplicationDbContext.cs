using Microsoft.EntityFrameworkCore;
using User.API.Models.Domain;
//using User.API.Models.Domain.User;

namespace User.API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Userr> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { roleId = "1", roleName = "HR Admin" },
                new Role { roleId = "2", roleName = "Super Admin" },
                new Role { roleId = "3", roleName = "Admin" },
                new Role { roleId = "4", roleName = "Employee" }
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { permissionId = "1", permissionName = "Manage Users" },
                new Permission { permissionId = "2", permissionName = "Manage Reports" },
                new Permission { permissionId = "3", permissionName = "Manage Invoices" }
            );

            modelBuilder.Entity<UserPermission>().HasKey(up => new { up.userId, up.permissionId });
    
        }
    }
}
