using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for ViewProduct.xaml
    /// </summary>
    public partial class ViewProduct : UserControl
    {
        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private ElectronicViewModel _ElectronicVM = new ElectronicViewModel();
        private PorcelainViewModel _PorcelainVM = new PorcelainViewModel();
        private FoodViewModel _FoodVM = new FoodViewModel();

        public ViewProduct()
        {
            InitializeComponent();
            lstCategories.ItemsSource = _CategoryVM.categoryRepo.Values;
            lstCategories.SelectedIndex = 0;
        }

        private void RemoveColumnByHeader(string headerText)
        {
            DataGridColumn columnToRemove = null;

            foreach (DataGridColumn column in dgProducts.Columns)
            {
                if (column.Header.ToString() == headerText)
                {
                    columnToRemove = column;
                    break;
                }
            }

            if (columnToRemove != null)
            {
                dgProducts.Columns.Remove(columnToRemove);
            }
        }

        private DataGridTextColumn GetColumnByHeader(string headerText)
        {
            DataGridTextColumn columnTemp = null;

            foreach (DataGridTextColumn column in dgProducts.Columns)
            {
                if (column.Header.ToString() == headerText)
                {
                    columnTemp = column;
                    break;
                }
            }
            return columnTemp;
        }

        private DataGridTextColumn CreateColumn(string header, string properties, int width)
        {
            DataGridTextColumn column;

            column = new DataGridTextColumn();
            column.Header = header;
            Binding binding = new Binding(properties);
            column.Binding = binding;
            column.Width = new DataGridLength(width);
            
            return column;
        }

        private void lstCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveColumnByHeader("Bảo hành");
            RemoveColumnByHeader("Công suất");
            RemoveColumnByHeader("Vật liệu");
            RemoveColumnByHeader("Ngày sản xuất");
            RemoveColumnByHeader("Ngày hết hạn");

            if (lstCategories.SelectedValue.ToString() == "Electronic")
            {
                DataGridTextColumn column1 = CreateColumn("Bảo hành", "WarrantyMonths", 100);
                DataGridTextColumn column2 = CreateColumn("Công suất", "ElectricPower", 100);
                column1.ElementStyle = new Style(typeof(TextBlock))
                {
                    Setters = {
                            new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Right),
                            new Setter(MarginProperty, new Thickness(5))
                          }
                };

                column2.ElementStyle = new Style(typeof(TextBlock))
                {
                    Setters = {
                            new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Right),
                            new Setter(MarginProperty, new Thickness(5))
                          }
                };
                dgProducts.Columns.Add(column1);
                dgProducts.Columns.Add(column2);

                dgProducts.ItemsSource = _ElectronicVM.electronicRepo.Items;
            }
            else if(lstCategories.SelectedValue.ToString() == "Porcelain")
            {
                dgProducts.Columns.Add(CreateColumn("Vật liệu", "Material", 100));

                dgProducts.ItemsSource = _PorcelainVM.porcelainRepo.Items;
            }
            else if (lstCategories.SelectedValue.ToString() == "Food")
            {
                dgProducts.Columns.Add(CreateColumn("Ngày sản xuất", "MfgDate", 100));
                dgProducts.Columns.Add(CreateColumn("Ngày hết hạn", "ExpDate", 100));

                DataGridTextColumn column = GetColumnByHeader("Ngày sản xuất");
                column.Binding.StringFormat = "dd/MM/yyyy";

                column = GetColumnByHeader("Ngày hết hạn");
                column.Binding.StringFormat = "dd/MM/yyyy";

                dgProducts.ItemsSource = _FoodVM.foodRepo.Items;
            }
        }
    }
}
