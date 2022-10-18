namespace StorexWebAPI.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime IncludeDate { get; set; }
    }
}
