using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Microsoft.Extensions.Configuration;
using Respository.Respository.Implement;
using Respository.Respository.Interface;
using Services.IService;
using System;
using System.Windows;


namespace CarRentingWPF
{

    public partial class MainWindow : Window
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        private readonly ICarInformationService _carInformationService;
        public MainWindow(IAccountService accountService, ICustomerService customerService, IRentingTransService rentingTransService,
            ICarInformationService carInformationService)
        {
            InitializeComponent();
            _accountService = accountService;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            _carInformationService = carInformationService;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetSection("AdminAccount:adminemail").Value;
                var password = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetSection("AdminAccount:adminpassword").Value;
                
                if (txtEmail.Text.Equals(email) && txtPassword.Password.Equals(password))
                {
                    errorMessage.Text = "Admin login successfully!";
                    AdminWindow adminWindow = new AdminWindow(_accountService, _carInformationService, _customerService,_rentingTransService);
                    adminWindow.Show();
                    this.Close();
                }else 
                {
                    var customer = _accountService.Login(txtEmail.Text, txtPassword.Password);
                    if (customer != null && customer.CustomerStatus == 1)
                    {                    
                        HomePage homepage = new HomePage(_accountService,_customerService,_rentingTransService,_carInformationService, customer.CustomerId);
                        homepage.Show();
                        this.Close();
                    }
                    else
                    {
                        errorMessage.Text = "You are not allowed to login!";
                    }   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message);
            }

        }
    }
}
