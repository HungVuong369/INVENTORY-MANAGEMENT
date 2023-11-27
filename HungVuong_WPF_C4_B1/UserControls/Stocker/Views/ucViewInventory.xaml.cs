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
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for ucViewInventory.xaml
    /// </summary>
    public partial class ucViewInventory : UserControl
    {
        private IInventoryManager inventoryManager = new InventoryManagerService();
        private InventoryManagerViewModel _InventoryManagerVM;

        public ucViewInventory()
        {
            InitializeComponent();
            _InventoryManagerVM = new InventoryManagerViewModel(inventoryManager);
            _InventoryManagerVM.ExportInventory = DataProvider.GetExportInventory();
            _InventoryManagerVM.ImportInventory = DataProvider.GetImportInventory();
            lbFeaturare.SelectedIndex = 0;
        }

        private void lbFeaturare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = lbFeaturare.SelectedValue as ListBoxItem;

            ReloadDataGrid(item.Tag.ToString());
        }

        private DataGridTextColumn CreateColumn(string header, string properties, int width)
        {
            DataGridTextColumn column;

            column = new DataGridTextColumn();
            column.Header = header;
            Binding binding = new Binding(properties);
            column.Binding = binding;
            return column;
        }

        private void RemoveColumnByHeader(string headerText)
        {
            DataGridColumn columnToRemove = null;

            foreach (DataGridColumn column in dgInventory.Columns)
            {
                if (column.Header.ToString() == headerText)
                {
                    columnToRemove = column;
                    break;
                }
            }

            if (columnToRemove != null)
            {
                dgInventory.Columns.Remove(columnToRemove);
            }
        }

        private void ReloadDataGrid(string tag)
        {
            XmlNodeList nodes = null;

            RemoveColumnByHeader("Kỳ trước");
            //RemoveColumnByHeader("Tổng tiền kỳ trước");
            RemoveColumnByHeader("Kỳ gần đây");
            //RemoveColumnByHeader("Tổng tiền kỳ gần đây");
            RemoveColumnByHeader("Kỳ tạo gần đây");

            if (tag == "DetailImportInventory" || tag == "DetailExportInventory")
            {
                DataGridTextColumn columnX = CreateColumn("Kỳ trước", "Previous", 100);
                columnX.ElementStyle = new Style(typeof(TextBlock))
                {
                    Setters = {
                            new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Right),
                            new Setter(MarginProperty, new Thickness(5))
                          }
                };
                dgInventory.Columns.Add(columnX);
                
                //DataGridTextColumn column1 = CreateColumn("Tổng tiền kỳ trước", "AmountPrevious", 100);
                //dgInventory.Columns.Add(column1);
                //column1.Binding.StringFormat = "{0:N0} VND";

                DataGridTextColumn columnY = CreateColumn("Kỳ gần đây", "Recent", 100);
                columnY.ElementStyle = new Style(typeof(TextBlock))
                {
                    Setters = {
                            new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Right),
                            new Setter(MarginProperty, new Thickness(5))
                          }
                };

                dgInventory.Columns.Add(columnY);

                //DataGridTextColumn column2 = CreateColumn("Tổng tiền kỳ gần đây", "AmountRecent", 100);
                //dgInventory.Columns.Add(column2);
                //column2.Binding.StringFormat = "{0:N0} VND";

                dgInventory.Columns.Add(CreateColumn("Kỳ tạo gần đây", "RecentlyCreated", 100));
            }

            if (tag == "ImportInventory")
            {
                if(dgInventory.ItemsSource == null)
                    dgInventory.Items.Clear();
                dgInventory.ItemsSource = _InventoryManagerVM.ImportInventory.Items;
            }
            else if(tag == "ExportInventory")
            {
                if (dgInventory.ItemsSource == null)
                    dgInventory.Items.Clear();
                dgInventory.ItemsSource = _InventoryManagerVM.ExportInventory.Items;
            }
            else if(tag == "DetailImportInventory")
            {
                nodes = DataProvider.GetDetailImportInventory();
                dgInventory.ItemsSource = null;
                dgInventory.Items.Clear();

                foreach(XmlNode node in nodes)
                {
                    dgInventory.Items.Add(new
                    {
                        Id = node.Attributes["ProductID"].Value,
                        Name = node.Attributes["Product"].Value,
                        Producer = node.Attributes["Producer"].Value,
                        Quantity = node.Attributes["Quantity"].Value,
                        MainPrice = double.Parse(node.Attributes["Amount"].Value),
                        Previous = node.Attributes["Previous"].Value,
                        AmountPrevious = double.Parse(node.Attributes["AmountPrevious"].Value),
                        Recent = node.Attributes["Recent"].Value,
                        AmountRecent = double.Parse(node.Attributes["AmountRecent"].Value),
                        RecentlyCreated = node.Attributes["Date"].Value,
                    });
                }
            }
            else if(tag == "DetailExportInventory")
            {
                nodes = DataProvider.GetDetailExportInventory();
                dgInventory.ItemsSource = null;
                dgInventory.Items.Clear();

                foreach (XmlNode node in nodes)
                {
                    dgInventory.Items.Add(new
                    {
                        Id = node.Attributes["ProductID"].Value,
                        Name = node.Attributes["Product"].Value,
                        Producer = node.Attributes["Producer"].Value,
                        Quantity = node.Attributes["Quantity"].Value,
                        MainPrice = double.Parse(node.Attributes["Amount"].Value),
                        Previous = node.Attributes["Previous"].Value,
                        AmountPrevious = double.Parse(node.Attributes["AmountPrevious"].Value),
                        Recent = node.Attributes["Recent"].Value,
                        AmountRecent = double.Parse(node.Attributes["AmountRecent"].Value),
                        RecentlyCreated = node.Attributes["Date"].Value,
                    });
                }
            }
        }
    }
}
