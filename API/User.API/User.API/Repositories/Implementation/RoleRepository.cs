using Microsoft.EntityFrameworkCore;
using User.API.Data;
using User.API.Models.Domain;
using User.API.Repositories.Interface;

namespace User.API.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await applicationDbContext.Roles.ToListAsync();
        }
    }
}
