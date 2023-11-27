using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ucCreateReceipt.xaml
    /// </summary>
    public partial class ucCreateReceipt : UserControl
    {
        public delegate void CancelFeatures(object sender, RoutedEventArgs e);
        public event CancelFeatures CancelEvent;
        public ucDetailReceipt DetailReceipt;

        public AccountDTO AccountDTO { get; set; }
        public ReceiptViewModel ReceiptVM { get; set; }

        public ucCreateReceipt(AccountDTO accountDTO)
        {
            InitializeComponent();

            ReceiptVM = new ReceiptViewModel(accountDTO);

            DetailReceipt = new ucDetailReceipt(ReceiptVM);

            this.AccountDTO = accountDTO;

            this.DataContext = this;
        }

        public void CancelReceipt_Click(object sender, RoutedEventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }

        private void btnCreateReceipt_Click(object sender, RoutedEventArgs e)
        {
            spCreateReceipt.Visibility = Visibility.Collapsed;
            grdSaveReceipt.Visibility = Visibility.Visible;

            grdCreateReceipt.HorizontalAlignment = HorizontalAlignment.Stretch;

            DetailReceipt.Reset();
            grdSaveReceipt.Children.Add(DetailReceipt);
        }
    }
}