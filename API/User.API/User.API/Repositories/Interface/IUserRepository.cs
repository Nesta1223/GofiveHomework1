using User.API.Models.Domain;

namespace Gofive.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Userr> CreateAsync(Userr userr);
    }
}
