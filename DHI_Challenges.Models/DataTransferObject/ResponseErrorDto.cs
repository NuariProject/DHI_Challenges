using System.Text.Json.Serialization;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class ResponseErrorDto : ResponseGlobalDto
    {
        [JsonPropertyOrder(4)]
        public dynamic Errors { get; set; }
    }
}
