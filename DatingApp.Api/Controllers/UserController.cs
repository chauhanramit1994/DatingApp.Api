using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _DbContext;
        public UserController(DataContext dbcontext)
        {
            _DbContext = dbcontext;
        }

        //GetAllUsers
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _DbContext.users.ToListAsync();
            return Ok(users);
        }

        //GetUserById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _DbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
    }
}
