using User.API.Models.DTO;
using User.API.Repositories.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using User.API.Models.Domain;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Gofive.API.Models.DTO;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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


        //Post api
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
        //Get all api
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()//add parameter later
        {
            var users = await userRepository.GetAllAsync();
            var response = new List<UserDto>();
            foreach (var u in users)
            {
                var dto = new UserDto
                {
                    userId = u.userId,
                    firstName = u.firstName,
                    lastName = u.lastName,
                    phone = u.phone,
                    email = u.email,
                    username = u.username,
                    role = u.role,
                    permissions = new List<Permission>()

                };
                foreach (var userPermission in u.UserPermissions)
                {
                    var permission = await permissionRepository.GetById(userPermission.permissionId);
                    dto.permissions.Add(permission);
                }
                response.Add(dto);
            }
            return Ok(response);
        }
        //Get by id api
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var existUser = await userRepository.GetById(id);
            if (existUser == null)
            {
                return NotFound();
            }
            var response = new UserDto
            {
                userId = id,
                firstName = existUser.firstName,
                lastName = existUser.lastName,
                phone = existUser.phone,
                email = existUser.email,
                username = existUser.username,
                role = existUser.role,
                permissions = new List<Permission>()

            };
            foreach (var userPermission in existUser.UserPermissions)
            {
                var permission = await permissionRepository.GetById(userPermission.permissionId);
                response.permissions.Add(permission);
            }
            return Ok(response);
        }
        //put api
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditUser([FromRoute] string id , UpdateUserRequestDto updateUserRequestDto)
        {
            //validate roleId
            var r = await roleRepository.GetById(updateUserRequestDto.roleId);
            if (r == null)
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
            var user = new Userr
            {
                userId = id,
                firstName = updateUserRequestDto.firstName,
                lastName = updateUserRequestDto.lastName,
                email = updateUserRequestDto.email,
                password = updateUserRequestDto.password,
                phone = updateUserRequestDto.phone,
                role = r,
                username = updateUserRequestDto.username,
                UserPermissions = new List<UserPermission>()
            };
            //validate every permissionId
            foreach (var permission in updateUserRequestDto.permissions)
            {
                var p = await permissionRepository.GetById(permission.permissionId);
                if (p == null)
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
                user.UserPermissions.Add(permission);


            }
            user =await userRepository.UpdateAsync(user);

            var response = new UserDto
            {
                userId = id,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                role = user.role,
                username = user.username,
                permissions = new List<Permission>()

            };
            foreach (var userPermission in user.UserPermissions)
            {
                var permission = await permissionRepository.GetById(userPermission.permissionId);
                response.permissions.Add(permission);
            }
            return Ok(response);
        }

        //Delete API
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            bool success = await userRepository.DeleteAsync(id);
            var response = new DeleteUserResponseDto();
            if (success)
            {
                response.result = true;
                response.message = "Deletion completed";
                return Ok(response);
            }
            else
            {
                response.result = false;
                response.message = "Deletion failed";
                return NotFound();
            }
        }

    }
}
