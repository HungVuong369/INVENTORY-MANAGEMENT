using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class FoodViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public RepositoryBase<Food> foodRepo { get; set; }

        public FoodViewModel()
        {
            foodRepo = unitOfWork.GetRepositoryFood;
        }

        public List<Food> GetProductExpired()
        {
            List<Food> foodList = new List<HungVuong_WPF_C4_B1.Food>();
            foreach(var product in foodRepo.Items)
            {
                if (product.ExpDate.Date < DateTime.Now.Date)
                    foodList.Add(product);
            }
            return foodList;
        }
    }
}
