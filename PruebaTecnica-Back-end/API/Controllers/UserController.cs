using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaBackend.Domain.DTO;
using PruebaTecnica_Back_end.Application.Services;
using PruebaTecnica_Back_end.Domain.Entities;

namespace PruebaBackend.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/admin")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("list")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpPost("create")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userService.AddUserAsync(user);
            return Ok(user);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> UserFindById(int id)
        {
      
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            ResponseDTO response = new ResponseDTO();
            var user = await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                await _userService.DeleteUserAsync(id);
                response.Messsage = "Deleted User";
            }
            else
            {
                response.Messsage = "User not found";
            }
            return Ok(response);
        }

        [HttpPut("edit/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> EditUser([FromBody] User user, int id)
        {
            ResponseDTO response = new ResponseDTO();
            User userFind = await _userService.GetUserByIdAsync(id);
            if (userFind != null)
            {
                userFind.UserName = user.UserName;
                userFind.Email = user.Email;
                userFind.Password = user.Password;
                userFind.Role = user.Role;
                User userupdate = await _userService.UpdateUserAsync(userFind);
                return Ok(userupdate);
            }
            else
            {
                response.Messsage = "User not found";
                return Ok(response);
            }

        }

        [HttpPut("role/{userId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AssignRole(int idUser, [FromBody] string role)
        {
            try
            {
                await _userService.AssignRoleToUserAsync(idUser, role);
                return Ok(new { message = "Role assigned successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

}
