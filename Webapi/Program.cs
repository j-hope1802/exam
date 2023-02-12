using Infrastructure.Data;
using Infrastructure.MapperProfiles;
using Infrastructure.Service;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IOrderService,OrderService>();

builder.Services.AddSwaggerGenNewtonsoftSupport();  
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(options => 
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(InfrastructureProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
