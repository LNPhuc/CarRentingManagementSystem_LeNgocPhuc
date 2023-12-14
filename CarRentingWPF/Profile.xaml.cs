using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service;
using Infrastructure.Service.IService;
using Infrastructure.UnitOfWork;
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
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        private readonly ICarInformationService _carInformationService;
        private readonly IAccountService _accountService;
        private int cusId;
        public Profile(IAccountService accountService,ICustomerService customerService,IRentingTransService rentingTransService, ICarInformationService carInformationService, int customerId)
        {
            InitializeComponent();
            _accountService = accountService;
            _customerService = customerService;
            _rentingTransService = rentingTransService;
            _carInformationService = carInformationService;
            cusId = customerId;

        }
        private void ProfileWindow_Load(object sender, RoutedEventArgs e) => LoadCustomer();
        private void LoadCustomer()
        {
            var customer = _customerService.GetCustomerById(cusId);
            txtId.Text = customer.CustomerId.ToString();
            txtEmail.Text = customer.Email.ToString();
            txtName.Text = customer.CustomerName.ToString();
            txtPassword.Text = customer.Password.ToString();
            txtBirthday.Text = customer.CustomerBirthday.ToString();
            txtTelephone.Text = customer.Telephone.ToString();
            txtCustomerStatus.Text = customer.CustomerStatus.ToString();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer cusnew = new Customer();
            cusnew.CustomerId = int.Parse(txtId.Text);
            cusnew.CustomerName = txtName.Text;
            cusnew.Email = txtEmail.Text;
            cusnew.Telephone = txtTelephone.Text;
            cusnew.Password = txtPassword.Text;
            cusnew.CustomerBirthday = DateTime.Parse(txtBirthday.Text);
            cusnew.CustomerStatus = byte.Parse(txtCustomerStatus.Text);
            var cusUpdate = _customerService.UpdateProfile(cusnew);
            if (cusUpdate != null) MessageBox.Show("Update Successfully!");
            else MessageBox.Show("Nothing Change!");
            LoadCustomer();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage(_accountService,_customerService,_rentingTransService,_carInformationService,cusId);
            homePage.Show();
            this.Close();
        }
    }
}
