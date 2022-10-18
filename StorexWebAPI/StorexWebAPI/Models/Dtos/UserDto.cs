namespace StorexWebAPI.Models.Dtos
{
    public class UserDto
    {
        public string Username { get; set; } = default;
        public string Password { get; set; } = default;
        public string Token { get; set; } = default;
        public string Role { get; set; } = default;
        public bool Status { get; set; } = default;

    }
}
