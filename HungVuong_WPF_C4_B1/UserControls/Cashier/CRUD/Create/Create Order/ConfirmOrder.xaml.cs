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
    /// Interaction logic for ConfirmOrder.xaml
    /// </summary>
    public partial class ConfirmOrder : UserControl
    {
        public List<IProduct> Products { get; set; }
        public string DateCreated { get; set; }
        public string OrderID { get; set; }
        public Customer Customer { get; set; }
        public string Username { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        private Window _ParentWindow;

        public ConfirmOrder(Order order, Window parentWindow)
        {
            InitializeComponent();
            this.DateCreated = order.CreatedAt.ToString("dd/MM/yyyy");
            this.OrderID = order.OrderID;
            this.Customer = order.Customer;
            this.Username = order.Username;
            this.Quantity = order.TotalQuantity;
            this.Total = order.TotalPrice;
            this.Products = order.ProductRepo.Items;
            this._ParentWindow = parentWindow;
            DataContext = this;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
        }
    }
}
