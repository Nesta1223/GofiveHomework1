using Gofive.API.Models.DTO;
using Gofive.API.Repositories.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using User.API.Models.Domain;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Gofive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            var user = new Userr
            {
                userId = createUserRequestDto.userId,
                firstName = createUserRequestDto.firstName,
                lastName = createUserRequestDto.lastName,
                email = createUserRequestDto.email,
                phone = createUserRequestDto.phone,
                //create role later
                username = createUserRequestDto.username,
                password = createUserRequestDto.password,
                //create userPermission later

            };


            await userRepository.CreateAsync(user);
            var response = new UserDto
            {
                userId = user.userId,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                //create role later
                username = user.username,
                password = user.password,
                //create userPermission later

            };
            return Ok(response);

        }
    }
}
