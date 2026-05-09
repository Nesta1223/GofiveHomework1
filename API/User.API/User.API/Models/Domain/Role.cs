using System.ComponentModel.DataAnnotations;

namespace User.API.Models.Domain
{
    public class Role
    {
        [Key]
        public Guid roleId { get; set; }
        public string roleName { get; set; }
    }
}
