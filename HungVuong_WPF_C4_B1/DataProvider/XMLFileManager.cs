using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    public class XMLFileManager
    {
        private static XmlDocument doc = new XmlDocument();

        public static XmlNodeList GetReceiptNodesById(string id)
        {
            doc.Load(Path.ReceiptsXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllReceiptById(id));

            doc.Save(Path.ReceiptsXml);

            return nodes;
        }

        public static XmlNodeList GetInvoiceNodesById(string id)
        {
            doc.Load(Path.InvoicesXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllInvoiceById(id));

            doc.Save(Path.InvoicesXml);

            return nodes;
        }

        public static XmlNodeList GetReceiptNodesByDate(string date)
        {
            doc.Load(Path.ReceiptsXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllReceiptByDate(date));

            doc.Save(Path.ReceiptsXml);

            return nodes;
        }

        public static XmlNodeList GetInvoiceNodesByDate(string date)
        {
            doc.Load(Path.InvoicesXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllInvoiceByDate(date));

            doc.Save(Path.InvoicesXml);

            return nodes;
        }

        public static XmlNodeList GetOrderNodesByDate(string date)
        {
            doc.Load(Path.OrdersXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllOrderByDate(date));

            doc.Save(Path.OrdersXml);

            return nodes;
        }

        public static XmlNodeList GetOrderById(string date)
        {
            doc.Load(Path.OrdersXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllOrderById(date));

            doc.Save(Path.OrdersXml);

            return nodes;
        }

        public static void WriteElectronic(RepositoryBase<Electronic> electronic)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement xml = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, xml);

            XmlElement root = doc.CreateElement("Products");
            doc.AppendChild(root);

            electronic.Items.ForEach(item =>
            {
                XmlElement product = doc.CreateElement("Product");
                product.SetAttribute("Id", item.Id);
                product.SetAttribute("Category", item.Category);
                product.SetAttribute("Name", item.Name);
                product.SetAttribute("Producer", item.Producer);
                product.SetAttribute("PriceInput", item.PriceInput.ToString());
                product.SetAttribute("Warranty", item.WarrantyMonths.ToString());
                product.SetAttribute("ElectricPower", item.ElectricPower.ToString());
                root.AppendChild(product);
            });
            doc.Save(Path.ElectronicXml);
        }

        public static void WritePorcelain(RepositoryBase<Porcelain> porcelains)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement xml = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, xml);

            XmlElement root = doc.CreateElement("Products");
            doc.AppendChild(root);

            porcelains.Items.ForEach(item =>
            {
                XmlElement product = doc.CreateElement("Product");
                product.SetAttribute("Id", item.Id);
                product.SetAttribute("Category", item.Category);
                product.SetAttribute("Name", item.Name);
                product.SetAttribute("Producer", item.Producer);
                product.SetAttribute("PriceInput", item.PriceInput.ToString());
                product.SetAttribute("Material", item.Material.ToString());
                root.AppendChild(product);
            });
            doc.Save(Path.PorcelainXml);
        }

        public static void WriteFood(RepositoryBase<Food> foods)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement xml = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, xml);

            XmlElement root = doc.CreateElement("Products");
            doc.AppendChild(root);

            foods.Items.ForEach(item =>
            {
                XmlElement product = doc.CreateElement("Product");
                product.SetAttribute("Id", item.Id);
                product.SetAttribute("Category", item.Category);
                product.SetAttribute("Name", item.Name);
                product.SetAttribute("Producer", item.Producer);
                product.SetAttribute("PriceInput", item.PriceInput.ToString());
                product.SetAttribute("MfgDate", item.MfgDate.ToString("dd/MM/yyyy"));
                product.SetAttribute("ExpDate", item.ExpDate.ToString("dd/MM/yyyy"));
                root.AppendChild(product);
            });
            doc.Save(Path.FoodXml);
        }

        public static void WriteCustomer(List<Customer> customerList)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement xml = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, xml);

            XmlElement root = doc.CreateElement("Customers");
            doc.AppendChild(root);

            customerList.ForEach(item =>
            {
                XmlElement customer = doc.CreateElement("Customer");
                customer.SetAttribute("Name", item.Name.ToUpper());
                customer.SetAttribute("CardID", item.CardID);
                customer.SetAttribute("Phone", item.Phone);
                customer.SetAttribute("Points", item.Points.ToString());
                root.AppendChild(customer);
            });
            doc.Save(Path.CustomerXml);
        }

        public static void WriteRequest(List<dynamic> requestList)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement xml = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, xml);

            XmlElement root = doc.CreateElement("Requests");
            doc.AppendChild(root);

            requestList.ForEach(item =>
            {
                XmlElement request = doc.CreateElement("Request");
                request.SetAttribute("Request", item.Request);
                request.SetAttribute("Reason", item.ReasonTemp);
                request.SetAttribute("CustomerID", item.CustomerID);
                root.AppendChild(request);
            });
            doc.Save(Path.RequestXml);
        }

        public static void AddRequest(string request, string reason, string customerID)
        {
            doc.Load(Path.RequestXml);

            XmlElement newElement1 = doc.CreateElement("Request");
            newElement1.SetAttribute("Request", request);
            newElement1.SetAttribute("Reason", reason);
            newElement1.SetAttribute("CustomerID", customerID);

            XmlElement rootElement = doc.DocumentElement;

            rootElement.AppendChild(newElement1);

            doc.Save(Path.RequestXml);
        }
    }
}
