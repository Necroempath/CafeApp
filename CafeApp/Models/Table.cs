namespace CafeApp.Models;

public class Table
{
    public int Id { get; set; }
    public int Number { get; set; }
    
    public string CustomerName {get; set;}
    
    public ICollection<Order> Orders { get; set; }
}