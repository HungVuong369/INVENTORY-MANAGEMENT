using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    public class ProductViewModel
    {
        private ElectronicViewModel _ElectronicVM = new ElectronicViewModel();
        private PorcelainViewModel _PorcelainVM = new PorcelainViewModel();
        private FoodViewModel _FoodVM = new FoodViewModel();

        public RepositoryBase<IProduct> productRepo
        {
            get
            {
                RepositoryBase<IProduct> iProduct = new RepositoryBase<IProduct>();
                iProduct.Items.AddRange(_ElectronicVM.electronicRepo.Items);
                iProduct.Items.AddRange(_PorcelainVM.porcelainRepo.Items);
                iProduct.Items.AddRange(_FoodVM.foodRepo.Items);
                return iProduct;
            }
        }

        public ProductViewModel()
        {
        }
    }
}
