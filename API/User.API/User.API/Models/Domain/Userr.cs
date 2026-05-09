using System.ComponentModel.DataAnnotations;

namespace User.API.Models.Domain
{
    public class Userr
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
