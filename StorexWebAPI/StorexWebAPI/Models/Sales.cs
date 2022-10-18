namespace StorexWebAPI.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int DistributedId { get; set; }
        public decimal Amount { get; set; }
        public DateTime IncludeDate { get; set; }

    }
}
