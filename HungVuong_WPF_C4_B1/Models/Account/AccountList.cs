using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1 {
    class AccountList
    {
        public List<Account> lstAccount { get; set; }

        public AccountList() {
            lstAccount = DataProvider.getListAccount(true);
        }
    }
}
