using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class PorcelainViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public RepositoryBase<Porcelain> porcelainRepo { get; set; }

        public PorcelainViewModel()
        {
            porcelainRepo = unitOfWork.GetRepositoryPorcelain;
        }
    }
}
