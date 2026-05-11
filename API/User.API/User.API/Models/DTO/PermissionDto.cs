using System.ComponentModel.DataAnnotations;

namespace User.API.Models.DTO
{
    public class PermissionDto
    {
        [Key]
        public string permissionId { get; set; }
        public string permissionName { get; set; }
    }
}
