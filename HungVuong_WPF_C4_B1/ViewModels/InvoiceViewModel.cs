using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class InvoiceViewModel
    {
        private IInventoryManager inventoryManager = new InventoryManagerService();
        private InventoryManagerViewModel InventoryManagerVM;

        private Invoice _Invoice;

        public Invoice Invoice
        {
            get
            {
                return _Invoice;
            }
            set
            {
                _Invoice = value;
            }
        }

        public InvoiceViewModel(AccountDTO account)
        {
            InventoryManagerVM = new InventoryManagerViewModel(inventoryManager);

            _Invoice = new Invoice();
            _Invoice.Username = account.Username;

            InventoryManagerVM.CreateInvoice(_Invoice);
        }

        public double GetTotalPrice()
        {
            _Invoice.TotalPrice = 0;
            foreach (var item in _Invoice.ProductRepo.Items)
            {
                _Invoice.TotalPrice += (item as Product).TotalOutput;
            }
            return _Invoice.TotalPrice;
        }

        public int GetTotalQuantity()
        {
            _Invoice.TotalQuantity = 0;
            foreach (var item in _Invoice.ProductRepo.Items)
            {
                _Invoice.TotalQuantity += item.Quantity;
            }
            return _Invoice.TotalQuantity;
        }

        public void SaveInvoice(Invoice Invoice)
        {
            InventoryManagerVM.SaveInvoice(Invoice);
        }

        public void ResetQuantity()
        {
            foreach (var item in _Invoice.ProductRepo.Items)
                item.Quantity = 0;
        }

        public void DeleteProduct()
        {
            for (int index = _Invoice.ProductRepo.Items.Count - 1; index >= 0; index--)
            {
                _Invoice.ProductRepo.Items.Remove(_Invoice.ProductRepo.Items[index]);
            }
        }

        public void ResetInvoice()
        {
            ResetQuantity();
            DeleteProduct();
            InventoryManagerVM.CreateInvoice(_Invoice);
            _Invoice.TotalPrice = 0;
            _Invoice.TotalQuantity = 0;
        }
    }
}
