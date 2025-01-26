using System.Text.Json.Serialization;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class ResponseExceptionDto : ResponseGlobalDto
    {
        [JsonPropertyOrder(5)]
        public string TracerId { get; set; }
    }
}
