namespace StorexWebAPI.Models
{
    public class Distributed
    {

        public int Id { get; set; }
        public Person? Person { get; set; }
        public int PersonId { get; set; }
        public string CodDistributed { get; set; } = string.Empty;
        public DateTime IncludeDate { get; set; }
    }
}
