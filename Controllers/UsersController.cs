using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuevoProyecto.API.Models;
using NuevoProyecto.API.Services;

using NuevoProyecto.API.IServices;
using NuevoProyecto.API.DTO;

namespace NuevoProyecto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
       private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            
            if (user == null)
                return NotFound($"User with ID {id} not found");
                
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email
            };
            return Ok(userDto);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<Users>> Create([FromBody] Users user)
        {
            try
            {
                await _userService.AddAsync(user);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Users user)
        {
            if (id != user.Id)
                return BadRequest("User ID mismatch");
                
            try
            {
                await _userService.UpdateAsync(user);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        //POST: api/users/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            // Validate model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate credentials
            var isValid = await _userService.ValidateCredentialsAsync(loginDto.Email, loginDto.Password);
            
            if (!isValid)
                return Unauthorized("Invalid email or password");

            // Get user details for the response
            var user = await _userService.GetByEmailAsync(loginDto.Email);
            
            // Map to DTO to not expose sensitive info
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.UserName,  // Note: This should match the property name in Users class
                Email = user.Email
            };

            // In a real application, you would generate a JWT token here
            // and return it with the user info
            
            //create JWT token
            // var token = _tokenService.GenerateToken(user);
            return Ok(new 
            { 
                User = userDto,
                Token = "JWT_TOKEN_WOULD_GO_HERE" // Placeholder
            });
        }
    }
}