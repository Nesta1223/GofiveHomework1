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


        public Task<IEnumerable<Userr>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Userr?> GetById(string id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.userId == id);
        }

        public Task<Userr?> UpdateAsync(Userr userr)
        {
            throw new NotImplementedException();
        }
        public Task<Userr?> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
