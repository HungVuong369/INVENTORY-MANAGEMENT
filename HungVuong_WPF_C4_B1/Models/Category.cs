using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Category(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
