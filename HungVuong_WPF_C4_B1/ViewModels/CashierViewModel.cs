using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class CashierViewModel
    {
        private readonly ICashier _CashierManager;

        public List<ProductDTO> AvailableProducts { get; set; }
        public List<InvoiceDTO> InvoicesByDate { get; set; }
        public List<InvoiceDTO> InvoicesByMonthAndYear { get; set; }
        public CustomerDTO CustomerInformation { get; set; }
        public double Revenue { get; set; }
        public double Profit { get; set; }

        public CashierViewModel(ICashier cashierManager)
        {
            _CashierManager = cashierManager;
        }

        public void CreateOrder(Order order)
        {
            _CashierManager.CreateOrder(order);
        }

        public void SaveOrder(Order order)
        {
            _CashierManager.SaveOrder(order);
        }

        public void LoadAvailableProducts()
        {
            AvailableProducts = _CashierManager.GetAvailableProducts();
        }

        public void LoadInvoicesByDate(DateTime date)
        {
            InvoicesByDate = _CashierManager.GetInvoicesByDate(date);
        }

        public void LoadInvoicesByMonthAndYear(int month, int year)
        {
            InvoicesByMonthAndYear = _CashierManager.GetInvoicesByMonthAndYear(month, year);
        }

        public void LoadCustomerInformation(string customerId)
        {
            CustomerInformation = _CashierManager.GetCustomerInformation(customerId);
        }

        public void CalculateRevenue()
        {
            Revenue = _CashierManager.CalculateRevenue();
        }

        public void CalculateProfit()
        {
            Profit = _CashierManager.CalculateProfit();
        }
    }
}
