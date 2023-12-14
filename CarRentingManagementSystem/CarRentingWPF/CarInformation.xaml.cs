using Infrastructure.Service;
using Infrastructure.Service.IService;
using System.Windows;


namespace CarRentingWPF
{
    /// <summary>
    /// Interaction logic for CarInformation.xaml
    /// </summary>
    public partial class CarInformation : Window
    {
        private readonly IAdminService _adminService;
        public CarInformation()
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
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}
