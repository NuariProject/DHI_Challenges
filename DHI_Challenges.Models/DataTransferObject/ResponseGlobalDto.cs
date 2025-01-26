using System.Text.Json.Serialization;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class ResponseGlobalDto
    {
        [JsonPropertyOrder(1)]
        public int StatusCode { get; set; }

        [JsonPropertyOrder(2)]
        public string Message { get; set; }

        [JsonPropertyOrder(3)]
        public dynamic Data { get; set; }

        [JsonPropertyOrder(4)]
        public dynamic Errors { get; set; }
    }
}
