using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class CategoryViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public Dictionary<string, string> categoryRepo { get; set; }

        public CategoryViewModel()
        {
            categoryRepo = unitOfWork.GetRepositoryCategory;
        }
    }
}
