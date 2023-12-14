using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Respository.Respository.Implement;
using Respository.Respository.Interface;
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
    public partial class HomePage : Window
    {
        private int customerId;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        private readonly ICarInformationService _carInformationService;
        private readonly IAccountService _accountService;
        public HomePage(IAccountService accountService,ICustomerService customerService, IRentingTransService rentingTransService,ICarInformationService carInformationService, int customerId)
        {
            InitializeComponent();
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            _carInformationService = carInformationService;
            _accountService = accountService;
            this.customerId = customerId;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(_accountService,_customerService, _rentingTransService,_carInformationService,customerId);
            profile.Show();
            this.Close();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            CarRentingHistory carRentingHistory = new CarRentingHistory(_accountService, _customerService, _rentingTransService, _carInformationService, customerId);
            carRentingHistory.Show();
            this.Close();
        }

        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            RentingCarWindow rentingCarWindow = new RentingCarWindow(_accountService,_carInformationService,_customerService, _rentingTransService,customerId);
            rentingCarWindow.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_accountService,_customerService,_rentingTransService,_carInformationService);
            mainWindow.Show();
            this.Close();
        }
    }
}
