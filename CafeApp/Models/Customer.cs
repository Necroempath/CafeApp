namespace CafeApp.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? TableId { get; set; }
    
    public Table? Table { get; set; }
}