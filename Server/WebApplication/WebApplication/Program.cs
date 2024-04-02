using Microsoft.EntityFrameworkCore;
using WebApplication.ApiKeyValidation;
using WebApplication.Middlewares;
using WebApplication.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EntityContext>(opt =>
    opt.UseInMemoryDatabase("Entity"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
