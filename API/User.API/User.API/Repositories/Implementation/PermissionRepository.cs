using Microsoft.EntityFrameworkCore;
using User.API.Data;
using User.API.Models.Domain;
using User.API.Repositories.Interface;

namespace User.API.Repositories.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PermissionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await dbContext.Permissions.ToListAsync();
        }
    }
}
