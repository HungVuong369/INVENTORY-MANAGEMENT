using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class Electronic : Product
    {
        public int WarrantyMonths { get; set; }
        public int ElectricPower { get; set; }

        public Electronic(string id, string category, string name, string producer, double priceInput, int warrantyMonths, int electricPower) : base(id, category, name, producer, priceInput, 0)
        {
            base.discountStrategy = new ElectronicDiscountStrategy();
            this.WarrantyMonths = warrantyMonths;
            this.ElectricPower = electricPower;
        }
    }
}
