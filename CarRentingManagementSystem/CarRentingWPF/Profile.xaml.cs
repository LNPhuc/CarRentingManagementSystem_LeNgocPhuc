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
using System.Windows.Shapes;

namespace CarRentingWPF
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private readonly ICustomerRepository customerRepository = new CustomerRepository();
        private int CustomerId;
        public Profile(int customerId)
        {
            InitializeComponent();
            CustomerId = customerId;
        }
        private void ProfileWindow_Load(object sender, RoutedEventArgs e) => LoadCustomer();
        private void LoadCustomer()
        {
            var customer = customerRepository.GetById(CustomerId);
            txtId.Text = customer.CustomerId.ToString();
            txtEmail.Text = customer.Email.ToString();
            txtName.Text = customer.CustomerName.ToString();
            txtPassword.Text = customer.Password.ToString();
            txtBirthday.Text = customer.CustomerBirthday.ToString();
            txtTelephone.Text = customer.Telephone.ToString();
            txtCustomerStatus.Text = customer.CustomerStatus.ToString();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            this.LoadCustomer();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
