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
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        public AccountDTO Account { get; set; }

        public CashierWindow(AccountDTO account)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Account = account;
            lbiDetailOrder.Content = "Xem chi tiết\nphiếu bán hàng";
            lbiOrderByDate.Content = "Xem phiếu bán\nhàng theo ngày";
            this.DataContext = this;
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            ucCreateOrder ucCreateOrder = new ucCreateOrder(Account);

            ucCreateOrder.CancelEvent += UcCreateOrder_CancelEvent;
            ucCreateOrder.DetailOrder.SaveOrderEvent += btnCreateOrder_Click;
            bdrContainerFeatures.Child = ucCreateOrder;
        }

        private void UcCreateOrder_CancelEvent(object sender, RoutedEventArgs e)
        {
            bdrContainerFeatures.Child = null;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.ShowLoginForm();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbox = sender as ListBox;

            string content = (lbox.SelectedItem as ListBoxItem).Content.ToString();

            switch (content)
            {
                case "Xem khách hàng":
                    bdrContainerFeatures.Child = new ucViewCustomer();
                    break;
                case "Tạo phiếu bán hàng":
                    btnCreateOrder_Click(sender, e);
                    break;
                case "Xem chi tiết\nphiếu bán hàng":
                    bdrContainerFeatures.Child = new ucViewDetailOrderById();
                    break;
                case "Xem phiếu bán\nhàng theo ngày":
                    bdrContainerFeatures.Child = new ucViewOrder();
                    break;
                case "Liệt kê hàng tồn":
                    bdrContainerFeatures.Child = new ucListingInventory();
                    break;
                case "Liệt kê hết hàng":
                    bdrContainerFeatures.Child = new ucOutOfInvoice();
                    break;
                case "Thống kê":
                    bdrContainerFeatures.Child = new StatisticsOrder();
                    break;
                case "Tạo khách hàng":
                    ucCreateCustomer ucCreateCustomer = new ucCreateCustomer();
                    bdrContainerFeatures.Child = ucCreateCustomer;
                    break;
                case "Xóa khách hàng":
                    bdrContainerFeatures.Child = new ucDeleteCustomer();
                    break;
            }
        }
    }
}
