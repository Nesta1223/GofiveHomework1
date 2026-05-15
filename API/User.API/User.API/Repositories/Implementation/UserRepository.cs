using User.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using User.API.Data;
using User.API.Models.Domain;

namespace User.API.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<Userr> CreateAsync(Userr userr)
        {
            //bool no = false;
            //var r = await dbContext.Roles.FirstOrDefaultAsync(x => x.roleId== userr.role.roleId);
        
            await dbContext.Users.AddAsync(userr);
            await dbContext.SaveChangesAsync();
            return userr;
        }


        public async Task<IEnumerable<Userr>> GetAllAsync()
        {
            return await dbContext.Users.Include(u =>u.role).Include(u => u.UserPermissions).ToListAsync();
        }

        public async Task<Userr?> GetById(string id)
        {
            return await dbContext.Users.Include(u => u.role).Include(u => u.UserPermissions).FirstOrDefaultAsync(x => x.userId == id);
        }

        public async Task<Userr?> UpdateAsync(Userr userr)
        {
            var existingUser = await dbContext.Users.Include(u => u.role).Include(u => u.UserPermissions).FirstOrDefaultAsync(x => x.userId == userr.userId);
            if (existingUser != null)
            {
                dbContext.Entry(existingUser).CurrentValues.SetValues(userr);
                await dbContext.SaveChangesAsync();
                return userr;
            }
            return null;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var existUser = await dbContext.Users.Include(u => u.role).Include(u =>u.UserPermissions).FirstOrDefaultAsync(x => x.userId == id);
            if (existUser != null)
            {
                dbContext.Remove(existUser);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
