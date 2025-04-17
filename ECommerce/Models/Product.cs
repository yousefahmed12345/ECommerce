using ECommerce.Data.Base;
using ECommerce.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public string Image { get; set; }
        public ProductColor ProductColor { get; set; }

        // Navigation Property

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }


}   
