using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_WPF_C4_B1
{
    class CategoryStyleSelector : StyleSelector
    {
        public Style ElectronicStyle { get; set; }
        public Style PorcelainStyle { get; set; }
        public Style FoodStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            ResourceDictionary resourceDict = new ResourceDictionary();
            resourceDict.Source = new Uri("Styles/Categories.xaml", UriKind.RelativeOrAbsolute);
            ElectronicStyle = resourceDict["ElectronicStyle"] as Style;
            PorcelainStyle = resourceDict["PorcelainStyle"] as Style;
            FoodStyle = resourceDict["FoodStyle"] as Style;

            var p = item.ToString();

            if (p == null)
                return new Style();
            if (p == "CAT1")
                return ElectronicStyle;
            else if (p == "CAT2")
                return PorcelainStyle;
            else if (p == "CAT3")
                return FoodStyle;

            return new Style();
        }
    }
}
