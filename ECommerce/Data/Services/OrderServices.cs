﻿using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly EcommerceDbContext _context;

        public OrderServices(EcommerceDbContext context)
        {
            _context = context;
        }


        public async Task<List<Order>> GetOrderByUserIdAsync(string userId)
              => await _context.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId )
        {
            var order = new Order()
            {
                UserId = userId
            };
            await _context.Orders.AddAsync(order);
            foreach (var item in items)
            {
                var orderitem = new OrderItem() 
                {
                   Amount = item.Amount,
                    Price = item.Product.Price,
                    OrderId = order.Id,
                    ProductId = item.Product.Id
                };
                await _context.OrderItems.AddAsync(orderitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
