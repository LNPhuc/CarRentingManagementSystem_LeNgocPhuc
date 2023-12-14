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
    /// Interaction logic for ManageRentingTransition.xaml
    /// </summary>
    public partial class ManageRentingTransition : Window
    {
        private readonly IAccountService _accountService;
        private readonly ICarInformationService _carService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        public ManageRentingTransition(IAccountService accountService, ICarInformationService carService, ICustomerService customerService, IRentingTransService rentingTransService)
        {
            InitializeComponent();
            _accountService = accountService;
            _carService = carService;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            Loaddata();
        }
        private void Loaddata()
        {
            var lsTrans = _rentingTransService.GetAllRentingTransaction();
            lvRenting.ItemsSource = lsTrans;
            var lsDetail = _rentingTransService.GetAllRentingDetail();
            lvRentingDetail.ItemsSource = lsDetail;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(_accountService,_carService,_customerService,_rentingTransService);
            adminWindow.Show();
            this.Close();
        }
    }
}
