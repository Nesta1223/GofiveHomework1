namespace User.API.Models.DTO
{
    public class GetAllUserRequestDto
    {
        public string? orderBy { get; set; }
        public string? orderDirection { get; set; }
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 20;
        public string? search { get; set; }
    }
}
