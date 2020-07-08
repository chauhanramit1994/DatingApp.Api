using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp.Api.DTO;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {
            dto.UserName = dto.UserName.ToLower();
            if (await _repo.UserExists(dto.UserName))
            {
                return BadRequest("User already exists !!"); 
            }

            var userToCreate = new User
            {
                UserName = dto.UserName
            };

            var createdUser = await _repo.Register(userToCreate, dto.Password);

            return StatusCode(201); 
        }
    }
}
