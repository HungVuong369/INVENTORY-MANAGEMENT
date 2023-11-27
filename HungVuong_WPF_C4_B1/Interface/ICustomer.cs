using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    interface ICustomer
    {
        void CreateCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        CustomerDTO GetCustomerById(string customerId);
        CustomerDTO GetCustomerByPhone(string phoneNumber);
        void CalculateCustomerPoints(double totalAmount);
    }
}
