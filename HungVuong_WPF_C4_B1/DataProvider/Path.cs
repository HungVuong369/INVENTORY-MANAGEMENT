using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class Path
    {
        public static string defaultLink = "Data/";
        public static string defaultLinkProduct = "Product/";

        public static string AccountsXml = defaultLink + "Accounts.xml";
        public static string AllAccount = "//Account";

        public static string CustomerXml = defaultLink + "Customers.xml";

        public static string ElectronicXml = defaultLink + defaultLinkProduct + "Electronic.xml";
        public static string PorcelainXml = defaultLink + defaultLinkProduct + "Porcelain.xml";
        public static string FoodXml = defaultLink + defaultLinkProduct+ "Food.xml";
        public static string CategoryXml = defaultLink + defaultLinkProduct + "Categories.xml";

        public static string ReceiptsXml = defaultLink + "Receipts.xml";
        public static string InvoicesXml = defaultLink + "Invoices.xml";
        public static string OrdersXml = defaultLink + "Orders.xml";

        public static string ImportInventoryXml = defaultLink + "Inventories/" + "ImportInventory.xml";
        public static string ExportInventoryXml = defaultLink + "Inventories/" + "ExportInventory.xml";

        public static string DetailImportInventoryXml = defaultLink + "Inventories/" + "DetailImportInventory.xml";
        public static string DetailExportInventoryXml = defaultLink + "Inventories/" + "DetailExportInventory.xml";

        public static string AllProduct = "//Product";
        public static string AllCustomer = "//Customer";
        public static string AllCategory = "//Category";
        public static string AllReceipt = "//Receipt";
        public static string AllInvoice = "//Invoice";
        public static string AllOrder = "//Order";
        public static string AllRequest = "//Request";

        public static string RequestXml = defaultLink + "Request.xml";

        public static string AllReceiptById(string id)
        {
            return $"//Receipt[@Id='{id}']";
        }

        public static string AllReceiptByDate(string date)
        {
            return $"//Receipt[@Date='{date}']";
        }

        public static string AllInvoiceById(string id)
        {
            return $"//Invoice[@Id='{id}']";
        }

        public static string AllInvoiceByDate(string date)
        {
            return $"//Invoice[@Date='{date}']";
        }

        public static string AllOrderByDate(string date)
        {
            return $"//Order[@Date='{date}']";
        }

        public static string AllOrderById(string id)
        {
            return $"//Order[@Id='{id}']";
        }

        public static string AllOrderDetailByDateAndId(string date, string productID)
        {
            return $"//Order[@Date='{date}']/OrderDetail[@ProductID='{productID}']";
        }

        public static string GetNodeRequestByID(string id)
        {
            return $"/Requests/Request[@CustomerID='{id}']";
        }
    }
}
