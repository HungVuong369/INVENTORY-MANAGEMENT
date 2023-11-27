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
    /// Interaction logic for ucViewCardID.xaml
    /// </summary>
    public partial class ucViewCardID : UserControl
    {
        private CustomerViewModel _CustomerVM;

        public delegate void NextHandle(object sender, RoutedEventArgs e);
        public event NextHandle NextEvent;

        public ucViewCardID()
        {
            InitializeComponent();

            this._CustomerVM = new CustomerViewModel();
            Loaded += Uccreatecustomer_Loaded;
        }

        private void Uccreatecustomer_Loaded(object sender, RoutedEventArgs e)
        {
            txtCardID.Focus();
        }

        private void btnNone_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer("Khách", "Không", 0, "Không");
            NextEvent?.Invoke(customer, e);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (_CustomerVM.isExistCardID(txtCardID.Text))
            {
                Customer customer = _CustomerVM.GetCustomerByCardID(txtCardID.Text.ToUpper());
                NextEvent?.Invoke(customer, e);
            }
            else
            {
                MessageBox.Show("Mã thẻ không tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
