using System.ComponentModel.DataAnnotations;
namespace EndPointParametersTask.ProductDTO
{
    public class ProductInputDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public string Category { get; set; } = "general"; 
    }
}
