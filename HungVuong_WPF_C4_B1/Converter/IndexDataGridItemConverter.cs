using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HungVuong_WPF_C4_B1
{
    public class IndexDataGridItemConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridRow row = (DataGridRow)value;
            DataGrid dataGrid = ItemsControl.ItemsControlFromItemContainer(row) as DataGrid;
            int index = dataGrid.ItemContainerGenerator.IndexFromContainer(row) + 1;
            return index.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
