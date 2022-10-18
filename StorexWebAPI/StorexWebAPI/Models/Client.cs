namespace StorexWebAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Person? Person { get; set; }
        public int PersonId { get; set; }
        public DateTime IncludeDate { get; set; }
    }
}
