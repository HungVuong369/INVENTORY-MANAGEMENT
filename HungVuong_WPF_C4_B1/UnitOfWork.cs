using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1
{
    class UnitOfWork
    {
        private RepositoryBase<InventoryItem> _ImportInventory;
        private RepositoryBase<InventoryItem> _ExportInventory;

        private RepositoryBase<Electronic> _ElectronicList;
        private RepositoryBase<Porcelain> _PorcelainList;
        private RepositoryBase<Food> _FoodList;
        private Dictionary<string, string> _CategoryList;
        private RepositoryBase<IProduct> _ProductList;

        private RepositoryBase<Customer> _CustomerList;

        public RepositoryBase<InventoryItem> GetRepositoryImportInventory
        {
            get
            {
                if (this._ImportInventory == null)
                    this._ImportInventory = new RepositoryBase<InventoryItem>();
                return this._ImportInventory;
            }
        }

        public RepositoryBase<Customer> GetRepositoryCustomer
        {
            get
            {
                if (this._CustomerList == null)
                    this._CustomerList = new RepositoryBase<Customer>();
                return this._CustomerList;
            }
        }

        public RepositoryBase<InventoryItem> GetRepositoryExportInventory
        {
            get
            {
                if (this._ExportInventory == null)
                    this._ExportInventory = new RepositoryBase<InventoryItem>();
                return this._ExportInventory;
            }
        }

        public RepositoryBase<Electronic> GetRepositoryElectronic
        {
            get
            {
                if (this._ElectronicList == null)
                    this._ElectronicList = new RepositoryBase<Electronic>();
                return this._ElectronicList;
            }
        }

        public RepositoryBase<Porcelain> GetRepositoryPorcelain
        {
            get
            {
                if (this._PorcelainList == null)
                    this._PorcelainList = new RepositoryBase<Porcelain>();
                return this._PorcelainList;
            }
        }

        public RepositoryBase<Food> GetRepositoryFood
        {
            get
            {
                if (this._FoodList == null)
                    this._FoodList = new RepositoryBase<Food>();
                return this._FoodList;
            }
        }

        public Dictionary<string, string> GetRepositoryCategory
        {
            get
            {
                if (this._CategoryList == null)
                    this._CategoryList = new Dictionary<string, string>();
                return this._CategoryList;
            }
        }

        public RepositoryBase<IProduct> GetRepositoryProduct
        {
            get
            {
                if (this._ProductList == null)
                    this._ProductList = new RepositoryBase<IProduct>();

                this._ProductList.Items.Clear();

                _ProductList.Items.AddRange(_ElectronicList.Items);
                _ProductList.Items.AddRange(_PorcelainList.Items);
                _ProductList.Items.AddRange(_FoodList.Items);

                return this._ProductList;
            }
        }

        public UnitOfWork() {
            _CustomerList = new RepositoryBase<Customer>();
            _ElectronicList = new RepositoryBase<Electronic>();
            _PorcelainList = new RepositoryBase<Porcelain>();
            _FoodList = new RepositoryBase<Food>();
            _ProductList = new RepositoryBase<IProduct>();

            _CustomerList.BulkInsert(DataProvider.GetListCustomer());

            _CategoryList = DataProvider.GetListCategories();

            _ElectronicList.BulkInsert(DataProvider.GetListElectronic());
            _PorcelainList.BulkInsert(DataProvider.GetListPorcelain());
            _FoodList.BulkInsert(DataProvider.GetListFood());

            _ImportInventory = DataProvider.GetImportInventory();
            _ExportInventory = DataProvider.GetExportInventory();
        }
    }
}
