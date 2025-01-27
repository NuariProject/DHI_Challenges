using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class RequestTransactionHeaderDto<T>
    {
        [Required(ErrorMessage = "UserID can't be empty")]
        [JsonPropertyOrder(2)]
        public int UserID { get; set; }

        [JsonPropertyOrder(5)]
        public List<T> Details { get; set; }
    }

    public class RequestTransactionDetailDto
    {
        [Required(ErrorMessage = "ProductID can't be empty")]
        [JsonPropertyOrder(1)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Quantity can't be empty")]
        [Range(1, 100, ErrorMessage = "Quantity must be in the range 1 to 100")]
        [JsonPropertyOrder(2)]
        public int Quantity { get; set; }
    }
}
