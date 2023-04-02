namespace backend.Models;

public class Order : BaseModel
{
 public ICollection<CartItem> CartItems { get; set; } = null!;
 public string Customer { get; set; } = null!;
 public OrderStatus Status { get; set; } = OrderStatus.Pending;

 public enum OrderStatus
 {
  Pending,
  Shipped,
  Delivered
 }
}