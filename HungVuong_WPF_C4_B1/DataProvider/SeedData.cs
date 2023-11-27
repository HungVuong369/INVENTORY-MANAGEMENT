using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    class SeedData
    {
        private static readonly XmlDocument doc = new XmlDocument();

        private List<IProduct> GenerateElectronic()
        {
            var electronic = new List<IProduct>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new Electronic
                (
                    $"E{i}",
                    "Electronic",
                    $"Electronic {i}",
                    $"Producer {i}",
                    100 + i * 10,
                    12 + i,
                    0 + i
                );

                electronic.Add(product);
            }

            return electronic;
        }

        private List<IProduct> GeneratePorcelain()
        {
            var porcelain = new List<IProduct>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new Porcelain
                (
                    $"P{i}",
                    "Porcelain",
                    $"Porcelain {i}",
                    $"Producer {i}",
                    50 + i * 5,
                    "Ceramic"
                );

                porcelain.Add(product);
            }

            return porcelain;
        }

        private List<IProduct> GenerateFood()
        {
            var food = new List<IProduct>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new Food
                (
                    $"F{i}",
                    "Food",
                    $"Food {i}",
                    $"Producer {i}",
                    5 + i,
                    $"{DateTime.Now.ToString("dd/MM/yyyy")}",
                    $"{DateTime.Now.AddMonths(i).ToString("dd/MM/yyyy")}"
                );

                food.Add(product);
            }

            return food;
        }

        public List<IProduct> Generate()
        {
            var seedData = new List<IProduct>();

            seedData.AddRange(GenerateElectronic());
            seedData.AddRange(GeneratePorcelain());
            seedData.AddRange(GenerateFood());

            return seedData;
        }
    }
}
