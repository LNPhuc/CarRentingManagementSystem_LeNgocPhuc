using Infrastructure.Service;
using Infrastructure.Service.IService;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        private int customerId;
        private readonly ICustomerService customerService = new CustomerService();

        public HomePage(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerService.GetCustomerById(customerId);
            Profile profile = new Profile(customerId);
            profile.Show();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
