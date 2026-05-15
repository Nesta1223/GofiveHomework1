using System.ComponentModel.DataAnnotations;

namespace User.API.Models.Domain
{
    public class Permission
    {
        [Key]
        public string permissionId { get; set; }
        public string permissionName { get; set; }

        //public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
