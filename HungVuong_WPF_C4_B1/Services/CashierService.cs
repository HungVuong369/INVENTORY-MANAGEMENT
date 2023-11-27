using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    public class CashierService : ICashier
    {
        XmlDocument doc = new XmlDocument();

        public double CalculateProfit()
        {
            return 0;
        }

        public double CalculateRevenue()
        {
            return 0;
        }

        public void CreateOrder(Order order)
        {
            order.ProductRepo = new RepositoryBase<IProduct>();
            order.OrderID = "PBH" + (DataProvider.GetQuantityOrderXml() + 1);
            order.CreatedAt = DateTime.Now;
        }

        public void SaveOrder(Order order)
        {
            doc.Load(Path.OrdersXml);

            XmlNode rootNode = doc.CreateNode(XmlNodeType.Element, "Order", null);

            XmlNode nodeRoot = doc.DocumentElement;

            #region Set Attributes
            var attr1 = doc.CreateAttribute("Id");
            attr1.Value = order.OrderID;

            var attr2 = doc.CreateAttribute("Username");
            attr2.Value = order.Username;

            var attr13 = doc.CreateAttribute("CustomerName");
            attr13.Value = order.Customer.Name;

            var attr14 = doc.CreateAttribute("CustomerPhone");
            attr14.Value = order.Customer.Phone;

            var attr15 = doc.CreateAttribute("CustomerCardID");
            attr15.Value = order.Customer.CardID;

            var attr16 = doc.CreateAttribute("Points");
            if(order.Customer.Name == "Khách")
                attr16.Value = "0";
            else
            {
                CustomerViewModel customerVM = new CustomerViewModel();
                attr16.Value = customerVM.getPoints(order.TotalPrice).ToString();
            }

            var attr3 = doc.CreateAttribute("Quantity");
            attr3.Value = order.TotalQuantity.ToString();

            var attr4 = doc.CreateAttribute("Total");
            attr4.Value = order.TotalPrice.ToString();

            var attr5 = doc.CreateAttribute("Date");
            attr5.Value = order.CreatedAt.ToString("dd/MM/yyyy");
            #endregion

            #region Append Attributes
            rootNode.Attributes.Append(attr1);
            rootNode.Attributes.Append(attr2);
            rootNode.Attributes.Append(attr13);
            rootNode.Attributes.Append(attr14);
            rootNode.Attributes.Append(attr15);
            rootNode.Attributes.Append(attr16);
            rootNode.Attributes.Append(attr3);
            rootNode.Attributes.Append(attr4);
            rootNode.Attributes.Append(attr5);
            #endregion

            nodeRoot.AppendChild(rootNode);

            XmlNode nodeChild = null;

            int index = 1;
            foreach (var orderDetail in order.ProductRepo.Items)
            {
                nodeChild = doc.CreateNode(XmlNodeType.Element, "OrderDetail", null);

                #region Set Attributes
                var attr6 = doc.CreateAttribute("Name");
                attr6.Value = orderDetail.Name;

                var attr7 = doc.CreateAttribute("Producer");
                attr7.Value = orderDetail.Producer;

                var attr8 = doc.CreateAttribute("PriceInput");
                attr8.Value = orderDetail.PriceInput.ToString();

                var attr9 = doc.CreateAttribute("PriceOutput");
                attr9.Value = orderDetail.PriceOutput.ToString();

                var attr10 = doc.CreateAttribute("Quantity");
                attr10.Value = orderDetail.Quantity.ToString();

                var attr11 = doc.CreateAttribute("Total");
                attr11.Value = (orderDetail.PriceOutput * orderDetail.Quantity).ToString();

                var attr12 = doc.CreateAttribute("Id");
                attr12.Value = index++.ToString();

                var attr17 = doc.CreateAttribute("ProductID");
                attr17.Value = orderDetail.Id;
                #endregion

                #region Append Attributes
                nodeChild.Attributes.Append(attr12);
                nodeChild.Attributes.Append(attr17);
                nodeChild.Attributes.Append(attr6);
                nodeChild.Attributes.Append(attr7);
                nodeChild.Attributes.Append(attr8);
                nodeChild.Attributes.Append(attr9);
                nodeChild.Attributes.Append(attr10);
                nodeChild.Attributes.Append(attr11);
                #endregion

                rootNode.AppendChild(nodeChild);
            }
            doc.Save(Path.OrdersXml);
        }

        public List<ProductDTO> GetAvailableProducts()
        {
            return new List<ProductDTO>();
        }

        public CustomerDTO GetCustomerInformation(string customerId)
        {
            return new CustomerDTO();
        }

        public List<InvoiceDTO> GetInvoicesByDate(DateTime date)
        {
            return new List<InvoiceDTO>();
        }

        public List<InvoiceDTO> GetInvoicesByMonthAndYear(int month, int year)
        {
            return new List<InvoiceDTO>();
        }
    }
}
