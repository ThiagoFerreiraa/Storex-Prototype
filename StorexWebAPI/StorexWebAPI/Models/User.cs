namespace StorexWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public string Role { get; set; } = string.Empty;
        public int? PersonId { get; set; }
        public DateTime IncludeDate { get; set; }
    }
}
