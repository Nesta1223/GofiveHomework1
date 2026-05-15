using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.API.Models.Domain
{
    public class UserPermission
    {
        public string permissionId { get; set; }
        public bool isReadable { get; set; }
        public bool isWritable { get; set; }
        public bool isDeletable { get; set; }
    }
}
