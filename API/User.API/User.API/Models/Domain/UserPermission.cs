using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.API.Models.Domain
{
    public class UserPermission
    {
        [Key,Column(Order =0)]
        public string userId { get; set; }
        [Key,Column(Order =1)]
        public string permissionId { get; set; }
        public bool isReadable { get; set; }
        public bool isWritable { get; set; }
        public bool isDeletable { get; set; }

        [ForeignKey("userId")]
        public Userr User { get; set; }

        [ForeignKey("permissionId")]
        public Permission Permission { get; set; }
    }
}
