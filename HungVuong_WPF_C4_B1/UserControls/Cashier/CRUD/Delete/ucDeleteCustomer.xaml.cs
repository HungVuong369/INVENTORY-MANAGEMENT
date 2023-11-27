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
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for ucDeleteCustomer.xaml
    /// </summary>
    public partial class ucDeleteCustomer : UserControl
    {
        public int number { get; set; }
        private CustomerViewModel _CustomerVM = new CustomerViewModel();

        public ucDeleteCustomer()
        {
            InitializeComponent();
            dgCustomer.ItemsSource = _CustomerVM.CustomerRepo.Items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            DeleteRequest deleteRequest = new DeleteRequest(window);
            deleteRequest.Tag = (sender as Button).Tag;
            window.Content = deleteRequest;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();

            if(window.DialogResult == true)
            {
                UpdateButtonDelete(sender as Button);
            }
        }

        private void UpdateButtonDelete(Button button)
        {
            button.Background = Brushes.Blue;
            button.IsEnabled = false;
            button.Content = "Đang chờ duyệt";
        }

        private void btnDelete_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);

            string cardID = button.Tag.ToString();

            XmlDocument doc = new XmlDocument();

            doc.Load(Path.RequestXml);

            XmlNode node = doc.SelectSingleNode(Path.GetNodeRequestByID(cardID));

            doc.Save(Path.RequestXml);

            if(node != null)
            {
                UpdateButtonDelete(button);
            }
        }
    }
}
