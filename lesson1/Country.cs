namespace lesson1;

public class Country
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CapitalCity { get; set; }
    public int Population { get; set; }
    public int? Area { get; set; }
    
    public virtual Continent? Continent { get; set; }
}