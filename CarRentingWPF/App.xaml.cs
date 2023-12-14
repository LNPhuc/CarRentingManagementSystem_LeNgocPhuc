using AutoMapper;
using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respository.Implement;
using Respository.Interface;
using Respository.Respository.Implement;
using Respository.Respository.Interface;
using Services.IService;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentingWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
        private void ConfigureServices(IServiceCollection service)
        {
            service.AddDbContext<FUCarRentingManagementContext>(options =>
                options.UseSqlServer("server =(local); database = FUCarRentingManagement;uid=sa;pwd=12345;"));
            service.AddTransient<IAccountService, AccountService>();
            service.AddTransient<ICustomerService, CustomerService>();
            service.AddTransient<IRentingTransService, RentingTransService>();
            service.AddTransient<ICarInformationService, CarInformationService>();

            service.AddTransient<IUnitofWork, UnitofWork>();
            service.AddTransient<IAccountRepository, AccountRepository>();
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<IRentingTransationRepository, RentingTransationRepository>();
            service.AddTransient<ICarInformationRepository, CarInformationRepository>();
            
            service.AddSingleton<AdminWindow>();
            service.AddSingleton<CarInformation>();
            service.AddSingleton<HomePage>();
            service.AddSingleton<MainWindow>();
            service.AddSingleton<ManageCustomer>();
            service.AddSingleton<Profile>();
            service.AddSingleton<RentingCarWindow>();
            
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
