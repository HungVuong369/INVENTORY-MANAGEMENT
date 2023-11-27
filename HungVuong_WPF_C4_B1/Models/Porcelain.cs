using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class Porcelain : Product
    {
        public string Material { get; set; }

        public Porcelain(string id, string category, string name, string producer, double priceInput, string material) : base(id, category, name, producer, priceInput, 0)
        {
            base.discountStrategy = new PorcelainDiscountStrategy();
            this.Material = material;
        }
    }
}
