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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for ConfirmRequest.xaml
    /// </summary>
    public partial class ConfirmRequest : UserControl
    {
        private CustomerViewModel customerVM = new CustomerViewModel();
        private Window _ParentWindow;

        public ConfirmRequest(Window window)
        {
            InitializeComponent();
            this._ParentWindow = window;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _ParentWindow.DialogResult = true;

            customerVM.CustomerRepo.Items.Remove(customerVM.GetCustomerByCardID(this.Tag.ToString()));

            XMLFileManager.WriteCustomer(customerVM.CustomerRepo.Items);

            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
            MessageBox.Show("Hủy thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnInformation_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = customerVM.GetCustomerByCardID(this.Tag.ToString());
            Window window = new Window();
            ucCustomerInformation customerInformation = new ucCustomerInformation(customer);
            customerInformation.Margin = new Thickness(10);
            customerInformation.Padding = new Thickness(10);
            window.Content = customerInformation;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.ShowDialog();
        }
    }
}
