namespace StorexWebAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public DateTime IncludeDate { get; set; }
        public string? Guid { get; set; } = new Guid().ToString();
    }
}
