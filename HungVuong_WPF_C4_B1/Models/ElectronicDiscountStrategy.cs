using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class ElectronicDiscountStrategy : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                // Giảm 15%
                return price - (price * 0.15);
            }
            return price;
        }
    }
}
