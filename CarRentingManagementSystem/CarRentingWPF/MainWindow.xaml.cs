using BussinessObject.Entity;
using Microsoft.Extensions.Configuration;
using Respository.Respository.Implement;
using Respository.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentingWPF
{

    public partial class MainWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;

        public MainWindow()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetSection("AdminAccount:adminemail").Value;
                var password = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetSection("AdminAccount:adminpassword").Value;
                var customer = _customerRepository.Login(txtEmail.Text, txtPassword.Password);
                if (txtEmail.Text.Equals(email) && txtPassword.Password.Equals(password))
                {
                    errorMessage.Text = "Admin login successfully!";
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }else if (customer != null)
                {
                    MessageBox.Show("Login Thanh cong");
                    HomePage homepage  = new HomePage(customer.CustomerId);
                    homepage.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message);
            }

        }
    }
}
