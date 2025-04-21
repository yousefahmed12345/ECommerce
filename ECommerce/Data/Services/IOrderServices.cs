using ECommerce.Data.Cart;
using ECommerce.Models;

namespace ECommerce.Data.Services
{
    public interface IOrderServices
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string uderId);
        Task<List<Order>> GetOrderByUserIdAsync(string userId);
    }
}
