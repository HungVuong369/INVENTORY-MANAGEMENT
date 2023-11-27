using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SaveReceipt.xaml
    /// </summary>
    public partial class ucDetailReceipt : UserControl
    {
        public delegate void SaveReceipt(object sender, RoutedEventArgs e);
        public event SaveReceipt SaveReceiptEvent;

        private ReceiptViewModel _ReceiptVM;
        private CategoryViewModel _CategoryVM = new CategoryViewModel();

        private ProductViewModel _ProductVM = new ProductViewModel();
        private ElectronicViewModel _ElectronicVM = new ElectronicViewModel();
        private PorcelainViewModel _PorcelainVM = new PorcelainViewModel();
        private FoodViewModel _FoodVM = new FoodViewModel();

        private IInventoryManager inventoryManager = new InventoryManagerService();
        private InventoryManagerViewModel _InventoryManagerVM;

        private IProduct _selectedProduct;

        public ReceiptViewModel ReceiptVM
        {
            get
            {
                return _ReceiptVM;
            }
        }

        public int Quantity = 0;

        private bool isCreated = false;

        public ucDetailReceipt(ReceiptViewModel receiptVM)
        {
            InitializeComponent();

            this._ReceiptVM = receiptVM;

            lstCategories.ItemsSource = _CategoryVM.categoryRepo.Values;
            lstCategories.SelectedIndex = 0;

            this._InventoryManagerVM = new InventoryManagerViewModel(inventoryManager);

            this.DataContext = this;
        }

        public void Reset()
        {
            _ElectronicVM.electronicRepo.Items.ForEach(element => element.Quantity = 0);
            _PorcelainVM.porcelainRepo.Items.ForEach(element => element.Quantity = 0);
            _FoodVM.foodRepo.Items.ForEach(element => element.Quantity = 0);
        }

        private void lstCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCategories.SelectedIndex == -1)
                return;
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

            _selectedProduct = null;
            if(isCreated == true)
                txtQuantity.Text = "0";
            txtQuantity.IsEnabled = false;
            btnAddProduct.IsEnabled = false;
            btnIncrease.IsEnabled = false;
            btnDecrease.IsEnabled = false;
            btnAddProduct.Content = "Thêm";
            isCreated = true;
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedIndex == -1)
                return;

            if (dgProducts.SelectedItem != null)
            {
                this._selectedProduct = (IProduct)dgProducts.SelectedItem;

                var dataGrid = (DataGrid)sender;

                txtQuantity.IsEnabled = true;
                btnAddProduct.IsEnabled = true;
                btnIncrease.IsEnabled = true;
                btnDecrease.IsEnabled = true;

                txtQuantity.Text = _selectedProduct.Quantity.ToString();

                if (_ReceiptVM.Receipt.ProductRepo.Items.Find(item => item.Id == _selectedProduct.Id) != null)
                    btnAddProduct.Content = "Cập nhật";
                else
                    btnAddProduct.Content = "Thêm";
            }
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.Trim();
            if ((sender as TextBox).Text == " " || (sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "";
                return;
            }

            txtQuantity.SelectionStart = txtQuantity.Text.Length;
            Quantity = int.Parse(txtQuantity.Text);
        }

        private void txtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
            else
            {
                if (txtQuantity.Text.Length == 9)
                    e.Handled = true;
            }
        }

        private void Clear()
        {
            for (int index = ReceiptVM.Receipt.ProductRepo.Items.Count - 1; index >= 0; index--)
            {
                if (ReceiptVM.Receipt.ProductRepo.Items[index].Quantity == 0)
                    ReceiptVM.Receipt.ProductRepo.Items.RemoveAt(index);
            }
        }

        private void btnSaveReceipt_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();

            if (ReceiptVM.Receipt.ProductRepo.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có muốn lưu phiếu nhập kho?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);
            if(MessageBoxResult.OK == result)
            {
                ReceiptVM.SaveReceipt(ReceiptVM.Receipt);
                _InventoryManagerVM.SaveImportInventory(ReceiptVM.Receipt.ProductRepo);
                _InventoryManagerVM.SaveDetailImportInventory(ReceiptVM.Receipt, _InventoryManagerVM.ImportInventory);

                ReceiptVM.ResetReceipt();

                MessageBox.Show("Tạo phiếu nhập kho thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveReceiptEvent?.Invoke(sender, e);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult isDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);

            if(isDelete == MessageBoxResult.OK)
            {
                string id = (sender as Button).Tag.ToString();

                var product = ReceiptVM.Receipt.ProductRepo.Items.Find(item => item.Id == id);

                product.Quantity = 0;

                ReceiptVM.Receipt.ProductRepo.Items.Remove(product);

                ReceiptVM.GetTotalPrice();
                ReceiptVM.GetTotalQuantity();

                for(int index = wpContainer.Children.Count - 1; index >= 0; index--)
                {
                    dynamic item = wpContainer.Children[index];

                    if (item.bdrContainer.Tag == id)
                        wpContainer.Children.Remove(item);
                }

                if (_selectedProduct.Id == product.Id)
                {
                    dgProducts.SelectedIndex = -1;
                    _selectedProduct = null;
                    txtQuantity.Text = "0";
                    btnAddProduct.Content = "Thêm";
                }
            }
        }

        private ucInformationProduct CreateInformationProduct()
        {
            ucInformationProduct ucInformation = new ucInformationProduct();
            dynamic selectedProduct = _selectedProduct;

            ucInformation.bdrContainer.Tag = _selectedProduct.Id;
            ucInformation.btnDelete.Tag = _selectedProduct.Id;
            ucInformation.lbiInformation.Content = $"Mã: {_selectedProduct.Id}\nTên: {_selectedProduct.Name}\nGiá nhập: {_selectedProduct.PriceInput.ToString("N0")} VND\nSố lượng: {_selectedProduct.Quantity.ToString("N0")}\nTổng tiền: {selectedProduct.TotalInput.ToString("N0")} VND";
            ucInformation.bdrContainer.Style = new CategoryStyleSelector().SelectStyle(_selectedProduct.Category, new DependencyObject());

            ucInformation.lbiInformation.MouseLeftButtonUp += LbiInformation_MouseLeftButtonUp;
            ucInformation.btnDelete.Click += btnDelete_Click;
            ucInformation.bdrContainer.Width = 170;

            return ucInformation;
        }

        private void LbiInformation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = new Window();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            ListBoxItem lbi = new ListBoxItem();
            lbi.Content = (sender as ListBoxItem).Content;
            lbi.FontSize = 16;
            lbi.Padding = new Thickness(50);
            window.Content = lbi;
            window.SizeToContent = SizeToContent.WidthAndHeight;

            window.ShowDialog();
        }

        private void UpdateInformationProduct()
        {
            foreach (dynamic item in wpContainer.Children)
            {
                dynamic selectedProduct = _selectedProduct;

                if (item.bdrContainer.Tag.ToString() == _selectedProduct.Id)
                {
                    item.lbiInformation.Content = $"Mã: {_selectedProduct.Id}\nTên: {_selectedProduct.Name}\nGiá nhập: {_selectedProduct.PriceInput.ToString("N0")} VND\nSố lượng: {_selectedProduct.Quantity.ToString("N0")}\nTổng tiền: {selectedProduct.TotalInput.ToString("N0")} VND";
                    break;
                }
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (int.Parse(txtQuantity.Text) == 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _selectedProduct.Quantity = int.Parse(txtQuantity.Text);

            var product = _ReceiptVM.Receipt.ProductRepo.Items.Find(item => item.Id == _selectedProduct.Id);
            if (product == null)
            {
                _ReceiptVM.Receipt.ProductRepo.Items.Add(_selectedProduct);

                wpContainer.Children.Add(CreateInformationProduct());

                btnAddProduct.Content = "Cập nhật";
            }
            else
                UpdateInformationProduct();

            ReceiptVM.GetTotalPrice();
            ReceiptVM.GetTotalQuantity();
            this.Clear();
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                txtQuantity.Text = "1";
                return;
            }
            if(txtQuantity.Text != "999999999")
                txtQuantity.Text = (int.Parse(txtQuantity.Text) + 1).ToString();
        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                txtQuantity.Text = "0";
                return;
            }

            if (txtQuantity.Text != "0")
                txtQuantity.Text = (int.Parse(txtQuantity.Text) - 1).ToString();
        }
    }
}
