namespace backend.Models;
public class CartItem : BaseModel
{
    public Product Product { get; set; } = null!;
    public Guid ProductId { get; set; }
    public double UpdatedPrice { get; set; }
    public int Amount { get; set; }
    public Order Order { get; set; } = null!;
    public Guid OrderId { get; set; }
}