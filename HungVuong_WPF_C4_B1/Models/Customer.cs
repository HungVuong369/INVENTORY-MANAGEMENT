using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class Customer : INotifyPropertyChanged
    {
        private string _Name;
        private string _Phone;
        private double _Points;

        public string Name {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public string Phone {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
                OnPropertyChanged();
            }
        }
        public double Points {
            get { return _Points; }
            set
            {
                _Points = value;
                OnPropertyChanged();
            }
        }
        public string CardID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer(string name, string phone, double points, string cardID)
        {
            this.Name = name;
            this.Phone = phone;
            this.Points = points;
            this.CardID = cardID;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
