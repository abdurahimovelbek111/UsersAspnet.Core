using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UsersAspnet.Core.Context;
using UsersAspnet.Core.Models;

namespace UsersAspnet.Core.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserController(ApplicationDbContext  applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var user = _applicationDbContext.Users;
            return Ok(user);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user =_applicationDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user is null)
                return NotFound($"Bunday {id}-->Id dagi User ma'lumotlari yuq . Iltimos qaytadan Users ro'yxatini qaytadan ko'rib chiqing !!!");

            return Ok(user);
        }
        [HttpPost]
        public IActionResult PostUser([FromBody]User user)
        {
            _applicationDbContext.AddAsync(user);
            _applicationDbContext.SaveChanges();
            return Created("", user);
        }
        [HttpDelete("{id}")]
        public IActionResult GetUserDelete(int id)
        {
            var user = _applicationDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user is null)
                return NotFound($"Uchirish uchun bunday {id}->Id dagi  User ma'lumotlari yuq . Iltimos qaytadan Users ro'yxatini qaytadan ko'rib chiqing !!!");
                _applicationDbContext.Remove(user);
                _applicationDbContext.SaveChanges();          
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult GetUserUpdate(int id,[FromBody]User user)
        {
            if (id == user.Id)
            {
                _applicationDbContext.Update(user);
                _applicationDbContext.SaveChanges();
            }
            else
                NotFound($"Update qilishda {id}-->Id dagi User ma'lumotlari yuq .Iltimos qaytadan Users ro'yxatini qaytadan ko'rib chiqing !!!");
            return Ok(user);
        }

    }

}
