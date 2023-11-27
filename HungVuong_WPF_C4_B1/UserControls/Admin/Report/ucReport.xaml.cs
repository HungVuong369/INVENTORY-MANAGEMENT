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
    /// Interaction logic for ucReport.xaml
    /// </summary>
    public partial class ucReport : UserControl
    {
        private ProductViewModel _ProductVM = new ProductViewModel();

        public int QuantityEmployees { get; set; }
        public int QuantityProducts { get; set; }
        public int QuantityReceipts { get; set; }
        public int QuantityInvoices { get; set; }
        public int QuantityOrders { get; set; }

        public ucReport()
        {
            InitializeComponent();

            QuantityEmployees = GlobalData.QuantityEmployees;
            QuantityProducts = _ProductVM.productRepo.Items.Count;
            QuantityReceipts = DataProvider.GetQuantityReceiptXml();
            QuantityInvoices = DataProvider.GetQuantityInvoiceXml();
            QuantityOrders = DataProvider.GetQuantityOrderXml();

            DataContext = this;
        }
    }
}
