namespace CafeApp.Models;

public class Payment
{
    public int Id { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateTime PaymentTime { get; set; }
    
    public string PaymentMethod { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
}