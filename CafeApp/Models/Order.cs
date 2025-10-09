namespace CafeApp.Models;

public class Order
{
    public int Id { get; set; }
    public decimal Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public bool IsCompleted { get; set; }
    public int? PaymentId { get; set; }
    public int EmployeeId { get; set; }

    public int TableId { get; set; }
    
    public Employee ServicedBy { get; set; }
    
    public Table OrderedBy { get; set; }
    
    public Payment? Payment { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}