using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ShopOnline.Api.Data;
using ShopOnline.Api.Repository;
using ShopOnline.Api.Repository.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopOnlineContext>(db => db.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")
    ), ServiceLifetime.Scoped);

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<IProductRepository, ProductQueryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7209", "https://localhost:7209")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
