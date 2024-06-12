using Backend.Api.Dto;
using Backend.Database.Models;
using Backend.Database.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController(UserRepository _userRepository) : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IResult> Register([FromBody] UserRegistrationDto registrationDto)
        {
            var userByEmail = _userRepository.GetUserByEmail(registrationDto.Email);
            if (userByEmail is not null)
                return Results.Unauthorized();

            var newUser = new User
            {
                Email = registrationDto.Email,
                Password = registrationDto.Password,
                Role = registrationDto.UserType,
            };

            var userId = await _userRepository.CreateEntityAsync(newUser);

            return Results.Ok(new UserAuthResponseDto { Id = userId, UserType = registrationDto.UserType } );
        }

        [HttpPost]
        [Route("login")]
        public async Task<IResult> Login([FromBody] UserLoginDto loginDto)
        {
            var userByEmail = await _userRepository.GetUserByEmail(loginDto.Email);
            if (userByEmail == null)
                return Results.Unauthorized();


            if (userByEmail.Email == loginDto.Email && userByEmail.Password == loginDto.Password)
                return Results.Ok(new UserAuthResponseDto { Id = userByEmail.Id, UserType = userByEmail.Role });
            else
                return Results.Unauthorized();
        }
    }
}
