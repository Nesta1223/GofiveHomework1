using User.API.Models.Domain;

namespace User.API.Repositories.Interface
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission> GetById(string id);
    }
}
