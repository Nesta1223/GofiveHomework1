using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.API.Models.Domain
{
    public class Userr
    {
        [Key]
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Role role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<UserPermission> UserPermissions { get; set; } 
  

    }
}
