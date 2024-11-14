using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;
using TextilesGeomar.Orders.API.Repositories;
using TextilesGeomar.Orders.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Register services
builder.Services.AddScoped<IConsumeOrderRepository, ConsumeOrderRepository>();
builder.Services.AddScoped<IConsumeOrderService, ConsumeOrderService>();
builder.Services.AddSingleton<IHostedService, RabbitMqConsumerService>();


//// Registering DbContext with dependency injection
builder.Services.AddDbContext<TextilesGeomarDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
