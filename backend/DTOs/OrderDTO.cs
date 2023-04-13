namespace backend.DTOs
{
    public class OrderDTO
    {
        public class CartItemDTO
        {
            public Guid ProductId { get; set; }
            public double UpdatedPrice { get; set; }
            public int Amount { get; set; }
        }

        public ICollection<CartItemDTO> CartItems { get; set; } = null!;
    }
}