using User.API.Models.Domain;

namespace User.API.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetById(string id);
    }
}
