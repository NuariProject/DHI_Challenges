using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class ResponseTransactionHeaderDto : RequestTransactionHeaderDto<ResponseransactionDetailDto>
    {
        [JsonPropertyOrder(1)]
        public int HeaderID { get; set; }

        [JsonPropertyOrder(3)]
        public int SummaryQuantity { get; set; }

        [JsonPropertyOrder(4)]
        public DateTime CreateDate { get; set; }
    }
    public class ResponseransactionDetailDto : RequestTransactionDetailDto
    {
        [JsonPropertyOrder(3)]
        public decimal Price { get; set; }
    }
}
