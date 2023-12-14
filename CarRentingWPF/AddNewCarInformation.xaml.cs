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
    /// Interaction logic for AddNewCarInformation.xaml
    /// </summary>
    public partial class AddNewCarInformation : Window
    {
        private readonly IAccountService _accountService;
        private readonly ICarInformationService _carService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        public AddNewCarInformation(IAccountService accountSevice, ICarInformationService carInformationService, ICustomerService customerService, IRentingTransService rentingTransService)
        {
            InitializeComponent();
            _accountService = accountSevice;
            _carService = carInformationService;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CarInformation carInformation = new CarInformation
                {
                    CarDescription = txtCarDescription.Text,
                    CarName = txtCarName.Text,
                    CarRentingPricePerDay = decimal.Parse(txtPricePerDate.Text),
                    FuelType = txtFuelType.Text,
                    CarStatus = 1,
                    ManufacturerId = int.Parse(txtManufactuerID.Text),
                    NumberOfDoors = int.Parse(txtNumberofDoors.Text),
                    SeatingCapacity = int.Parse(txtSeatingCapacity.Text),
                    SupplierId = int.Parse(txtSupplierId.Text),
                    Year = int.Parse(txtYear.Text),
                };
                _carService.AddNewCar(carInformation);
                MessageBox.Show("Add new Successfully!");
                ManageCarInformation man = new ManageCarInformation(_accountService, _carService, _customerService, _rentingTransService);
                man.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Missing feature!");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ManageCarInformation manageCarInformation = new ManageCarInformation(_accountService, _carService, _customerService, _rentingTransService);
            manageCarInformation.Show();
            this.Close();
        }
    }
}
