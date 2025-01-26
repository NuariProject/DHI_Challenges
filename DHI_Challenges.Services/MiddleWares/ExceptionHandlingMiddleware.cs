using DHI_Challenges.Models.DataTransferObject;
using System.Text.Json;

namespace DHI_Challenges.Services.MiddleWares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string tracerId = context.Items["TracerId"]?.ToString() ?? Guid.NewGuid().ToString();

                // Log the exception
                _logger.LogError($"TracerId: {tracerId}, Error: {ex.Message}");

                // Return a standardized error response
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new ResponseExceptionDto() 
                {
                    StatusCode =  StatusCodes.Status500InternalServerError,
                    Message = ex.Message, //"An unexpected error occurred."
                    TracerId = tracerId
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
