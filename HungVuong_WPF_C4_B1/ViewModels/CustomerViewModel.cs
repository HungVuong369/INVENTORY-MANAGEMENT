using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class CustomerViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public RepositoryBase<Customer> CustomerRepo { get; set; }

        public CustomerViewModel()
        {
            CustomerRepo = unitOfWork.GetRepositoryCustomer;
        }

        public bool isExistCardID(string cardID)
        {
            foreach(var item in CustomerRepo.Items)
            {
                if(item.CardID.ToUpper() == cardID.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        public Customer GetCustomerByCardID(string cardID)
        {
            foreach (var item in CustomerRepo.Items)
            {
                if (item.CardID.ToUpper() == cardID.ToUpper())
                {
                    return item;
                }
            }
            return null;
        }

        public double getPoints(double total)
        {
            return total * 0.001;
        }
    }
}
