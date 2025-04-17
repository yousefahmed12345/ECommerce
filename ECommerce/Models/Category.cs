using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }


        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [StringLength(10, ErrorMessage ="This {0} Is Specific Between {2},{1}",MinimumLength =5)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }


        //Navigation Property

        public ICollection<Product> Products { get; set; }


    }
}
