using User.API.Models.Domain;
using User.API.Models.DTO;

namespace User.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Userr> CreateAsync(Userr userr);

        Task<IEnumerable<Userr>> GetAllAsync(GetAllUserRequestDto request);
        Task<Userr?> GetById(string id);
        Task<Userr?> UpdateAsync(Userr userr);
        Task<bool> DeleteAsync(string id);
    }
}
