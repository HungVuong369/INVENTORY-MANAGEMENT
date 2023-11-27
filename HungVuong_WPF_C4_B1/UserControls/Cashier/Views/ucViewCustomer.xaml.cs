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
    /// Interaction logic for ucViewCustomer.xaml
    /// </summary>
    public partial class ucViewCustomer : UserControl
    {
        private CustomerViewModel _CustomerVM = new CustomerViewModel();

        public ucViewCustomer()
        {
            InitializeComponent();
            dgCustomer.ItemsSource = _CustomerVM.CustomerRepo.Items;
        }
    }
}
