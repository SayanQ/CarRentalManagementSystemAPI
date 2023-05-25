global using CarRentalManagementSystemAPI.Models;
global using CarRentalManagementSystemAPI.ViewModels;
global using CarRentalManagementSystemAPI.Data;
using CarRentalManagementSystemAPI.Services.CarService;
using CarRentalManagementSystemAPI.Services.CustomerService;
using CarRentalManagementSystemAPI.Services.DriverService;
using CarRentalManagementSystemAPI.Services.EmployeeService;
using CarRentalManagementSystemAPI.Services.BookingService;
using CarRentalManagementSystemAPI.Services.PaymentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);//for automapper

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();



builder.Services.AddDbContext<DataContext>(options =>
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
