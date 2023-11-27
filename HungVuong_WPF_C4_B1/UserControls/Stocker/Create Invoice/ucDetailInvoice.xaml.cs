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
    /// Interaction logic for ucDetailInvoice.xaml
    /// </summary>
    public partial class ucDetailInvoice : UserControl
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public delegate void SaveInvoice(object sender, RoutedEventArgs e);
        public event SaveInvoice SaveInvoiceEvent;

        private InvoiceViewModel _InvoiceVM;
        private ProductViewModel _ProductVM = new ProductViewModel();

        private ElectronicViewModel _ElectronicVM = new ElectronicViewModel();
        private PorcelainViewModel _PorcelainVM = new PorcelainViewModel();
        private FoodViewModel _FoodVM = new FoodViewModel();

        private IInventoryManager inventoryManager = new InventoryManagerService();
        private InventoryManagerViewModel _InventoryManagerVM;

        public InventoryManagerViewModel InventoryManagerVM
        {
            get
            {
                return _InventoryManagerVM;
            }
        }

        private IProduct _selectedProduct;
        private InventoryItem _SelectedInventoryItem;
        private int _Max;

        public InvoiceViewModel InvoiceVM
        {
            get
            {
                return _InvoiceVM;
            }
        }

        public ucDetailInvoice(InvoiceViewModel invoiceVM)
        {
            InitializeComponent();

            this._InvoiceVM = invoiceVM;
            _InventoryManagerVM = new InventoryManagerViewModel(inventoryManager);

            InventoryManagerVM.ImportInventory = DataProvider.GetImportInventory();
            InventoryManagerVM.ExportInventory = DataProvider.GetExportInventory();

            dgProducts.ItemsSource = _InventoryManagerVM.ImportInventory.Items;

            _ProductVM.productRepo.Items.Clear();
            _ProductVM.productRepo.Items.AddRange(_ElectronicVM.electronicRepo.Items);
            _ProductVM.productRepo.Items.AddRange(_PorcelainVM.porcelainRepo.Items);
            _ProductVM.productRepo.Items.AddRange(_FoodVM.foodRepo.Items);
        }

        public void Reset()
        {
            _ProductVM.productRepo.Items.ForEach(element => element.Quantity = 0);
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

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.Trim();
            if ((sender as TextBox).Text == " " || (sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "";
                return;
            }

            txtQuantity.SelectionStart = txtQuantity.Text.Length;
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedIndex == -1)
                return;

            if (dgProducts.SelectedItem != null)
            {
                this._selectedProduct = _ProductVM.productRepo.Items.Find(item => item.Id == (dgProducts.SelectedItem as IProduct).Id);
                this._SelectedInventoryItem = dgProducts.SelectedItem as InventoryItem;

                var dataGrid = (DataGrid)sender;

                txtQuantity.IsEnabled = true;
                btnAddProduct.IsEnabled = true;
                btnIncrease.IsEnabled = true;
                btnDecrease.IsEnabled = true;

                txtQuantity.Text = _selectedProduct.Quantity.ToString();

                _Max = (dgProducts.SelectedItem as IProduct).Quantity;
                _InvoiceVM.Invoice.ProductRepo.Items.ForEach(item =>
                {
                    if (item.Id == (dgProducts.SelectedItem as InventoryItem).Id)
                        _Max += item.Quantity;
                });

                if (_InvoiceVM.Invoice.ProductRepo.Items.Find(item => item.Id == _selectedProduct.Id) != null)
                    btnAddProduct.Content = "Cập nhật";
                else
                    btnAddProduct.Content = "Thêm";
            }
        }

        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();

            if (InvoiceVM.Invoice.ProductRepo.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có muốn lưu phiếu xuất kho?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);
            if(MessageBoxResult.OK == result)
            {
                InventoryManagerVM.ImportInventory = DataProvider.GetImportInventory();
                InventoryManagerVM.ExportInventory = DataProvider.GetExportInventory();

                InvoiceVM.SaveInvoice(InvoiceVM.Invoice);
                _InventoryManagerVM.SaveExportInventory(InvoiceVM.Invoice.ProductRepo);

                _InventoryManagerVM.UpdateImportInventory(InvoiceVM.Invoice.ProductRepo);
                _InventoryManagerVM.SaveImportInventory(new RepositoryBase<IProduct>());

                _InventoryManagerVM.SaveDetailExportInventory(InvoiceVM.Invoice, _InventoryManagerVM.ExportInventory);

                InvoiceVM.ResetInvoice();

                MessageBox.Show("Tạo phiếu xuất kho thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveInvoiceEvent?.Invoke(sender, e);
            }
        }

        private void Clear()
        {
            for (int index = InvoiceVM.Invoice.ProductRepo.Items.Count - 1; index >= 0; index--)
            {
                if (InvoiceVM.Invoice.ProductRepo.Items[index].Quantity == 0)
                    InvoiceVM.Invoice.ProductRepo.Items.RemoveAt(index);
            }
        }

        private ucInformationProduct CreateInformationProduct()
        {
            ucInformationProduct ucInformation = new ucInformationProduct();
            dynamic selectedProduct = _selectedProduct;

            ucInformation.bdrContainer.Tag = _selectedProduct.Id;
            ucInformation.btnDelete.Tag = _selectedProduct.Id;
            ucInformation.lbiInformation.Content = $"Mã: {_selectedProduct.Id}\nTên: {_selectedProduct.Name}\nGiá bán: {_selectedProduct.PriceOutput.ToString("N0")} VND\nGiá giảm: {(_selectedProduct.PriceOutput - selectedProduct.PriceDiscount).ToString("N0")} VND\nSố lượng: {_selectedProduct.Quantity.ToString("N0")}\nTổng tiền: {selectedProduct.TotalOutput.ToString("N0")} VND";

            ucInformation.bdrContainer.Style = new CategoryStyleSelector().SelectStyle(_selectedProduct.Category, new DependencyObject());
            ucInformation.btnDelete.Click += btnDelete_Click;
            ucInformation.lbiInformation.MouseLeftButtonUp += LbiInformation_MouseLeftButtonUp;
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
                    item.lbiInformation.Content = $"Mã: {_selectedProduct.Id}\nTên: {_selectedProduct.Name}\nGiá bán: {_selectedProduct.PriceOutput.ToString("N0")} VND\nGiá giảm: {(_selectedProduct.PriceOutput - selectedProduct.PriceDiscount).ToString("N0")} VND\nSố lượng: {_selectedProduct.Quantity.ToString("N0")}\nTổng tiền: {selectedProduct.TotalOutput.ToString("N0")} VND";
                    break;
                }
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(int.Parse(txtQuantity.Text) > this._Max || int.Parse(txtQuantity.Text) == 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var product = _InvoiceVM.Invoice.ProductRepo.Items.Find(item => item.Id == _selectedProduct.Id);

            if(btnAddProduct.Content.ToString() == "Cập nhật")
            {
                _SelectedInventoryItem.Quantity += _selectedProduct.Quantity;
            }

            _selectedProduct.Quantity = int.Parse(txtQuantity.Text);

            _SelectedInventoryItem.Quantity -= _selectedProduct.Quantity;

            if (product == null)
            {
                _InvoiceVM.Invoice.ProductRepo.Items.Add(_selectedProduct);

                wpContainer.Children.Add(CreateInformationProduct());

                btnAddProduct.Content = "Cập nhật";
            }
            else
                UpdateInformationProduct();

            InvoiceVM.GetTotalPrice();
            InvoiceVM.GetTotalQuantity();

            this.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult isDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);

            if (isDelete == MessageBoxResult.OK)
            {
                string id = (sender as Button).Tag.ToString();

                var product = InvoiceVM.Invoice.ProductRepo.Items.Find(item => item.Id == id);

                foreach(InventoryItem item in dgProducts.ItemsSource)
                {
                    if(item.Id == (sender as Button).Tag.ToString())
                    {
                        item.Quantity += InvoiceVM.Invoice.ProductRepo.Items.Find(element => element.Id == item.Id).Quantity;
                        break;
                    }
                }

                product.Quantity = 0;

                InvoiceVM.Invoice.ProductRepo.Items.Remove(product);

                InvoiceVM.GetTotalPrice();
                InvoiceVM.GetTotalQuantity();

                for (int index = wpContainer.Children.Count - 1; index >= 0; index--)
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

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                txtQuantity.Text = "1";
                return;
            }
            if (txtQuantity.Text != "999999999")
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
