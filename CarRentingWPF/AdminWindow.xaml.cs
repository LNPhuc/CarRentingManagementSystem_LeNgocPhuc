using Infrastructure.IService;
using Infrastructure.Service.IService;
using Services.IService;
using Services.Service;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly IAccountService _accountService;
        private readonly ICarInformationService _carService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        public AdminWindow(IAccountService accountSevice, ICarInformationService carInformationService, ICustomerService customerService, IRentingTransService rentingTransService)
        {
            InitializeComponent();
            _accountService = accountSevice;
            _carService = carInformationService;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
        }

        private void btnCus_Infor(object sender, RoutedEventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer(_accountService,_carService,_customerService, _rentingTransService);
            manageCustomer.Show();
            this.Close();
        }

        private void btnCar_Infor(object sender, RoutedEventArgs e)
        {
            ManageCarInformation car = new ManageCarInformation(_accountService, _carService, _customerService, _rentingTransService);
            car.Show();
            this.Close();
        }

        private void btnRenting_Trans(object sender, RoutedEventArgs e)
        {
            ManageRentingTransition manageRentingTransition = new ManageRentingTransition(_accountService, _carService, _customerService, _rentingTransService);
            manageRentingTransition.Show();
            this.Close();
        }

        private void btnLogout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_accountService, _customerService, _rentingTransService, _carService);
            mainWindow.Show();
            this.Close();
        }
    }
}
