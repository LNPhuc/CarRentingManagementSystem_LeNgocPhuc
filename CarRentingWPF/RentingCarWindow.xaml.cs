using Infrastructure.IService;
using Infrastructure.Service;
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
    /// Interaction logic for RentingCarWindow.xaml
    /// </summary>
    public partial class RentingCarWindow : Window
    {
        private int _customerId;
        private readonly ICarInformationService _carInformationService;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        public RentingCarWindow(IAccountService accountSevice, ICarInformationService carInformationService, ICustomerService customerService, IRentingTransService rentingTransService, int customerId)
        {
            InitializeComponent();
            _carInformationService = carInformationService;
            _accountService = accountSevice;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            this._customerId = customerId;
            Loaddata();
        }
        private void Loaddata()
        {
            var lscar = _carInformationService.GetCarInformation();
            lvMembers.ItemsSource = lscar;
        }
        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            if(txtCarId.Text == string.Empty)
            {
                MessageBox.Show("Please select car to rent!");
            }
            else
            {
                int carid = int.Parse(txtCarId.Text);
                RentingDetailWindow rentingDetailWindow = new RentingDetailWindow(_accountService, _carInformationService, _customerService, _rentingTransService, _customerId, carid);
                rentingDetailWindow.Show();
                this.Close();
            }           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage(_accountService, _customerService, _rentingTransService, _carInformationService,_customerId);
            homePage.Show();
            this.Close();
        }
    }
}
