using System.ComponentModel.DataAnnotations;

namespace ProoductPrac.Model
{
    public class Product
    {

        public int Id { get; set; }


        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Range(0.01,10000.00, ErrorMessage ="price must be between 0.01 and 10000.00")]
        public decimal Price { get; set; }
    }
}
