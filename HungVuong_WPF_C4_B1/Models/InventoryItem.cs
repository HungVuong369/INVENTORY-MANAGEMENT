using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1 {
    public class InventoryItem : Product
    {
        public double MainPrice { get; set; }
        public int BeforeQuantity { get; set; }
        public bool IsNew { get; set; }

        public InventoryItem(double mainPrice, int beforeQuantity, bool isNew, string id, string category, string name, string producer, double priceInput, int quantity) : base(id, category, name, producer, priceInput, quantity)
        {
            this.MainPrice = mainPrice;
            this.BeforeQuantity = beforeQuantity;
            this.IsNew = isNew;
            base.discountStrategy = discountStrategy;
        }
    }
}
