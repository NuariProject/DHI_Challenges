using DHI_Challenges.Models.DataTransferObject;
using DHI_Challenges.Services.Infrastructures;
using DHI_Challenges.Services.MiddleWares;
using DHI_Challenges.Services.Repositories;
using DHI_Challenges.Services.Repositories.IRepositories;
using DHI_Challenges.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DHIContexts>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("dhi_connect")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .Select(ms => new ValidationErrorsDto
            {
                Field = ms.Key,
                Message = ms.Value.Errors.First().ErrorMessage
            })
            .ToList();

        ResponseErrorDto response = new()
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = Message.VALIDATION_ERROR,
            Errors = errors
        };

        return new BadRequestObjectResult(response);
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
