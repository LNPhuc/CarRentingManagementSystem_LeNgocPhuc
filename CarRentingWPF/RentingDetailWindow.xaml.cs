using Infrastructure.IService;
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
    /// Interaction logic for RentingDetailWindow.xaml
    /// </summary>
    public partial class RentingDetailWindow : Window
    {
        private int _customerId;
        private readonly ICarInformationService _carInformationService;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        private int carRentingId;
        public RentingDetailWindow(IAccountService accountSevice, ICarInformationService carInformationService, ICustomerService customerService, IRentingTransService rentingTransService, int customerId, int carId)
        {
            InitializeComponent();
            _carInformationService = carInformationService;
            _customerService = customerService;
            _accountService = accountSevice;
            _rentingTransService = rentingTransService;
            _customerId = customerId;
            carRentingId = carId;
            LoadData();
        }
        private void LoadData()
        {
            var carInfo = _carInformationService.GetCarInformationByCarId(carRentingId);
            txtCarId.Text = carInfo.CarId.ToString();
            txtCarName.Text = carInfo.CarName.ToString();
            txtNumberofDoors.Text = carInfo.NumberOfDoors.ToString();
            txtCarStatus.Text = carInfo.CarStatus.ToString();
            txtSeatingCapacity.Text = carInfo.SeatingCapacity.ToString();
            txtFuelType.Text = carInfo.FuelType.ToString();
            txtYear.Text = carInfo.Year.ToString();
            txtPricePerDate.Text = carInfo.CarRentingPricePerDay.ToString();
            txtManufacturer.Text = carInfo.Manufacturer.ManufacturerName.ToString();
            txtSupplierName.Text = carInfo.Supplier.SupplierName.ToString();
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            RentingCarWindow rentingCarWindow = new RentingCarWindow(_accountService,_carInformationService,_customerService,_rentingTransService,_customerId);
            rentingCarWindow.Show();
            this.Close();
        }
    }
}
