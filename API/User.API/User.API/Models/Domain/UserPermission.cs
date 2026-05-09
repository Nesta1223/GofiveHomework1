using System.ComponentModel.DataAnnotations;

namespace User.API.Models.Domain
{
    public class UserPermission
    {
        public string userId { get; set; }
        public string permissionId { get; set; }
        public bool isReadable { get; set; }
        public bool isWritable { get; set; }
        public bool isDeletable { get; set; }
    }
}
