using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class InvoiceDTO
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
        public List<InvoiceItemDTO> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
