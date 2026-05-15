using User.API.Models.Domain;

namespace User.API.Models.DTO
{
    public class UpdateUserRequestDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string? phone { get; set; } = string.Empty;
        public string roleId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<UserPermission> permissions { get; set; } = new();
    }
}
