using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HungVuong_WPF_C4_B1
{
    public class ConvertPointsToCardType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double points = (double)value;

            if (points > 5000 && points <= 10000)
                return "Vàng";

            else if (points > 10000)
                return "Bạch Kim";

            return "Chưa có";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
