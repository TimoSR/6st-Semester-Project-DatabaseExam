namespace API.Neo4j.Models;

public class NeoActivity
{
        public Guid id { get; set; }

        public string? title { get; set; }

        public DateTime date { get; set; }

        public string? description { get; set; }

        public string? category { get; set; }
        
        public string? address { get; set; }

        public bool isCancelled { get; set; }

}