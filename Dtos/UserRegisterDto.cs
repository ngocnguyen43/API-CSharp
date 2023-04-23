namespace WebApi2.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        private string Role { get; set; } = "user";
    }
}
