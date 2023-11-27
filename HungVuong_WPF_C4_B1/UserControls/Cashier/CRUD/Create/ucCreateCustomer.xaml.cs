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
    /// Interaction logic for ucCreateCustomer.xaml
    /// </summary>
    public partial class ucCreateCustomer : UserControl
    {
        private CustomerViewModel _CustomerVM = new CustomerViewModel();

        public ucCreateCustomer()
        {
            InitializeComponent();
            Loaded += Uccreatecustomer_Loaded;
        }

        private void Uccreatecustomer_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }

        private void ResetTextBox()
        {
            txtCardID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        private void FocusTextBox()
        {
            if (txtName.Text == string.Empty)
                txtName.Focus();
            else if (txtPhone.Text == string.Empty)
                txtPhone.Focus();
            else
                txtCardID.Focus();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if(txtCardID.Text == string.Empty || txtName.Text == string.Empty || txtPhone.Text == string.Empty)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusTextBox();
                return;
            }
            if (!_CustomerVM.isExistCardID(txtCardID.Text))
            {
                Customer customer = new Customer(txtName.Text, txtPhone.Text, 0, txtCardID.Text);
                _CustomerVM.CustomerRepo.Items.Add(customer);
                XMLFileManager.WriteCustomer(_CustomerVM.CustomerRepo.Items);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetTextBox();
                FocusTextBox();
            }
            else
            {
                MessageBox.Show("Mã thẻ đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtCardID.Focus();
            }
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}
