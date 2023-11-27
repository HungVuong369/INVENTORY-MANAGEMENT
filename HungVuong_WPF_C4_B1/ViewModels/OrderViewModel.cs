using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class OrderViewModel
    {
        private ICashier cashier = new CashierService();
        private CashierViewModel _CashierVM;

        private Order _Order;

        public Order Order
        {
            get
            {
                return _Order;
            }
            set
            {
                _Order = value;
            }
        }

        public OrderViewModel(AccountDTO account)
        {
            _CashierVM = new CashierViewModel(cashier);

            _Order = new Order();
            _Order.Username = account.Username;

            _CashierVM.CreateOrder(_Order);
        }

        public double GetTotalPrice()
        {
            _Order.TotalPrice = 0;
            foreach (var item in _Order.ProductRepo.Items)
            {
                _Order.TotalPrice += (item as Product).TotalOutput;
            }
            return _Order.TotalPrice;
        }

        public int GetTotalQuantity()
        {
            _Order.TotalQuantity = 0;
            foreach (var item in _Order.ProductRepo.Items)
            {
                _Order.TotalQuantity += item.Quantity;
            }
            return _Order.TotalQuantity;
        }

        public void SaveOrder(Order order)
        {
            _CashierVM.SaveOrder(order);
        }

        public void ResetQuantity()
        {
            foreach (var item in _Order.ProductRepo.Items)
                item.Quantity = 0;
        }

        public void DeleteProduct()
        {
            for (int index = _Order.ProductRepo.Items.Count - 1; index >= 0; index--)
            {
                _Order.ProductRepo.Items.Remove(_Order.ProductRepo.Items[index]);
            }
        }

        public void ResetOrder()
        {
            ResetQuantity();
            DeleteProduct();
            _CashierVM.CreateOrder(_Order);
            _Order.TotalPrice = 0;
            _Order.TotalQuantity = 0;
        }
    }
}
