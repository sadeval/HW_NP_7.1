using Microsoft.AspNetCore.Mvc;
using UserRegistrationServer.Models;

namespace UserRegistrationServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        [HttpPost]
        public IActionResult Register([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Пользователь не может быть null");
            }

            if (string.IsNullOrEmpty(newUser.Username) || string.IsNullOrEmpty(newUser.Password) || string.IsNullOrEmpty(newUser.Email))
            {
                return BadRequest("Все поля обязательны для заполнения");
            }

            if (users.Any(u => u.Username == newUser.Username))
            {
                return Conflict("Пользователь с таким именем уже существует");
            }

            newUser.Id = nextId++;
            users.Add(newUser);

            return Ok(new { Message = "Пользователь успешно зарегистрирован", UserId = newUser.Id });
        }
    }
}
