using System.ComponentModel.DataAnnotations;

namespace forms_page.Models
{
    public class Product
    {
        [Display(Name="Product Id")]
        public int ProductId { get; set; }
         [Display(Name="Product Name")]
        public string Name { get; set; } = string.Empty; // same with string? - nullable 
         [Display(Name="Price")]
        public decimal Price { get; set; }
         [Display(Name="Product Image")]
        public string Image { get; set; } = string.Empty;
         [Display(Name="In Stock")]
        public bool IsInStock { get; set; }
         [Display(Name="Category Id")]
        public int CategoryId { get; set; } //foreign key


    }
}