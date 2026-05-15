using User.API.Models.DTO;
using User.API.Repositories.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using User.API.Models.Domain;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Gofive.API.Models.DTO;

namespace Gofive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IPermissionRepository permissionRepository;
        private readonly IRoleRepository roleRepository;

        public UsersController(IUserRepository userRepository, IPermissionRepository permissionRepository , IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.permissionRepository = permissionRepository;
            this.roleRepository = roleRepository;
        }

        [HttpPost]//Incomplete
        public async Task<IActionResult> CreateUser(CreateUserRequestDto createUserRequestDto)

        {
            //find existing userid
            var u = await userRepository.GetById(createUserRequestDto.userId);
            if (u != null)
            {
                return NotFound(new
                {
                    status = new
                    {
                        code = "400",
                        description = "Already have this userId"
                    },
                    data = (object)null
                });
            }
            //validate roleId
            var r = await roleRepository.GetById(createUserRequestDto.roleId);
            if (r== null)
            {
                return NotFound(new
                {
                    status = new
                    {
                        code = "404",
                        description = "Role not found"
                    },
                    data = (object)null
                });
            }
            //validate every permissionId
            foreach (var permission in createUserRequestDto.permissions) {
                var p =await permissionRepository.GetById(permission.permissionId);
                if(p == null)
                {
                    return NotFound(new
                    {
                        status = new
                        {
                            code = "404",
                            description = "One of the permission not found"
                        },
                        data = (object)null
                    });
                }

            }
            //Create new user to add into database
            var user = new Userr
            {
                userId = createUserRequestDto.userId,
                firstName = createUserRequestDto.firstName,
                lastName = createUserRequestDto.lastName,
                email = createUserRequestDto.email,
                phone = createUserRequestDto.phone,
                role = r,
                username = createUserRequestDto.username,
                password = createUserRequestDto.password,
                UserPermissions = new List<UserPermission>()


            };
            //create response
            var response = new UserDto
            {
                userId = user.userId,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                role = r,
                username = user.username,
                permissions = new List<Permission>()    
                

            };
            //Add every UserPermission into List<> field and Add every Permission into response
            foreach(var permission in createUserRequestDto.permissions)
            {
                //for the database
                var userpermission = new UserPermission
                {
                    permissionId = permission.permissionId,
                    isReadable = permission.isReadable,
                    isDeletable = permission.isDeletable,
                    isWritable = permission.isWritable,

                };
                user.UserPermissions.Add(userpermission);
                //for response
                var p =await permissionRepository.GetById(permission.permissionId);
                response.permissions.Add(p);
            }


            await userRepository.CreateAsync(user);
     
            return Ok(response);

        }
    }
}
