namespace CafeApp.Models;

public class Table
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public ICollection<Order> Orders { get; set; }
}