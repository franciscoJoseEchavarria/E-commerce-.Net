using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuevoProyecto.API.src.Core.Interfaces

;
using NuevoProyecto.API.src.Application.DTOs;
using NuevoProyecto.API.src.Core.Entities
;

namespace NuevoProyecto.API.src.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        // 1. Inyección de dependencias: Recibimos IUserService por constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // 2. GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // 3. GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }

        // 4. POST: api/users/register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserDto userDto)
        {
            var createdUser = await _userService.AddAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // 5. POST: api/users/login
        [HttpPost("login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginDto loginDto)
        {
            var isValid = await _userService.ValidateCredentialsAsync(loginDto.Email, loginDto.Password);
            return Ok(isValid);
        }

        // 6. PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest("ID mismatch");

            await _userService.UpdateAsync(id, userDto);
            return NoContent();
        }

        // 7. DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        // 8. GET: api/users/email/john@example.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}

