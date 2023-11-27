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
    /// Interaction logic for StatisticsOrder.xaml
    /// </summary>
    public partial class StatisticsOrder : UserControl
    {
        public StatisticsOrder()
        {
            InitializeComponent();
            SetData();
        }

        private List<string> GetLstIDForTheDay()
        {
            XmlNodeList nodes = XMLFileManager.GetOrderNodesByDate(DateTime.Now.ToString("dd/MM/yyyy"));
            List<string> lstID = new List<string>();

            foreach (XmlNode node in nodes)
            {
                for (XmlNode node1 = node.FirstChild; node1 != null; node1 = node1.NextSibling)
                {
                    if (!lstID.Contains(node1.Attributes["ProductID"].Value))
                    {
                        lstID.Add(node1.Attributes["ProductID"].Value);
                    }
                }
            }
            return lstID;
        }

        private void SetData()
        {
            List<string> lstID = GetLstIDForTheDay();

            XmlDocument doc = new XmlDocument();

            doc.Load(Path.OrdersXml);

            int index = 1;
            lstID.ForEach(item =>
            {
                XmlNodeList nodes = doc.SelectNodes(Path.AllOrderDetailByDateAndId(DateTime.Now.ToString("dd/MM/yyyy"), item));

                double revenue = 0;
                double priceInput = 0;
                int quantity = 0;
                XmlNode nodeLast = null;
                foreach (XmlNode node in nodes)
                {
                    revenue += double.Parse(node.Attributes["Quantity"].Value) * double.Parse(node.Attributes["PriceOutput"].Value);
                    priceInput += double.Parse(node.Attributes["Quantity"].Value) * double.Parse(node.Attributes["PriceInput"].Value);
                    quantity += int.Parse(node.Attributes["Quantity"].Value);
                    nodeLast = node;
                }

                double profit = revenue - priceInput;

                dgOrder.Items.Add(new {
                    Index = index++,
                    Id = item,
                    Name = nodeLast.Attributes["Name"].Value,
                    Producer = nodeLast.Attributes["Producer"].Value,
                    Quantity = quantity,
                    Revenue = revenue,
                    Profit = profit
                });
            });

            doc.Save(Path.OrdersXml);
        }
    }
}
