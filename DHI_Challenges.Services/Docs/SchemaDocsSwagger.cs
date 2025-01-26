using DHI_Challenges.Models.DataTransferObject;
using DHI_Challenges.Services.Utils;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DHI_Challenges.Services.Docs
{
    public class SchemaDocsSwagger : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(ResponseGlobalDto))
            {
                schema.Example = new OpenApiObject
                {
                    ["statusCode"] = new OpenApiInteger(StatusCodes.Status200OK),
                    ["message"] = new OpenApiString(Message.SUCCESS),
                    ["data"] = new OpenApiArray { new OpenApiString(Message.TEXT_OA_DATA) }
                };
            }
            else if (context.Type == typeof(ResponseErrorDto))
            {
                schema.Example = new OpenApiObject
                {
                    ["statusCode"] = new OpenApiInteger(StatusCodes.Status404NotFound),
                    ["message"] = new OpenApiString(Message.DATA_NOT_FOUND),
                    ["data"] = new OpenApiString(null),
                    ["errors"] = new OpenApiArray { new OpenApiString(Message.TEXT_OA_ERROR) }
                };
            }
            else if (context.Type == typeof(ResponseExceptionDto))
            {
                schema.Example = new OpenApiObject
                {
                    ["statusCode"] = new OpenApiInteger(StatusCodes.Status500InternalServerError),
                    ["message"] = new OpenApiString(Message.VALIDATION_ERROR),
                    ["data"] = new OpenApiString(null),
                    ["tracerId"] = new OpenApiString(Message.TEXT_OA_TRACER)
                };

            }
        }
    }
}
