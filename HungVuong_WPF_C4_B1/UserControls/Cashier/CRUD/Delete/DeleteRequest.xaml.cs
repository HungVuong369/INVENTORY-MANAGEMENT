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
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for DeleteRequest.xaml
    /// </summary>
    public partial class DeleteRequest : UserControl
    {
        private CustomerViewModel customerVM = new CustomerViewModel();
        private Window parentWindow;
        public DeleteRequest(Window window)
        {
            parentWindow = window;
            InitializeComponent();
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.DialogResult = false;
            parentWindow.Close();
        }

        private void ResetTextBox()
        {
            txtReason.Text = "";
            txtRequest.Text = "";
        }

        private void FocusTextBox()
        {
            if (txtRequest.Text == string.Empty)
                txtRequest.Focus();
            else if (txtReason.Text == string.Empty)
                txtReason.Focus();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if(txtReason.Text == string.Empty || txtRequest.Text == string.Empty)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusTextBox();
                return;
            }

            XMLFileManager.AddRequest(txtRequest.Text, txtReason.Text, this.Tag.ToString());

            MessageBox.Show("Gửi yêu cầu đến admin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            this.parentWindow.DialogResult = true;

            parentWindow.Close();
        }
    }
}
