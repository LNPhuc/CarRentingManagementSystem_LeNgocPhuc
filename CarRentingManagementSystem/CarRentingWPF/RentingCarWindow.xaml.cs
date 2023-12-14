using Infrastructure.Service;
using Infrastructure.Service.IService;
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
        private readonly IAdminService _adminService;
        public RentingCarWindow()
        {
            InitializeComponent();
            _adminService = new AdminService();
            Loaddata();
        }
        private void Loaddata()
        {
            var lscar = _adminService.GetCarInformation();
            lvMembers.ItemsSource = lscar;
        }
        private void btnRent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
