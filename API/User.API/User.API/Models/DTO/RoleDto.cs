using System.ComponentModel.DataAnnotations;

namespace User.API.Models.DTO
{
    public class RoleDto
    {
        [Key]
        public string roleId { get; set; }
        public string roleName { get; set; }
    }
}
