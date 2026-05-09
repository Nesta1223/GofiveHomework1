using System.ComponentModel.DataAnnotations;

namespace User.API.Models.Domain
{
    public class Permission
    {
        [Key]
        public Guid permissionId { get; set; }
        public string permissionName { get; set; }
    }
}
