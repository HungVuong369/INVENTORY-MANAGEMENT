using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class InventoryManagerViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();

        private readonly IInventoryManager _InventoryManager;
        public RepositoryBase<InventoryItem> ImportInventory { get; set; }
        public RepositoryBase<InventoryItem> ExportInventory { get; set; }

        public InventoryManagerViewModel(IInventoryManager inventoryManager)
        {
            this._InventoryManager = inventoryManager;
            ImportInventory = unitOfWork.GetRepositoryImportInventory;
            ExportInventory = unitOfWork.GetRepositoryExportInventory;
        }

        public void CreateReceipt(Receipt receipt)
        {
            this._InventoryManager.CreateReceipt(receipt);
        }

        public void SaveReceipt(Receipt receipt)
        {
            this._InventoryManager.SaveReceipt(receipt);
        }

        public void CreateInvoice(Invoice invoice)
        {
            this._InventoryManager.CreateInvoice(invoice);
        }

        public void SaveInvoice(Invoice invoice)
        {
            this._InventoryManager.SaveInvoice(invoice);
        }

        public RepositoryBase<Product> GetImportInventory()
        {
            return this._InventoryManager.GetImportInventory();
        }

        public RepositoryBase<Product> GetExportInventory()
        {
            return this._InventoryManager.GetExportInventory();
        }

        public InvoiceDTO GetInvoice(string invoiceID)
        {
            return this._InventoryManager.GetInvoice(invoiceID);
        }

        public void UpdateInventory(InvoiceDTO invoice)
        {
            this._InventoryManager.UpdateInventory(invoice);
        }

        public void SaveImportInventory(RepositoryBase<IProduct> lstProduct)
        {
            this._InventoryManager.SaveImportInventory(ImportInventory, lstProduct);
        }

        public void SaveExportInventory(RepositoryBase<IProduct> lstProduct)
        {
            this._InventoryManager.SaveExportInventory(ExportInventory, lstProduct);
        }

        public void SaveDetailImportInventory(Receipt receipt, RepositoryBase<InventoryItem> importInventory)
        {
            this._InventoryManager.SaveDetailImportInventory(receipt, importInventory);
        }

        public void SaveDetailExportInventory(Invoice invoice, RepositoryBase<InventoryItem> exportInventory)
        {
            this._InventoryManager.SaveDetailExportInventory(invoice, exportInventory);
        }

        public void UpdateImportInventory(RepositoryBase<IProduct> lstProduct)
        {
            foreach(var item in lstProduct.Items)
            {
                var product = ImportInventory.Items.Find(p => p.Id == item.Id);

                product.Quantity -= item.Quantity;
                product.MainPrice -= item.Quantity * item.PriceInput;
            }
        }

        public void UpdateExportInventory(RepositoryBase<IProduct> lstProduct)
        {
            foreach (var item in lstProduct.Items)
            {
                var product = ExportInventory.Items.Find(p => p.Id == item.Id);

                product.Quantity -= item.Quantity;
                product.MainPrice -= product.TotalOutput;
            }
        }
    }
}
