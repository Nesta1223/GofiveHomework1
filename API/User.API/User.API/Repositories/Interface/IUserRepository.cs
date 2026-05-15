using User.API.Models.Domain;

namespace User.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Userr> CreateAsync(Userr userr);

        Task<IEnumerable<Userr>> GetAllAsync();
        Task<Userr?> GetById(string id);
        Task<Userr?> UpdateAsync(Userr userr);
        Task<Userr?> DeleteAsync(string id);
    }
}
