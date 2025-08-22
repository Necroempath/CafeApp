namespace CafeApp.Models;

public class Employee
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime HireDate { get; set; }
    
    public decimal Salary { get; set; }
    
    public decimal Premium { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}