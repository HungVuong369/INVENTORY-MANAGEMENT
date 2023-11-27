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
    /// Interaction logic for ucSearchInvoiceByDate.xaml
    /// </summary>
    public partial class ucSearchInvoiceByDate : UserControl
    {
        public ucSearchInvoiceByDate()
        {
            InitializeComponent();

            DatePicker.SelectedDate = DateTime.Now;

            btnView_Click(new object(), new RoutedEventArgs());
        }

        private void ReloadDataGrid()
        {
            dgInvoice.Items.Clear();

            DateTime selectedDateTime = DatePicker.SelectedDate ?? default(DateTime);

            XmlNodeList nodes = XMLFileManager.GetInvoiceNodesByDate(selectedDateTime.ToString("dd/MM/yyyy"));

            foreach (XmlNode node in nodes)
            {
                int height = 30;
                List<object> lstProductDetail = new List<object>();
                for (XmlNode node1 = node.FirstChild; node1 != null; node1 = node1.NextSibling)
                {
                    lstProductDetail.Add(new
                    {
                        Id = node.Attributes["Id"].Value,
                        Name = node1.Attributes["Name"].Value,
                        Producer = node1.Attributes["Producer"].Value,
                        PriceInput = double.Parse(node1.Attributes["PriceInput"].Value),
                        PriceOutput = double.Parse(node1.Attributes["PriceOutput"].Value),
                        Quantity = double.Parse(node1.Attributes["Quantity"].Value),
                        Total = double.Parse(node1.Attributes["Total"].Value),
                    });
                    height += 60;
                }

                if (height > 300)
                    height = 300;

                dgInvoice.Items.Add(
                        new
                        {
                            Id = node.Attributes["Id"].Value,
                            Username = node.Attributes["Username"].Value,
                            Quantity = double.Parse(node.Attributes["Quantity"].Value),
                            Total = double.Parse(node.Attributes["Total"].Value),
                            DetailProducts = lstProductDetail,
                            Height = height
                        }
                    );
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }
    }
}
