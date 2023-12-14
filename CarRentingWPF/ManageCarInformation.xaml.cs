using BussinessObject.Entity;
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
    /// Interaction logic for ManageCarInformation.xaml
    /// </summary>
    public partial class ManageCarInformation : Window
    {
        private readonly IAccountService _accountService;
        private readonly ICarInformationService _carService;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        public ManageCarInformation(IAccountService accountSevice, ICarInformationService carInformationService, ICustomerService customerService, IRentingTransService rentingTransService)
        {
            InitializeComponent();
            _accountService = accountSevice;
            _carService = carInformationService;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            Loaddata();
        }
        private void Loaddata()
        {
            var lscar = _carService.GetCarInformation();
            lvMembers.ItemsSource = lscar;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CarInformation carnew = new CarInformation();
            try
            {
                carnew.CarId = int.Parse(txtCarId.Text);
                carnew.CarName = txtCarName.Text;
                carnew.Year = int.Parse(txtYear.Text);
                carnew.NumberOfDoors = int.Parse(txtNumberOfDoor.Text);
                carnew.SeatingCapacity = int.Parse(txtSeattingCapacity.Text);
                carnew.FuelType = txtFuelType.Text;
                var carUpdate = _carService.UpdateCarInformation(carnew);
                if (carUpdate != null)
                {
                    MessageBox.Show("Update Successfully!");
                    Loaddata();
                }
                else MessageBox.Show("Nothing Change!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select item to update!");
            }           
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddNewCarInformation carInformation = new AddNewCarInformation(_accountService, _carService, _customerService, _rentingTransService);
            carInformation.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(_accountService, _carService, _customerService, _rentingTransService);
            adminWindow.Show();
            this.Close();
        }
    }
}
