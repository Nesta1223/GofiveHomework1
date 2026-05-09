using System.ComponentModel.DataAnnotations;
using User.API.Models.Domain;

namespace Gofive.API.Models.DTO
{
    public class UserDto
    {
        [Key]
        public Guid userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Role role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Permission> permissions { get; set; } = new();
    }
}
