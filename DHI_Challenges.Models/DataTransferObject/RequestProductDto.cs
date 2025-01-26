using System.ComponentModel.DataAnnotations;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class RequestProductDto
    {
        [Required(ErrorMessage = "ProductName Can't Empty")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "ProductName Maximal 25 Character")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price can't be empty")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
    }
}
