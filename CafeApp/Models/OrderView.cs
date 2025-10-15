namespace CafeApp.Models;

/// <summary>
/// Dedicated to represent order properties is GUI
/// It prevents main model from property overloading (TotalPrice)
/// </summary>
public class OrderView
{
    public Order Order { get; set; }
    public decimal TotalPrice { get; set; }

    public OrderView(Order order)
    {
        Order = order;
        TotalPrice = order.OrderItems.Sum(oi => oi.Product.Price * oi.Quantity);
    }
}