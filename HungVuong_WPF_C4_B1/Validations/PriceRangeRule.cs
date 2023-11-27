using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HungVuong_WPF_C4_B1
{
    class PriceRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double price = 0;
            try
            {
                if (((string)value).Length > 0)
                    price = Int32.Parse((string)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }

            if((string)value == string.Empty)
                return new ValidationResult(false, "Vui lòng không để trống!");
            else if (price == 0)
                return new ValidationResult(false, "Số tiền không hợp lệ!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
