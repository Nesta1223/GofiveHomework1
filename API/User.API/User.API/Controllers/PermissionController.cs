using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using User.API.Models.DTO;
using User.API.Repositories.Interface;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await permissionRepository.GetAllAsync();

            var response = new List<PermissionDto>();
            foreach(var p in permissions)
            {
                response.Add(new PermissionDto
                {
                    permissionId = p.permissionId,
                    permissionName = p.permissionName
                });
            }
            return Ok(response);
        } 
    }
}
