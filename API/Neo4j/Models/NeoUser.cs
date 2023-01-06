namespace API.Neo4j.Models;

public class NeoUser
{
    
    public Guid id { get; set; }
    
    public string? userName { get; set; }
    
    public string? displayName { get; set; }
    
    public string? email { get; set; }

    public string? address { get; set; }
    
}