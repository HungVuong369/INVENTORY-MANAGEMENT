using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_WPF_C4_B1 {
    class Account {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public Account(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }
}
