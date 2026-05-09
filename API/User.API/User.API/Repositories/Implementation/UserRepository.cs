using Gofive.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using User.API.Data;
using User.API.Models.Domain;

namespace Gofive.API.Repositories.Implementation
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
            await dbContext.Users.AddAsync(userr);
            await dbContext.SaveChangesAsync();
            return userr;
        }
    }
}
