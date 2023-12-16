using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Infrastructure.UnitOfWork;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace CarRentingWPF
{
    /// <summary>
    /// Interaction logic for ManageCustomer.xaml
    /// </summary>
    public partial class ManageCustomer : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        private readonly ICarInformationService _carService;
        private readonly IRentingTransService _rentingTransService;
        public ManageCustomer(IAccountService accountService, ICarInformationService carInformationService,ICustomerService customerService, IRentingTransService rentingTransService)
        {
            InitializeComponent();
            _customerService = customerService;
            _accountService = accountService;
            _carService = carInformationService;
            _rentingTransService = rentingTransService;
            Loaddata();
        }
        private void Loaddata()
        {
            var lscustomer = _customerService.GetCustomer();
            lvMembers.ItemsSource = null;
            lvMembers.ItemsSource = lscustomer;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Loaddata();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer cusnew = new Customer();
            try
            {
                cusnew.CustomerId = int.Parse(txtCustomerId.Text);
                cusnew.CustomerName = txtCustomerName.Text;
                cusnew.Email = txtEmail.Text;
                cusnew.Telephone = txtTelephone.Text;
                cusnew.Password = txtPassword.Text;
                cusnew.CustomerBirthday = DateTime.Parse(txtBirthday.Text);
                cusnew.CustomerStatus = byte.Parse(txtStatus.Text);
                _customerService.UpdateProfile(cusnew.CustomerId, cusnew);
                MessageBox.Show("Update Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select item to update!");
            }
            Loaddata();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Customer cusnew = new Customer();
            try
            {
                cusnew.CustomerId = int.Parse(txtCustomerId.Text);
                cusnew.CustomerName = txtCustomerName.Text;
                cusnew.Email = txtEmail.Text;
                cusnew.Telephone = txtTelephone.Text;
                cusnew.Password = txtPassword.Text;
                cusnew.CustomerBirthday = DateTime.Parse(txtBirthday.Text);
                cusnew.CustomerStatus = byte.Parse(txtStatus.Text);
                if (cusnew.CustomerStatus != 0)
                {
                    _customerService.DeleteCustomer(cusnew.CustomerId);
                    MessageBox.Show("Delete Successfully!");
                }
                else MessageBox.Show("This account is already deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select item to update!");
            }
            Loaddata();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(_accountService,_carService, _customerService, _rentingTransService);
            adminWindow.Show();
            this.Close();
        }
    }
}
