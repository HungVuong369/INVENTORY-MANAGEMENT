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
    /// Interaction logic for ucCreateOrder.xaml
    /// </summary>
    public partial class ucCreateOrder : UserControl
    {
        public delegate void CancelFeatures(object sender, RoutedEventArgs e);
        public event CancelFeatures CancelEvent;
        public ucDetailOrder DetailOrder;

        private Window window;

        public OrderViewModel OrderVM { get; set; }

        public ucCreateOrder(AccountDTO account)
        {
            InitializeComponent();

            OrderVM = new OrderViewModel(account);
            DetailOrder = new ucDetailOrder(OrderVM);

            this.DataContext = this;
        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            window = new Window();
            ucViewCardID viewCardID = new ucViewCardID();

            viewCardID.NextEvent += ViewCardID_NextEvent;

            window.Content = viewCardID;

            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            window.Height = 200;

            window.Width = 330;

            window.ShowDialog();
        }

        private void ViewCardID_NextEvent(object sender, RoutedEventArgs e)
        {
            window.Close();

            spCreateOrder.Visibility = Visibility.Collapsed;
            grdSaveOrder.Visibility = Visibility.Visible;

            spCreateOrder.HorizontalAlignment = HorizontalAlignment.Stretch;

            DetailOrder.Reset();

            Customer customer = sender as Customer;
            OrderVM.Order.Customer.Name = customer.Name;
            OrderVM.Order.Customer.Phone = customer.Phone;
            OrderVM.Order.Customer.Points = customer.Points;
            OrderVM.Order.Customer.CardID = customer.CardID;

            grdSaveOrder.Children.Add(DetailOrder);
        }
    }
}
