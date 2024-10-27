namespace UserRegistrationServer.Models
{
    public class User
    {
        public int Id { get; set; } // Идентификатор пользователя
        public string Username { get; set; }
        public string Password { get; set; } // В реальном приложении пароль должен быть захеширован
        public string Email { get; set; }
    }
}