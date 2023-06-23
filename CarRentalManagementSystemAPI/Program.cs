global using CarRentalManagementSystemAPI.Models;
global using CarRentalManagementSystemAPI.ViewModels;
global using CarRentalManagementSystemAPI.Data;
using CarRentalManagementSystemAPI.Services.CarService;
using CarRentalManagementSystemAPI.Services.CustomerService;
using CarRentalManagementSystemAPI.Services.DriverService;
using CarRentalManagementSystemAPI.Services.EmployeeService;
using CarRentalManagementSystemAPI.Services.BookingService;
using CarRentalManagementSystemAPI.Services.PaymentService;
using CarRentalManagementSystemAPI.Services.AuthenticationService;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Clear all the inbuild providers
builder.Logging.ClearProviders();

//For adding the log4net into our api and this will log both built-in log and log4net 
builder.Logging.AddLog4Net();

//use this to override built-in logger
//builder.Host.UseLog4Net();//erreor

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
builder.Services.AddScoped<IUserAuthService, UserAuthService>();



builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", b =>
    {
        b.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
