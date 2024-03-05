using System.ComponentModel.DataAnnotations;

namespace forms_page.Models
{
    public class Product
    {
        [Display(Name="Product Id")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name="Product Name")]
        public string Name { get; set; } = string.Empty; // same with string? - nullable 

        [Required]
        [Range(1,1000)]
        [Display(Name="Price")]
        public decimal? Price { get; set; } // [Required] annotation 

        [Required]
        [Display(Name="Image")]
        public string? Image { get; set; } = string.Empty;
        
        [Display(Name="Is Product In Stock")]
        public bool IsInStock { get; set; }

        [Required]
        [Display(Name="Category")]
        public int CategoryId { get; set; } //foreign key


    }
}