namespace DHI_Challenges.Models.DataTransferObject
{
    public class ResponseGlobalDto
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public dynamic Errors { get; set; }
    }
}
