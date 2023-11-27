using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HungVuong_WPF_C4_B1
{
    class InvalidInput : ValidationRule
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if((string)value == string.Empty)
                return new ValidationResult(false, "Vui lòng không để trống!");
            if(value.ToString().Length > MaxLength)
                return new ValidationResult(false, $"Giới hạn {MaxLength} kí tự!");
            if(value.ToString().Length < MinLength)
                return new ValidationResult(false, $"Tối thiểu {MinLength} kí tự!");
            return ValidationResult.ValidResult;
        }
    }
}
