using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    class InventoryManagerService : IInventoryManager
    {
        XmlDocument doc = new XmlDocument();

        public void CreateReceipt(Receipt receipt)
        {
            receipt.ProductRepo = new RepositoryBase<IProduct>();
            receipt.ReceiptID = "PNK" + (DataProvider.GetQuantityReceiptXml() + 1);
            receipt.CreatedAt = DateTime.Now;
        }

        private XmlAttribute CreateAttribute(string name, string value)
        {
            var attribute = doc.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }

        public void SaveReceipt(Receipt receipt)
        {
            doc.Load(Path.ReceiptsXml);

            XmlNode nodeRoot = doc.DocumentElement;

            XmlNode rootNode = doc.CreateNode(XmlNodeType.Element, "Receipt", null);

            rootNode.Attributes.Append(CreateAttribute("Id", receipt.ReceiptID));
            rootNode.Attributes.Append(CreateAttribute("Username", receipt.Username));
            rootNode.Attributes.Append(CreateAttribute("Quantity", receipt.TotalQuantity.ToString()));
            rootNode.Attributes.Append(CreateAttribute("Total", receipt.TotalPrice.ToString()));
            rootNode.Attributes.Append(CreateAttribute("Date", DateTime.Now.ToString("dd/MM/yyyy")));

            int index = 1;
            foreach (var receiptDetail in receipt.ProductRepo.Items)
            {
                XmlNode nodeChild = doc.CreateNode(XmlNodeType.Element, "ReceiptDetail", null);

                nodeChild.Attributes.Append(CreateAttribute("Id", index++.ToString()));
                nodeChild.Attributes.Append(CreateAttribute("ProductID", receiptDetail.Id));
                nodeChild.Attributes.Append(CreateAttribute("Name", receiptDetail.Name));
                nodeChild.Attributes.Append(CreateAttribute("Producer", receiptDetail.Producer));
                nodeChild.Attributes.Append(CreateAttribute("PriceInput", receiptDetail.PriceInput.ToString()));
                nodeChild.Attributes.Append(CreateAttribute("PriceOutput", receiptDetail.PriceOutput.ToString()));
                nodeChild.Attributes.Append(CreateAttribute("Quantity", receiptDetail.Quantity.ToString()));
                nodeChild.Attributes.Append(CreateAttribute("Total", (receiptDetail.PriceInput * receiptDetail.Quantity).ToString()));

                rootNode.AppendChild(nodeChild);
            }

            nodeRoot.AppendChild(rootNode);

            doc.Save(Path.ReceiptsXml);
        }

        public void CreateInvoice(Invoice invoice)
        {
            invoice.ProductRepo = new RepositoryBase<IProduct>();
            invoice.InvoiceID = "PXK" + (DataProvider.GetQuantityInvoiceXml() + 1);
            invoice.CreatedAt = DateTime.Now;
        }

        public void SaveInvoice(Invoice invoice)
        {
            doc.Load(Path.InvoicesXml);
            XmlNode nodeRoot = doc.DocumentElement;
            XmlNode rootNode = doc.CreateNode(XmlNodeType.Element, "Invoice", null);

            #region Set Attributes
            var attr1 = doc.CreateAttribute("Id");
            attr1.Value = invoice.InvoiceID;

            var attr2 = doc.CreateAttribute("Username");
            attr2.Value = invoice.Username;

            var attr3 = doc.CreateAttribute("Quantity");
            attr3.Value = invoice.TotalQuantity.ToString();

            var attr4 = doc.CreateAttribute("Total");
            attr4.Value = invoice.TotalPrice.ToString();

            var attr5 = doc.CreateAttribute("Date");
            attr5.Value = DateTime.Now.ToString("dd/MM/yyyy");
            #endregion

            #region Append Attributes
            rootNode.Attributes.Append(attr1);
            rootNode.Attributes.Append(attr2);
            rootNode.Attributes.Append(attr3);
            rootNode.Attributes.Append(attr4);
            rootNode.Attributes.Append(attr5);
            #endregion

            nodeRoot.AppendChild(rootNode);

            XmlNode nodeChild = null;

            int index = 1;
            foreach (var invoiceDetail in invoice.ProductRepo.Items)
            {
                nodeChild = doc.CreateNode(XmlNodeType.Element, "InvoiceDetail", null);

                #region Set Attributes
                var attr12 = doc.CreateAttribute("Id");
                attr12.Value = index++.ToString();

                var attr13 = doc.CreateAttribute("ProductID");
                attr13.Value = invoiceDetail.Id;

                var attr6 = doc.CreateAttribute("Name");
                attr6.Value = invoiceDetail.Name;

                var attr7 = doc.CreateAttribute("Producer");
                attr7.Value = invoiceDetail.Producer;

                var attr8 = doc.CreateAttribute("PriceInput");
                attr8.Value = invoiceDetail.PriceInput.ToString();

                var attr9 = doc.CreateAttribute("PriceOutput");
                attr9.Value = invoiceDetail.PriceOutput.ToString();

                var attr10 = doc.CreateAttribute("Quantity");
                attr10.Value = invoiceDetail.Quantity.ToString();

                var attr11 = doc.CreateAttribute("Total");
                attr11.Value = (invoiceDetail as Product).TotalOutput .ToString();
                #endregion

                #region Append Attributes
                nodeChild.Attributes.Append(attr12);
                nodeChild.Attributes.Append(attr13);
                nodeChild.Attributes.Append(attr6);
                nodeChild.Attributes.Append(attr7);
                nodeChild.Attributes.Append(attr8);
                nodeChild.Attributes.Append(attr9);
                nodeChild.Attributes.Append(attr10);
                nodeChild.Attributes.Append(attr11);
                #endregion

                rootNode.AppendChild(nodeChild);
            }
            doc.Save(Path.InvoicesXml);
        }

        public InvoiceDTO GetInvoice(string invoiceId)
        {
            return new InvoiceDTO();
        }

        public void UpdateInventory(InvoiceDTO invoice)
        {
        }

        public RepositoryBase<Product> GetImportInventory()
        {
            return new RepositoryBase<Product>();
        }

        public RepositoryBase<Product> GetExportInventory()
        {
            return new RepositoryBase<Product>();
        }

        public void SaveImportInventory(RepositoryBase<InventoryItem> importInventory, RepositoryBase<IProduct> lstProduct)
        {
            foreach (var item in lstProduct.Items)
            {
                var product = importInventory.Items.Find(element => element.Id == item.Id);
                if (product == null)
                {
                    importInventory.Add(new InventoryItem(
                        item.Quantity * item.PriceInput,
                        item.Quantity,
                        true,
                        item.Id,
                        item.Category,
                        item.Name,
                        item.Producer,
                        item.PriceInput,
                        item.Quantity
                        ));
                }
                else
                {
                    product.IsNew = false;
                    product.Quantity += item.Quantity;
                    (product as InventoryItem).BeforeQuantity = item.Quantity;
                    (product as InventoryItem).MainPrice = ((product as InventoryItem).MainPrice + product.PriceInput * (product as InventoryItem).BeforeQuantity);
                }
            }

            ProductViewModel productVM = new ProductViewModel();

            doc = new XmlDocument();

            XmlNode xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(xmlDeclaration);

            XmlNode rootNode = doc.CreateNode(XmlNodeType.Element, "Products", null);
            doc.AppendChild(rootNode);

            for (int index = importInventory.Items.Count - 1; index >= 0; index--)
            {
                var inventory = importInventory.Items[index];

                if (inventory.Quantity == 0)
                {
                    importInventory.Items.RemoveAt(index);
                    continue;
                }

                XmlNode nodeChild = doc.CreateNode(XmlNodeType.Element, "Product", null);

                var product = productVM.productRepo.Items.Find(item => item.Id == inventory.Id);

                #region Create Attributes
                var attr1 = doc.CreateAttribute("Id");
                attr1.Value = inventory.Id;

                var attr8 = doc.CreateAttribute("Category");
                attr8.Value = inventory.Category;

                var attr2 = doc.CreateAttribute("Name");
                attr2.Value = inventory.Name;

                var attr3 = doc.CreateAttribute("Producer");
                attr3.Value = inventory.Producer;

                var attr4 = doc.CreateAttribute("PriceInput");
                attr4.Value = product.PriceInput.ToString();

                var attr5 = doc.CreateAttribute("PriceOutput");
                attr5.Value = product.PriceOutput.ToString();

                var attr6 = doc.CreateAttribute("Quantity");
                attr6.Value = inventory.Quantity.ToString();

                XmlAttribute attr7 = doc.CreateAttribute("Total");
                if(inventory.IsNew == true)
                    attr7.Value = (inventory.Quantity * inventory.PriceInput).ToString();
                else
                    attr7.Value = ((inventory as InventoryItem).MainPrice.ToString());
                #endregion

                #region Append Attributes
                nodeChild.Attributes.Append(attr1);
                nodeChild.Attributes.Append(attr8);
                nodeChild.Attributes.Append(attr2);
                nodeChild.Attributes.Append(attr3);
                nodeChild.Attributes.Append(attr4);
                nodeChild.Attributes.Append(attr5);
                nodeChild.Attributes.Append(attr6);
                nodeChild.Attributes.Append(attr7);
                #endregion

                rootNode.AppendChild(nodeChild);
            }
            doc.Save(Path.ImportInventoryXml);
        }

        public void SaveExportInventory(RepositoryBase<InventoryItem> exportInventory, RepositoryBase<IProduct> lstProduct)
        {
            foreach (var item in lstProduct.Items)
            {
                var product = exportInventory.Items.Find(element => element.Id == item.Id);
                if (product == null)
                {
                    exportInventory.Add(new InventoryItem(
                        (item as Product).TotalOutput,
                        item.Quantity,
                        true,
                        item.Id,
                        item.Category,
                        item.Name,
                        item.Producer,
                        item.PriceInput,
                        item.Quantity
                        ));

                    IDiscountStrategy discountStrategy = null;

                    if (item.Category == "CAT1")
                        discountStrategy = new ElectronicDiscountStrategy();
                    else if (item.Category == "CAT2")
                        discountStrategy = new PorcelainDiscountStrategy();
                    else
                        discountStrategy = new FoodDiscountStrategy();

                    exportInventory.Items[exportInventory.Items.Count - 1].SetIDiscountStrategy(discountStrategy);
                }
                else
                {
                    product.IsNew = false;
                    product.Quantity += item.Quantity;
                    (product as InventoryItem).BeforeQuantity = item.Quantity;
                    (product as InventoryItem).MainPrice = ((product as InventoryItem).MainPrice + product.GetDiscountedPrice() * (product as InventoryItem).BeforeQuantity);
                }
            }

            doc = new XmlDocument();

            XmlNode xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(xmlDeclaration);

            XmlNode rootNode = doc.CreateNode(XmlNodeType.Element, "Products", null);
            doc.AppendChild(rootNode);

            for (int index = exportInventory.Items.Count - 1; index >= 0; index--)
            {
                var product = exportInventory.Items[index];

                if (product.Quantity == 0)
                {
                    exportInventory.Items.RemoveAt(index);
                    continue;
                }

                XmlNode nodeChild = doc.CreateNode(XmlNodeType.Element, "Product", null);

                #region Create Attributes
                var attr1 = doc.CreateAttribute("Id");
                attr1.Value = product.Id;

                var attr8 = doc.CreateAttribute("Category");
                attr8.Value = product.Category;

                var attr2 = doc.CreateAttribute("Name");
                attr2.Value = product.Name;

                var attr3 = doc.CreateAttribute("Producer");
                attr3.Value = product.Producer;

                var attr4 = doc.CreateAttribute("PriceInput");
                attr4.Value = product.PriceInput.ToString();

                var attr5 = doc.CreateAttribute("PriceOutput");
                attr5.Value = product.PriceOutput.ToString();

                var attr6 = doc.CreateAttribute("Quantity");
                attr6.Value = product.Quantity.ToString();

                var attr7 = doc.CreateAttribute("Total");
                attr7.Value = product.TotalOutput.ToString();
                #endregion

                #region Append Attributes
                nodeChild.Attributes.Append(attr1);
                nodeChild.Attributes.Append(attr2);
                nodeChild.Attributes.Append(attr8);
                nodeChild.Attributes.Append(attr3);
                nodeChild.Attributes.Append(attr4);
                nodeChild.Attributes.Append(attr5);
                nodeChild.Attributes.Append(attr6);
                nodeChild.Attributes.Append(attr7);
                #endregion

                rootNode.AppendChild(nodeChild);
            }
            doc.Save(Path.ExportInventoryXml);
        }

        private XmlNode FindReceipt(IProduct receiptDetail, XmlNodeList lstNode)
        {
            foreach (XmlNode node in lstNode)
            {
                if (receiptDetail.Id == node.Attributes["ProductID"].Value)
                    return node;
            }
            return null;
        }

        private void CreateProductInventory(RepositoryBase<InventoryItem> importInventory, Receipt receipt, XmlNodeList lstNode, IProduct receiptDetail, ref int index)
        {
            XmlNode nodeChild = doc.CreateNode(XmlNodeType.Element, "Product", null);

            Product product = importInventory.Items.Find(p => p.Id == receiptDetail.Id);

            #region Set Attributes
            var attr1 = doc.CreateAttribute("No");
            attr1.Value = index++.ToString();

            var attr2 = doc.CreateAttribute("Product");
            attr2.Value = receiptDetail.Name;

            var attr14 = doc.CreateAttribute("Producer");
            attr14.Value = receiptDetail.Producer;

            var attr13 = doc.CreateAttribute("ProductID");
            attr13.Value = receiptDetail.Id;

            var attr3 = doc.CreateAttribute("Previous");
            attr3.Value = "0";

            var attr4 = doc.CreateAttribute("AmountPrevious");
            attr4.Value = "0";

            var attr5 = doc.CreateAttribute("Recent");
            attr5.Value = receiptDetail.Quantity.ToString();

            var attr6 = doc.CreateAttribute("AmountRecent");
            attr6.Value = receiptDetail.TotalInput.ToString();

            var attr7 = doc.CreateAttribute("Date");
            attr7.Value = receipt.CreatedAt.ToString("dd/MM/yyyy");

            var attr11 = doc.CreateAttribute("Quantity");
            attr11.Value = receiptDetail.Quantity.ToString();

            var attr12 = doc.CreateAttribute("Amount");
            attr12.Value = receiptDetail.TotalInput.ToString();
            #endregion

            #region Append Attributes
            nodeChild.Attributes.Append(attr1);
            nodeChild.Attributes.Append(attr2);
            nodeChild.Attributes.Append(attr14);
            nodeChild.Attributes.Append(attr3);
            nodeChild.Attributes.Append(attr4);
            nodeChild.Attributes.Append(attr5);
            nodeChild.Attributes.Append(attr6);
            nodeChild.Attributes.Append(attr7);
            nodeChild.Attributes.Append(attr11);
            nodeChild.Attributes.Append(attr12);
            nodeChild.Attributes.Append(attr13);
            #endregion

            XmlNode node = doc.DocumentElement;

            node.AppendChild(nodeChild);
        }

        private void setProductInventory(RepositoryBase<InventoryItem> importInventory, Receipt receipt, XmlNode node, IProduct receiptDetail)
        {
            Product product = importInventory.Items.Find(p => p.Id == receiptDetail.Id);
            node.Attributes["Previous"].Value = node.Attributes["Quantity"].Value;
            node.Attributes["AmountPrevious"].Value = node.Attributes["Amount"].Value;
            node.Attributes["Recent"].Value = receiptDetail.Quantity.ToString();
            node.Attributes["AmountRecent"].Value = receiptDetail.TotalInput.ToString();
            node.Attributes["Date"].Value = receipt.CreatedAt.ToString("dd/MM/yyyy");
            node.Attributes["Quantity"].Value = (int.Parse(node.Attributes["Previous"].Value) + receiptDetail.Quantity).ToString();
            node.Attributes["Amount"].Value = (double.Parse(node.Attributes["AmountPrevious"].Value) + double.Parse(node.Attributes["AmountRecent"].Value)).ToString();
        }

        public void SaveDetailImportInventory(Receipt receipt, RepositoryBase<InventoryItem> importInventory)
        {
            doc.Load(Path.DetailImportInventoryXml);

            XmlNodeList lstNode = doc.SelectNodes(Path.AllProduct);

            int index = lstNode.Count + 1;
            foreach (var receiptDetail in receipt.ProductRepo.Items)
            {
                XmlNode node = FindReceipt(receiptDetail, lstNode);

                if (node == null)
                    CreateProductInventory(importInventory, receipt, lstNode, receiptDetail, ref index);
                else
                    setProductInventory(importInventory, receipt, node, receiptDetail);
            }

            doc.Save(Path.DetailImportInventoryXml);
        }

        private XmlNode FindInvoice(IProduct invoiceDetail, XmlNodeList lstNode)
        {
            foreach (XmlNode node in lstNode)
            {
                if (invoiceDetail.Id == node.Attributes["ProductID"].Value)
                    return node;
            }
            return null;
        }

        private void CreateProductInventory(Invoice invoice, XmlNodeList lstNode, IProduct invoiceDetail, ref int index)
        {
            XmlNode nodeChild = doc.CreateNode(XmlNodeType.Element, "Product", null);
            ProductViewModel productVM = new ProductViewModel();
            var product = productVM.productRepo.Items.Find(p => p.Id == invoiceDetail.Id);

            #region Set Attributes
            var attr1 = doc.CreateAttribute("No");
            attr1.Value = index++.ToString();

            var attr2 = doc.CreateAttribute("Product");
            attr2.Value = invoiceDetail.Name;

            var attr13 = doc.CreateAttribute("Producer");
            attr13.Value = invoiceDetail.Producer;

            var attr8 = doc.CreateAttribute("ProductID");
            attr8.Value = invoiceDetail.Id;

            var attr3 = doc.CreateAttribute("Previous");
            attr3.Value = "0";

            var attr4 = doc.CreateAttribute("AmountPrevious");
            attr4.Value = "0";

            var attr5 = doc.CreateAttribute("Recent");
            attr5.Value = invoiceDetail.Quantity.ToString();

            var attr6 = doc.CreateAttribute("AmountRecent");
            attr6.Value = (invoiceDetail as Product).TotalOutput.ToString();

            var attr7 = doc.CreateAttribute("Date");
            attr7.Value = invoice.CreatedAt.ToString("dd/MM/yyyy");

            var attr11 = doc.CreateAttribute("Quantity");
            attr11.Value = invoiceDetail.Quantity.ToString();

            var attr12 = doc.CreateAttribute("Amount");
            attr12.Value = (invoiceDetail as Product).TotalOutput.ToString();
            #endregion

            #region Append Attributes
            nodeChild.Attributes.Append(attr1);
            nodeChild.Attributes.Append(attr2);
            nodeChild.Attributes.Append(attr13);
            nodeChild.Attributes.Append(attr3);
            nodeChild.Attributes.Append(attr4);
            nodeChild.Attributes.Append(attr5);
            nodeChild.Attributes.Append(attr6);
            nodeChild.Attributes.Append(attr7);
            nodeChild.Attributes.Append(attr11);
            nodeChild.Attributes.Append(attr12);
            nodeChild.Attributes.Append(attr8);
            #endregion

            XmlNode node = doc.DocumentElement;

            node.AppendChild(nodeChild);
        }

        public void setProductInventory(RepositoryBase<InventoryItem> exportInventory, Invoice invoice, XmlNode node, IProduct invoiceDetail)
        {
            ProductViewModel productVM = new ProductViewModel();
            Product product = exportInventory.Items.Find(p => p.Id == invoiceDetail.Id);
            var itemDiscount = productVM.productRepo.Items.Find(p => p.Id == invoiceDetail.Id);

            node.Attributes["Previous"].Value = node.Attributes["Quantity"].Value;
            node.Attributes["AmountPrevious"].Value = node.Attributes["Amount"].Value;
            node.Attributes["Recent"].Value = invoiceDetail.Quantity.ToString();
            node.Attributes["AmountRecent"].Value = invoiceDetail.TotalInput.ToString();
            node.Attributes["Date"].Value = invoice.CreatedAt.ToString("dd/MM/yyyy");
            node.Attributes["Quantity"].Value = (int.Parse(node.Attributes["Previous"].Value) + invoiceDetail.Quantity).ToString();
            node.Attributes["Amount"].Value = (double.Parse(node.Attributes["AmountPrevious"].Value) + double.Parse(node.Attributes["AmountRecent"].Value)).ToString();
        }

        public void SaveDetailExportInventory(Invoice invoice, RepositoryBase<InventoryItem> exportInventory)
        {
            doc.Load(Path.DetailExportInventoryXml);

            XmlNodeList lstNode = doc.SelectNodes(Path.AllProduct);

            int index = lstNode.Count + 1;
            foreach (var invoiceDetail in invoice.ProductRepo.Items)
            {
                XmlNode node = FindInvoice(invoiceDetail, lstNode);

                if (node == null)
                    CreateProductInventory(invoice, lstNode, invoiceDetail, ref index);
                else
                    setProductInventory(exportInventory, invoice, node, invoiceDetail);
            }
            doc.Save(Path.DetailExportInventoryXml);
        }
    }
}
