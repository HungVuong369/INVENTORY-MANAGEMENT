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
    /// Interaction logic for ucViewDetailOrderById.xaml
    /// </summary>
    public partial class ucViewDetailOrderById : UserControl
    {
        public ucViewDetailOrderById()
        {
            InitializeComponent();
        }

        private void ReloadDataGrid()
        {
            dgOrder.Items.Clear();

            XmlNodeList nodes = XMLFileManager.GetOrderById(txtInput.Text.ToUpper());

            int index = 1;
            foreach (XmlNode node in nodes)
            {
                for (XmlNode node1 = node.FirstChild; node1 != null; node1 = node1.NextSibling)
                {
                    dgOrder.Items.Add(new
                    {
                        Index = index++,
                        Username = node.Attributes["Username"].Value,
                        Id = node.Attributes["Id"].Value,
                        Name = node1.Attributes["Name"].Value,
                        Producer = node1.Attributes["Producer"].Value,
                        PriceInput = double.Parse(node1.Attributes["PriceInput"].Value),
                        PriceOutput = double.Parse(node1.Attributes["PriceOutput"].Value),
                        Quantity = node1.Attributes["Quantity"].Value,
                        Total = double.Parse(node1.Attributes["Total"].Value),
                        CreatedAt = node.Attributes["Date"].Value
                    });
                }
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtInput.Focus();
        }

        private void txtInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(e.Text[0] == '\r')
                ReloadDataGrid();
        }
    }
}
