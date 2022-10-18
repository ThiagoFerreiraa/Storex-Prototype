namespace StorexWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime IncludeDate { get; set; }
    }
}
