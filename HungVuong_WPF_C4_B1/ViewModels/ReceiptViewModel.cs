using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class ReceiptViewModel
    {
        private IInventoryManager inventoryManager = new InventoryManagerService();
        private InventoryManagerViewModel InventoryManagerVM;

        private Receipt _Receipt;

        public Receipt Receipt {
            get
            {
                return _Receipt;
            }
            set
            {
                _Receipt = value;
            }
        }

        public ReceiptViewModel(AccountDTO account)
        {
            InventoryManagerVM = new InventoryManagerViewModel(inventoryManager);

            _Receipt = new Receipt();
            _Receipt.Username = account.Username;

            InventoryManagerVM.CreateReceipt(_Receipt);
        }

        public double GetTotalPrice()
        {
            _Receipt.TotalPrice = 0;
            foreach (var item in _Receipt.ProductRepo.Items)
            {
                _Receipt.TotalPrice += item.Quantity * item.PriceInput;
            }
            return _Receipt.TotalPrice;
        }

        public int GetTotalQuantity()
        {
            _Receipt.TotalQuantity = 0;
            foreach (var item in _Receipt.ProductRepo.Items)
            {
                _Receipt.TotalQuantity += item.Quantity;
            }
            return _Receipt.TotalQuantity;
        }

        public void SaveReceipt(Receipt receipt)
        {
            InventoryManagerVM.SaveReceipt(receipt);
        }

        public void ResetQuantity()
        {
            foreach(var item in _Receipt.ProductRepo.Items)
                item.Quantity = 0;
        }

        public void DeleteProduct()
        {
            for(int index = _Receipt.ProductRepo.Items.Count - 1; index >= 0; index--)
            {
                _Receipt.ProductRepo.Items.Remove(_Receipt.ProductRepo.Items[index]);
            }
        }

        public void ResetReceipt()
        {
            ResetQuantity();
            DeleteProduct();
            InventoryManagerVM.CreateReceipt(_Receipt);
            _Receipt.TotalPrice = 0;
            _Receipt.TotalQuantity = 0;
        }
    }
}
