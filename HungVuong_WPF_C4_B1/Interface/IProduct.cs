using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public interface IProduct
    {
        string Id { get; }
        string Category { get; }
        string Name { get; }
        string Producer { get; }
        double PriceInput { get; set; }
        double PriceOutput { get; }
        int Quantity { get; set; }
        double TotalInput { get; }
    }
}
