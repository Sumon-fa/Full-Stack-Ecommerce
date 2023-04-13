using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(OrderDTO request, User user);
        Task<Order?> GetSingleOrderAsync(Guid id, User user);
        Task<ICollection<Order>> GetMyOrdersAsync(User user);
        Task UpdateAsync();
        Task<bool> DeleteAsync();
        public Task<Order?> GetOrderDetailsByAdminAsync(Guid id);
        Task<ICollection<Order>> GetAllAsync();
    }
}