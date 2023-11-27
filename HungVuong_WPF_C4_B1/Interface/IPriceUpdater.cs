using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    interface IPriceUpdater
    {
        void UpdatePrice(IProduct product, double newPrice);
    }
}
