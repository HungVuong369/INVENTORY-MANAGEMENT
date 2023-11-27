using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        AccountList accountList = new AccountList();

        private bool isLogin = false;
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private bool openNewWindow(Account account)
        {
            if(account.role == "admin")
            {
                AdminWindow adminWindow = new AdminWindow(new AccountDTO(account.username));
                adminWindow.Show();
                return true;
            }
            else if (account.role == "stocker")
            {
                StockerWindow stockerWindow = new StockerWindow(new AccountDTO(account.username));

                stockerWindow.Show();
                return true;
            }
            else if (account.role == "cashier")
            {
                CashierWindow cashier = new CashierWindow(new AccountDTO(account.username));
                cashier.Show();
                return true;
            }
            return false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            foreach (var account in accountList.lstAccount)
            {
                SecureString securePassword = txtPassword.SecurePassword;
                IntPtr bstrPtr = Marshal.SecureStringToBSTR(securePassword);
                string password = Marshal.PtrToStringBSTR(bstrPtr);

                if (string.Compare(txtUsername.Text.ToLower(), account.username.ToLower()) == 0
                    && string.Compare(password.ToLower(), account.password.ToLower()) == 0)
                {
                    if (openNewWindow(account))
                    {
                        isLogin = true;
                        this.Close();
                        return;
                    }
                }

            }
            MessageBox.Show("Mật khẩu không đúng. Vui lòng thử lại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            ResetTextBox();
        }

        private void ResetTextBox()
        {
            txtPassword.Clear();
            txtUsername.Clear();
            txtUsername.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "\r")
            {
                btnLogin.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        public static void ShowLoginForm()
        {
            LoginWindow login = new LoginWindow();
            login.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isLogin == false)
                Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button.Content.ToString() == "Stocker")
            {
                txtUsername.Text = "Stocker";
                txtPassword.Password = "Stocker";
            }
            if (button.Content.ToString() == "Cashier")
            {
                txtUsername.Text = "Cashier";
                txtPassword.Password = "Cashier";
            }
            if (button.Content.ToString() == "Admin")
            {
                txtUsername.Text = "Admin";
                txtPassword.Password = "Admin";
            }

            btnLogin_Click(new object(), new RoutedEventArgs());
        }
    }
}
