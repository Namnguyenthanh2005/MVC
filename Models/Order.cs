using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Group3.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [StringLength(50, ErrorMessage = "User ID cannot exceed 50 characters.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid order date.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
        public decimal TotalAmount { get; set; }
    }
}
