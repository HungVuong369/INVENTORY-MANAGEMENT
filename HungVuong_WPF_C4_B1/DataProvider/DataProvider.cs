using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    class DataProvider
    {
        private static XmlDocument doc = new XmlDocument();

        // Account
        public static List<Account> getListAccount(bool isHaveAdmin)
        {
            List<Account> accounts = new List<Account>();

            doc.Load(Path.AccountsXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllAccount);

            foreach (XmlNode node in nodes)
            {
                if (!isHaveAdmin && node.Attributes["Role"].Value == "admin")
                    continue;

                accounts.Add(new Account(
                        node.Attributes["Username"].Value,
                        node.Attributes["Password"].Value,
                        node.Attributes["Role"].Value
                        ));
            }

            doc.Save(Path.AccountsXml);

            GlobalData.QuantityEmployees = nodes.Count;

            return accounts;
        }

        // Product
        public static List<Electronic> GetListElectronic()
        {
            doc.Load(Path.ElectronicXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);

            List<Electronic> products = new List<Electronic>();

            foreach (XmlNode node in nodes)
            {
                products.Add(
                    new Electronic(
                        node.Attributes["Id"].Value,
                        node.Attributes["Category"].Value,
                        node.Attributes["Name"].Value,
                        node.Attributes["Producer"].Value,
                        double.Parse(node.Attributes["PriceInput"].Value),
                        int.Parse(node.Attributes["Warranty"].Value),
                        int.Parse(node.Attributes["ElectricPower"].Value)
                    ));
            }

            doc.Save(Path.ElectronicXml);
            return products;
        }

        public static List<Porcelain> GetListPorcelain()
        {
            doc.Load(Path.PorcelainXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);

            List<Porcelain> products = new List<Porcelain>();

            foreach (XmlNode node in nodes)
            {
                products.Add(
                    new Porcelain(
                        node.Attributes["Id"].Value,
                        node.Attributes["Category"].Value,
                        node.Attributes["Name"].Value,
                        node.Attributes["Producer"].Value,
                        double.Parse(node.Attributes["PriceInput"].Value),
                        node.Attributes["Material"].Value
                    ));
            }

            doc.Save(Path.PorcelainXml);
            return products;
        }

        public static List<Food> GetListFood()
        {
            doc.Load(Path.FoodXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);

            List<Food> products = new List<Food>();

            foreach (XmlNode node in nodes)
            {
                products.Add(
                    new Food(
                        node.Attributes["Id"].Value,
                        node.Attributes["Category"].Value,
                        node.Attributes["Name"].Value,
                        node.Attributes["Producer"].Value,
                        double.Parse(node.Attributes["PriceInput"].Value),
                        node.Attributes["MfgDate"].Value,
                        node.Attributes["ExpDate"].Value
                    ));
            }

            doc.Save(Path.FoodXml);
            return products;
        }

        public static List<IProduct> GetAllProduct()
        {
            List<IProduct> products = new List<IProduct>();

            products.AddRange(GetListElectronic());
            products.AddRange(GetListPorcelain());
            products.AddRange(GetListFood());

            return products;
        }

        public static Dictionary<string, string> GetListCategories()
        {
            doc.Load(Path.CategoryXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllCategory);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (XmlNode node in nodes)
            {
                dictionary.Add(node.Attributes["Id"].Value, node.Attributes["Name"].Value);
            }

            doc.Save(Path.CategoryXml);
            return dictionary;
        }

        public static int GetQuantityReceiptXml()
        {
            doc.Load(Path.ReceiptsXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllReceipt);

            doc.Save(Path.ReceiptsXml);
            return nodes.Count;
        }

        public static int GetQuantityInvoiceXml()
        {
            doc.Load(Path.InvoicesXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllInvoice);

            doc.Save(Path.InvoicesXml);
            return nodes.Count;
        }

        public static int GetQuantityOrderXml()
        {
            doc.Load(Path.OrdersXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllOrder);

            doc.Save(Path.OrdersXml);
            return nodes.Count;
        }

        public static int GetQuantityRequest()
        {
            doc.Load(Path.RequestXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllRequest);

            doc.Save(Path.RequestXml);

            return nodes.Count;
        }

        public static RepositoryBase<InventoryItem> GetImportInventory()
        {
            RepositoryBase<InventoryItem> products = new RepositoryBase<InventoryItem>();

            doc.Load(Path.ImportInventoryXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);
            foreach(XmlNode node in nodes)
            {
                IDiscountStrategy discountStrategy = null;

                if (node.Attributes["Category"].Value == "CAT1")
                    discountStrategy = new ElectronicDiscountStrategy();
                else if (node.Attributes["Category"].Value == "CAT2")
                    discountStrategy = new PorcelainDiscountStrategy();
                else
                    discountStrategy = new FoodDiscountStrategy();

                products.Add(new InventoryItem(
                    double.Parse(node.Attributes["Total"].Value),
                    0,
                    false,
                    node.Attributes["Id"].Value,
                    node.Attributes["Category"].Value,
                    node.Attributes["Name"].Value,
                    node.Attributes["Producer"].Value,
                    double.Parse(node.Attributes["PriceInput"].Value),
                    int.Parse(node.Attributes["Quantity"].Value)
                ));
                products.Items[products.Items.Count - 1].SetIDiscountStrategy(discountStrategy);
            }

            doc.Save(Path.ImportInventoryXml);
            return products;
        }

        public static RepositoryBase<InventoryItem> GetExportInventory()
        {
            RepositoryBase<InventoryItem> products = new RepositoryBase<InventoryItem>();

            doc.Load(Path.ExportInventoryXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);
            foreach (XmlNode node in nodes)
            {
                IDiscountStrategy discountStrategy = null;

                if (node.Attributes["Category"].Value == "CAT1")
                    discountStrategy = new ElectronicDiscountStrategy();
                else if (node.Attributes["Category"].Value == "CAT2")
                    discountStrategy = new PorcelainDiscountStrategy();
                else
                    discountStrategy = new FoodDiscountStrategy();

                products.Add(new InventoryItem(
                    double.Parse(node.Attributes["Total"].Value),
                    0,
                    false,
                    node.Attributes["Id"].Value,
                    node.Attributes["Category"].Value,
                    node.Attributes["Name"].Value,
                    node.Attributes["Producer"].Value,
                    double.Parse(node.Attributes["PriceInput"].Value),
                    int.Parse(node.Attributes["Quantity"].Value)
                ));
                products.Items[products.Items.Count - 1].SetIDiscountStrategy(discountStrategy);
            }

            doc.Save(Path.ExportInventoryXml);
            return products;
        }

        public static XmlNodeList GetDetailImportInventory()
        {
            doc.Load(Path.DetailImportInventoryXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);

            doc.Save(Path.DetailImportInventoryXml);

            return nodes;
        }

        public static XmlNodeList GetDetailExportInventory()
        {
            doc.Load(Path.DetailExportInventoryXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllProduct);

            doc.Save(Path.DetailExportInventoryXml);

            return nodes;
        }

        public static List<Customer> GetListCustomer()
        {
            doc.Load(Path.CustomerXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllCustomer);

            List<Customer> customers = new List<Customer>();

            foreach(XmlNode node in nodes)
            {
                customers.Add(new Customer(
                        node.Attributes["Name"].Value,
                        node.Attributes["Phone"].Value,
                        double.Parse(node.Attributes["Points"].Value),
                        node.Attributes["CardID"].Value
                    ));
            }

            doc.Save(Path.CustomerXml);

            return customers;
        }
    }
}
