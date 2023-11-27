using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class Food : Product
    {
        public DateTime MfgDate { get; set; }
        public DateTime ExpDate { get; set; }

        public Food(string id, string category, string name, string producer, double priceInput, string mfgDate, string expDate) : base(id, category, name, producer, priceInput, 0)
        {
            base.discountStrategy = new FoodDiscountStrategy();
            this.MfgDate = DateTime.ParseExact(mfgDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.ExpDate = DateTime.ParseExact(expDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
