using Microsoft.EntityFrameworkCore;
using telecom.Modules.Telecom.Data;
using telecom.Modules.Customer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RegisterPackageService>();

builder.Services.AddDbContext<TelecomContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); 
app.Run();