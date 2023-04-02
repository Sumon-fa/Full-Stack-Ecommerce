using backend.Models;
using backend.Db;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using backend.Common;

namespace backend.Services
{
 public class OrderService : IOrderService
 {
  private readonly AppDbContext _dbContext;
  private readonly UserManager<User> _userManager;

  public OrderService(AppDbContext dbContext, UserManager<User> userManager)
  {
   _dbContext = dbContext;
   _userManager = userManager;
  }

  public async Task<Order> CreateAsync(OrderDTO request, User user)
  {
   var order = new Order()
   {
    Customer = user.Email,
    CartItems =
       (from item in request.CartItems
        select new CartItem()
        {
         ProductId = item.ProductId,
         Amount = item.Amount,
         UpdatedPrice = item.UpdatedPrice
        }).ToList(),
    Status = Order.OrderStatus.Pending
   };
   _dbContext.Orders.Add(order);
   await _dbContext.SaveChangesAsync();
   return order;
  }

  public Task<bool> DeleteAsync()
  {
   throw new NotImplementedException();
  }

  public Task UpdateAsync()
  {
   throw new NotImplementedException();
  }

  public async Task<ICollection<Order>> GetAllAsync()
  {
   var orders = await _dbContext.Orders.ToListAsync();
   if (orders.Count == 0)
   {
    throw ServiceException.NotFound("No order exist.");
   }
   return orders;
  }

  public async Task<Order?> GetSingleOrderAsync(Guid id, User user)
  {
   var orderDetails = await _dbContext.Orders
       .Include(o => o.CartItems)
           .ThenInclude(od => od.Product)
       .FirstOrDefaultAsync(o => o.Id == id && o.Customer == user.Email);
   if (orderDetails is null)
   {
    throw ServiceException.NotFound("No order exist.");
   }
   return orderDetails;
  }

  public async Task<ICollection<Order>> GetMyOrdersAsync(User user)
  {
   var myorders = await _dbContext.Orders.Where(o => o.Customer == user.Email).ToListAsync();
   if (myorders.Count == 0)
   {
    throw ServiceException.NotFound("No order exist.");
   }

   return myorders;
  }

  public async Task<Order?> GetOrderDetailsByAdminAsync(Guid id)
  {
   var orderDetails = await _dbContext.Orders
       .Include(o => o.CartItems)
           .ThenInclude(od => od.Product)
       .FirstOrDefaultAsync(o => o.Id == id);
   if (orderDetails is null)
   {
    throw ServiceException.NotFound("No order exist.");
   }
   return orderDetails;
  }
 }
}