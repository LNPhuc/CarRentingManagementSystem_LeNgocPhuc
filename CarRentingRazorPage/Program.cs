using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Respository.Implement;
using Respository.Interface;
using Respository.Respository.Implement;
using Respository.Respository.Interface;
using Services.IService;
using Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
string connString = builder.Configuration.GetConnectionString("FUCarRentingManagementDB");
builder.Services.AddDbContext<FUCarRentingManagementContext>(options => { options.UseSqlServer(connString); });


builder.Services.AddTransient<IUnitofWork, UnitofWork>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICarInformationService, CarInformationService>();
builder.Services.AddTransient<IRentingTransService, RentingTransService>();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICarInformationRepository, CarInformationRepository>();
builder.Services.AddTransient<IRentingTransService, RentingTransService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
