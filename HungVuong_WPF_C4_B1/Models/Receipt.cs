using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class Receipt : INotifyPropertyChanged
    {
        private RepositoryBase<IProduct> _ProductRepo;

        public RepositoryBase<IProduct> ProductRepo
        {
            get
            {
                return _ProductRepo;
            }
            set
            {
                _ProductRepo = value;
                OnPropertyChanged();
            }
        }

        private int _TotalQuantity;
        private double _TotalPrice;
        private string _ReceiptID;

        public int TotalQuantity
        {
            get
            {
                return _TotalQuantity;
            }
            set
            {
                _TotalQuantity = value;
                OnPropertyChanged();
            }
        }

        public double TotalPrice
        {
            get
            {
                return _TotalPrice;
            }
            set
            {
                _TotalPrice = value;
                OnPropertyChanged();
            }
        }

        public string ReceiptID
        {
            get
            {
                return _ReceiptID;
            }
            set
            {
                _ReceiptID = value;
                OnPropertyChanged();
            }
        }

        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
