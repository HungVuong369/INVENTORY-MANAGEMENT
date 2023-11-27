using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window, INotifyPropertyChanged
    {
        public AccountDTO Account { get; set; }

        public int QuantityRequest { get; set; } = DataProvider.GetQuantityRequest();

        public AdminWindow(AccountDTO account)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Account = account;
            lbiDetailReceipt.Content = "Tìm chi tiết\nphiếu nhập kho";
            lbiDetailInvoice.Content = "Tìm chi tiết\nphiếu xuất kho";
            lbiDetailOrder.Content = "Tìm chi tiết\nphiếu bán hàng";
            this.DataContext = this;
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
                case "Báo cáo":
                    bdrContainerFeatures.Child = new ucReport();
                    break;
                case "Xem khách hàng":
                    bdrContainerFeatures.Child = new ucViewCustomer();
                    break;
                case "Tìm chi tiết\nphiếu bán hàng":
                    bdrContainerFeatures.Child = new ucViewDetailOrderById();
                    break;
                case "Tìm phiếu bán hàng":
                    bdrContainerFeatures.Child = new ucViewOrder();
                    break;
                case "Liệt kê hết hàng":
                    bdrContainerFeatures.Child = new ucOutOfInvoice();
                    break;
                case "Thống kê":
                    bdrContainerFeatures.Child = new StatisticsOrder();
                    break;
                case "Xem sản phẩm":
                    bdrContainerFeatures.Child = new ViewProduct();
                    break;
                case "Cập nhật giá":
                    bdrContainerFeatures.Child = new ucUpdatePrice();
                    break;
                case "Tìm chi tiết\nphiếu nhập kho":
                    bdrContainerFeatures.Child = new ucViewDetailReceipt(Account);
                    break;
                case "Tìm phiếu nhập kho":
                    bdrContainerFeatures.Child = new ucSearchReceiptByDate();
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

        private void btnBadge_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            ucListRequest ucListRequest = new ucListRequest();
            ucListRequest.buttonClick += UcListRequest_buttonClick;
            window.Content = ucListRequest;

            window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void UcListRequest_buttonClick()
        {
            QuantityRequest = DataProvider.GetQuantityRequest();
            OnPropertyChanged("QuantityRequest");
        }
    }
}
