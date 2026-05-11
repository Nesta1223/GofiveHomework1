using Microsoft.AspNetCore.Mvc;
using User.API.Models.DTO;
using User.API.Repositories.Interface;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController :ControllerBase
    {
        private readonly IRoleRepository roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleRepository.GetAllAsync();
            var response = new List<RoleDto>();
            foreach (var r in roles)
            {
                response.Add(new RoleDto
                    {
                    roleId = r.roleId,
                    roleName = r.roleName
                    }
                );
               
            }
            return Ok(response);
        }
    }
}
