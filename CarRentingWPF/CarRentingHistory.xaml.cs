using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Services.IService;
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
    /// Interaction logic for CarRentingHistory.xaml
    /// </summary>
    public partial class CarRentingHistory : Window
    {
        private int customerId;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        private readonly ICarInformationService _carInformationService;
        private readonly IAccountService _accountService;
        public CarRentingHistory(IAccountService accountService, ICustomerService customerService, IRentingTransService rentingTransService, ICarInformationService carInformationService, int customerId)
        {
            InitializeComponent();
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            _carInformationService = carInformationService;
            _accountService = accountService;
            this.customerId = customerId;
            LoadData(customerId);
            
        }
        private void LoadData(int CustomerId)
        { 
            var rentings = _rentingTransService.GetRentingHistory(CustomerId);
            lvRentingTransaction.ItemsSource = rentings;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage(_accountService, _customerService, _rentingTransService, _carInformationService, customerId);
            homePage.Show();
            this.Close();
        }
    }
}
