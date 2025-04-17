using ECommerce.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using ECommerce.Controllers;


namespace ECommerce.Data.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);

        Task CreateAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task DeleteAsync(int id);
      
    }
}
