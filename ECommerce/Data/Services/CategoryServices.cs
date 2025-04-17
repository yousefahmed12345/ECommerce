using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class CategoryServices : EntityBaseRepository<Category>, ICategoryServices
    {
       
        public CategoryServices(EcommerceDbContext context) : base(context)
        {

        }



       
    }
}
