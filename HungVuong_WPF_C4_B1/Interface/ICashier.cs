using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    interface ICashier
    {
        void CreateOrder(Order order);
        void SaveOrder(Order order);
        List<InvoiceDTO> GetInvoicesByDate(DateTime date);
        List<InvoiceDTO> GetInvoicesByMonthAndYear(int month, int year);
        CustomerDTO GetCustomerInformation(string customerId);
        List<ProductDTO> GetAvailableProducts();
        double CalculateRevenue();
        double CalculateProfit();
    }
}