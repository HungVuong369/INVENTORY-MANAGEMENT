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
    /// Interaction logic for ucCreateInvoice.xaml
    /// </summary>
    public partial class ucCreateInvoice : UserControl
    {
        public delegate void CancelFeatures(object sender, RoutedEventArgs e);
        public event CancelFeatures CancelEvent;
        public ucDetailInvoice DetailInvoice;

        public InvoiceViewModel InvoiceVM { get; set; }
        public AccountDTO AccountDTO { get; set; }

        public ucCreateInvoice(AccountDTO account)
        {
            InitializeComponent();
            this.AccountDTO = account;
            InvoiceVM = new InvoiceViewModel(account);
            
            DetailInvoice = new ucDetailInvoice(InvoiceVM);
            this.DataContext = this;
        }

        private void CancelInvoice_Click(object sender, RoutedEventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }

        private void btnCreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            spCreateInvoice.Visibility = Visibility.Collapsed;
            grdSaveInvoice.Visibility = Visibility.Visible;

            grdCreateInvoice.HorizontalAlignment = HorizontalAlignment.Stretch;

            DetailInvoice.Reset();
            grdSaveInvoice.Children.Add(DetailInvoice);
        }
    }
}
