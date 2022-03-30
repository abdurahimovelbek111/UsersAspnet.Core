using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UsersAspnet.Core.Context;
using UsersAspnet.Core.Interface;
using UsersAspnet.Core.Models;

namespace UsersAspnet.Core.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAsync _userAsync;

        public UserController(IUserAsync userAsync)
        {
            _userAsync = userAsync;
        }
        [HttpGet()]
        public async  Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userAsync.GetAllAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userAsync.GetByIdAsync(id));
        }
        [HttpPost()]
        public async Task<IActionResult> PostUser([FromBody]User user)
        {
            return Created("", await _userAsync.AddAsync(user));
        }


    }
}
