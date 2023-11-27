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
    /// Interaction logic for ucUpdatePrice.xaml
    /// </summary>
    public partial class ucUpdatePrice : UserControl
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        private CategoryViewModel _CategoryVM = new CategoryViewModel();

        private ProductViewModel _ProductVM = new ProductViewModel();
        private ElectronicViewModel _ElectronicVM = new ElectronicViewModel();
        private PorcelainViewModel _PorcelainVM = new PorcelainViewModel();
        private FoodViewModel _FoodVM = new FoodViewModel();

        private IProduct _selectedProduct;
        private DataGridRow selectedRow = null;

        private IInventoryManager inventoryManager = new InventoryManagerService();
        private InventoryManagerViewModel _InventoryManagerVM;

        public double Price { get; set; }

        public ucUpdatePrice()
        {
            InitializeComponent();

            lstCategories.ItemsSource = _CategoryVM.categoryRepo.Values;
            lstCategories.SelectedIndex = 0;

            _InventoryManagerVM = new InventoryManagerViewModel(inventoryManager);

            DataContext = this;
        }

        private void lstCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCategories.SelectedValue.ToString() == "Electronic")
            {
                dgProducts.ItemsSource = _ElectronicVM.electronicRepo.Items;
            }
            else if (lstCategories.SelectedValue.ToString() == "Porcelain")
            {
                dgProducts.ItemsSource = _PorcelainVM.porcelainRepo.Items;
            }
            else if (lstCategories.SelectedValue.ToString() == "Food")
            {
                dgProducts.ItemsSource = _FoodVM.foodRepo.Items;
            }
            txtPriceInput.IsEnabled = false;
            btnUpdatePrice.IsEnabled = false;
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedIndex == -1)
                return;
            if (selectedRow != null)
                selectedRow.Background = Brushes.White;

            if (dgProducts.SelectedItem != null)
            {
                this._selectedProduct = (IProduct)dgProducts.SelectedItem;
                txtPriceInput.IsEnabled = true;
                btnUpdatePrice.IsEnabled = true;

                var dataGrid = (DataGrid)sender;
                selectedRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
                selectedRow.Background = Brushes.LightBlue;
                spUpdatePrice.Visibility = Visibility.Visible;
                Price = _selectedProduct.PriceInput;
                txtPriceInput.Text = _selectedProduct.PriceInput.ToString();
            }
        }

        private void btnUpdatePrice_Click(object sender, RoutedEventArgs e)
        {
            if (txtPriceInput.Text == string.Empty || double.Parse(txtPriceInput.Text) <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            this._selectedProduct.PriceInput = double.Parse(txtPriceInput.Text);

            if (lstCategories.SelectedValue.ToString() == "Electronic")
            {
                XMLFileManager.WriteElectronic(_ElectronicVM.electronicRepo);
            }
            else if (lstCategories.SelectedValue.ToString() == "Porcelain")
            {
                XMLFileManager.WritePorcelain(_PorcelainVM.porcelainRepo);
            }
            else if (lstCategories.SelectedValue.ToString() == "Food")
            {
                XMLFileManager.WriteFood(_FoodVM.foodRepo);
            }

            var product1 = _InventoryManagerVM.ImportInventory.Items.Find(item => item.Id == _selectedProduct.Id);
            var product2 = _InventoryManagerVM.ExportInventory.Items.Find(item => item.Id == _selectedProduct.Id);

            if (product1 != null)
                product1.PriceInput = _selectedProduct.PriceInput;

            if (product2 != null)
                product2.PriceInput = _selectedProduct.PriceInput;
            _InventoryManagerVM.SaveImportInventory(new RepositoryBase<IProduct>());
            _InventoryManagerVM.SaveExportInventory(new RepositoryBase<IProduct>());

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);
            txtPriceInput.Text = _selectedProduct.PriceInput.ToString("N0");
        }

        private void txtPriceInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtPriceInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtPriceInput.Text.Replace(",", "").Length > 9)
            {
                txtPriceInput.Text = txtPriceInput.Text.Substring(0, 11);
                return;
            }
            if (txtPriceInput.Text == string.Empty)
                return;
            txtPriceInput.Text = txtPriceInput.Text.Trim();
            txtPriceInput.Text = double.Parse(txtPriceInput.Text).ToString("N0");
            txtPriceInput.SelectionStart = txtPriceInput.Text.Length;
        }
    }
}
