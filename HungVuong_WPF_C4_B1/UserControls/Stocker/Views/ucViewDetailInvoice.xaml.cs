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
    /// Interaction logic for ucViewDetailInvoice.xaml
    /// </summary>
    public partial class ucViewDetailInvoice : UserControl
    {
        public ucViewDetailInvoice()
        {
            InitializeComponent();
        }

        private void ReloadDataGrid()
        {
            dgDetailInvoice.Items.Clear();

            XmlNodeList nodes = null;
            if (cbFeature.SelectedIndex == 0)
            {
                nodes = XMLFileManager.GetInvoiceNodesById(txtInput.Text.ToUpper());
            }
            else if (cbFeature.SelectedIndex == 1)
            {
                DateTime selectedDateTime = DatePicker.SelectedDate ?? default(DateTime);
                nodes = XMLFileManager.GetInvoiceNodesByDate(selectedDateTime.ToString("dd/MM/yyyy"));
            }

            int index = 1;
            foreach (XmlNode node in nodes)
            {
                for (XmlNode node1 = node.FirstChild; node1 != null; node1 = node1.NextSibling)
                {
                    dgDetailInvoice.Items.Add(new
                    {
                        Index = index++,
                        Username = node.Attributes["Username"].Value,
                        Id = node.Attributes["Id"].Value,
                        Name = node1.Attributes["Name"].Value,
                        Producer = node1.Attributes["Producer"].Value,
                        PriceInput = node1.Attributes["PriceInput"].Value,
                        PriceOutput = node1.Attributes["PriceOutput"].Value,
                        Quantity = node1.Attributes["Quantity"].Value,
                        Total = node1.Attributes["Total"].Value,
                        CreatedAt = node.Attributes["Date"].Value
                    });
                }
            }
        }

        private void cbFeature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtInput == null || DatePicker == null)
                return;

            dgDetailInvoice.Items.Clear();
            txtInput.Text = DatePicker.Text = "";

            if (cbFeature.SelectedIndex == 0)
            {
                txtInput.Visibility = Visibility.Visible;
                DatePicker.Visibility = Visibility.Collapsed;
            }
            else if (cbFeature.SelectedIndex == 1)
            {
                txtInput.Visibility = Visibility.Collapsed;
                DatePicker.Visibility = Visibility.Visible;
                DatePicker.SelectedDate = DateTime.Now;
                ReloadDataGrid();
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }
    }
}
