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
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnCus_Infor(object sender, RoutedEventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer();
            manageCustomer.Show();
            this.Close();
        }

        private void btnCar_Infor(object sender, RoutedEventArgs e)
        {
            CarInformation car = new CarInformation();
            car.Show();
            this.Close();
        }

        private void btnRenting_Trans(object sender, RoutedEventArgs e)
        {

        }

        private void btnReport(object sender, RoutedEventArgs e)
        {

        }
    }
}
