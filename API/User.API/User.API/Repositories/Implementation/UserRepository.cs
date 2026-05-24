using User.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using User.API.Data;
using User.API.Models.Domain;
using User.API.Models.DTO;

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


        public async Task<IEnumerable<Userr>> GetAllAsync(GetAllUserRequestDto requestDto)
        {
            var query = dbContext.Users.Include(u => u.role).Include(u => u.UserPermissions).AsQueryable();
            //search
            if (!string.IsNullOrEmpty(requestDto.search))
            {
                query = query.Where(u => u.firstName.Contains(requestDto.search) 
                        || u.lastName.Contains(requestDto.search) 
                        || u.email.Contains(requestDto.search));



            }
            //sort
            if (!string.IsNullOrEmpty(requestDto.orderBy)){//first name , email , rolename
                query = requestDto.orderBy.ToLower() switch
                {
                    "firstname" => requestDto.orderDirection == "desc"
                    ? query.OrderByDescending(u => u.firstName)
                    : query.OrderBy(u => u.firstName),
                    "email" => requestDto.orderDirection == "desc"
                    ? query.OrderByDescending(u => u.email)
                    : query.OrderBy(u => u.email),
                    "rolename" => requestDto.orderDirection == "desc"
                    ? query.OrderByDescending(u => u.role.roleName)
                    : query.OrderBy(u => u.role.roleName),
                    _=>query
                };
            }

            query = query.Skip((requestDto.pageNumber - 1) * requestDto.pageSize).Take(requestDto.pageSize);


            return await query.ToListAsync();
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
