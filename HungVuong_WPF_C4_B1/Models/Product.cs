using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class Product : IProduct, INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        private double _PriceInput;
        public double PriceInput {
            get
            {
                return _PriceInput;
            }
            set
            {
                _PriceInput = value;
                OnPropertyChanged(nameof(PriceInput));
                OnPropertyChanged(nameof(PriceOutput));
            }
        }
        public double PriceOutput {
            get
            {
                if (PriceInput == 0)
                    return 0;
                return PriceInput + (PriceInput * 0.1) + (PriceInput * 0.3) + (PriceInput * GlobalData.QuantityEmployees * 0.012);
            }
        }
        private int _Quantity;
        public int Quantity {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }

        public double TotalInput
        {
            get { return Quantity * PriceInput; }
        }

        public double TotalOutput
        {
            get { return Quantity * discountStrategy.ApplyDiscount(PriceOutput); }
        }

        public double PriceDiscount
        {
            get { return discountStrategy.ApplyDiscount(PriceOutput); }
        }

        protected IDiscountStrategy discountStrategy;

        public virtual double GetDiscountedPrice()
        {
            return discountStrategy.ApplyDiscount(PriceOutput);
        }

        public void SetIDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Product(string id, string category, string name, string producer, double priceInput, int quantity)
        {
            this.Id = id;
            this.Category = category;
            this.Name = name;
            this.Producer = producer;
            this.PriceInput = priceInput;
            this.Quantity = quantity;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
