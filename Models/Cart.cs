using System.ComponentModel.DataAnnotations;

namespace MVC_Group3.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [StringLength(50, ErrorMessage = "User ID cannot exceed 50 characters.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid product ID.")]
        public int ShoeId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        public Shoe Shoe { get; set; }
    }
}
