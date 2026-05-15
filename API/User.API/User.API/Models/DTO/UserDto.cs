using System.ComponentModel.DataAnnotations;
using User.API.Models.Domain;

namespace Gofive.API.Models.DTO
{
    public class UserDto
    {
        [Key]
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Role role { get; set; }
        public string username { get; set; }
        public List<Permission> permissions { get; set; } = new();
    }
}
