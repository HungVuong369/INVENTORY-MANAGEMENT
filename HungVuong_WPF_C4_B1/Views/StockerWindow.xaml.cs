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

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for StockerWindow.xaml
    /// </summary>
    public partial class StockerWindow : Window
    {
        private AccountDTO _AccountDTO;

        public AccountDTO Account
        {
            get { return _AccountDTO; }
        }

        public StockerWindow(AccountDTO accountDTO)
        {
            InitializeComponent();
            this._AccountDTO = accountDTO;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.WindowState = WindowState.Maximized;
            lbiDetailReceipt.Content = "Tìm chi tiết\nphiếu nhập kho";
            lbiDetailInvoice.Content = "Tìm chi tiết\nphiếu xuất kho";

            this.DataContext = this;
        }

        private void btnCreateReceipt_Click(object sender, RoutedEventArgs e)
        {
            ucCreateReceipt ucCreateReceipt = new ucCreateReceipt(_AccountDTO);

            ucCreateReceipt.CancelEvent += UcCreateReceipt_CancelEvent;
            ucCreateReceipt.DetailReceipt.SaveReceiptEvent += btnCreateReceipt_Click;
            bdrContainerFeatures.Child = ucCreateReceipt;
        }

        private void UcCreateReceipt_CancelEvent(object sender, RoutedEventArgs e)
        {
            bdrContainerFeatures.Child = null;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.ShowLoginForm();
            this.Close();
        }

        private void btnCreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            ucCreateInvoice ucCreateInvoice = new ucCreateInvoice(_AccountDTO);

            ucCreateInvoice.CancelEvent += UcCreateReceipt_CancelEvent;
            ucCreateInvoice.DetailInvoice.SaveInvoiceEvent += btnCreateInvoice_Click;
            bdrContainerFeatures.Child = ucCreateInvoice;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbox = sender as ListBox;

            string content = (lbox.SelectedItem as ListBoxItem).Content.ToString();

            switch (content)
            {
                case "Xem sản phẩm":
                    bdrContainerFeatures.Child = new ViewProduct();
                    break;
                case "Tạo phiếu nhập kho":
                    btnCreateReceipt_Click(sender, e);
                    break;

                case "Tìm phiếu nhập kho":
                    bdrContainerFeatures.Child = new ucSearchReceiptByDate();
                    break;

                case "Tìm chi tiết\nphiếu nhập kho":
                    bdrContainerFeatures.Child = new ucViewDetailReceipt(_AccountDTO);
                    break;
                case "Tạo phiếu xuất kho":
                    btnCreateInvoice_Click(sender, e);
                    break;

                case "Tìm phiếu xuất kho":
                    bdrContainerFeatures.Child = new ucSearchInvoiceByDate();
                    break;

                case "Tìm chi tiết\nphiếu xuất kho":
                    ucViewDetailInvoice ucViewDetailInvoice = new ucViewDetailInvoice();

                    bdrContainerFeatures.Child = ucViewDetailInvoice;
                    break;
                case "Xem kho":
                    ucViewInventory ucViewInventory = new ucViewInventory();

                    bdrContainerFeatures.Child = ucViewInventory;
                    break;
                case "Liệt kê hết hạn":
                    ucViewProductEpired ucViewProductExpired = new ucViewProductEpired();

                    bdrContainerFeatures.Child = ucViewProductExpired;
                    break;
            }
        }
    }
}
