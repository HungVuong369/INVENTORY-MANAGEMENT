using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public interface IInventoryManager
    {
        void CreateReceipt(Receipt receipt);
        void SaveReceipt(Receipt receipt);
        void CreateInvoice(Invoice invoice);
        void SaveInvoice(Invoice invoice);
        void UpdateInventory(InvoiceDTO invoice);
        InvoiceDTO GetInvoice(string invoiceId);
        RepositoryBase<Product> GetImportInventory();
        RepositoryBase<Product> GetExportInventory();
        void SaveImportInventory(RepositoryBase<InventoryItem> importInventory, RepositoryBase<IProduct> lstProduct);
        void SaveDetailImportInventory(Receipt receipt, RepositoryBase<InventoryItem> importInventory);
        void SaveDetailExportInventory(Invoice invoice, RepositoryBase<InventoryItem> exportInventory);
        void SaveExportInventory(RepositoryBase<InventoryItem> exportInventory, RepositoryBase<IProduct> lstProduct);
    }
}
