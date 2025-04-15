using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptoin { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public Data.ProductColor ProductColor { get; set; }

        // Navigation Property

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }


}   
